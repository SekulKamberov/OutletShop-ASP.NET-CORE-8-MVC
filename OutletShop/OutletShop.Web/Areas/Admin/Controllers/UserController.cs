namespace OutletShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc;

    using OutletShop.DataAccess.IRepository;
    using OutletShop.Models.ViewModels;
    using OutletShop.Models;
    using OutletShop.Utility;

    [Area("Admin")]
    [Authorize(Roles = Const.Role_Admin)]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUnitOfWork unitOfWork;

        public UserController(
            UserManager<IdentityUser> _userManager, 
            IUnitOfWork _unitOfWork, 
            RoleManager<IdentityRole> _roleManager)
        {
            unitOfWork = _unitOfWork;
            roleManager = _roleManager;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoleManagment(string userId)
        {

            RoleManagmentVM RoleVM = new RoleManagmentVM()
            {
                User = unitOfWork.User.Get(u => u.Id == userId, includeProperties: "Company"),
                RoleList = roleManager.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),
                CompanyList = unitOfWork.Company.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            RoleVM.User.Role = userManager.GetRolesAsync(unitOfWork.User.Get(u => u.Id == userId))
                    .GetAwaiter().GetResult().FirstOrDefault();
            return View(RoleVM);
        }

        [HttpPost]
        public IActionResult RoleManagment(RoleManagmentVM roleManagmentVM)
        { 
            string oldRole = userManager.GetRolesAsync(unitOfWork.User.Get(u => u.Id == roleManagmentVM.User.Id))
                    .GetAwaiter().GetResult().FirstOrDefault();

            User User = unitOfWork.User.Get(u => u.Id == roleManagmentVM.User.Id);


            if (!(roleManagmentVM.User.Role == oldRole))
            {
                //a role was updated
                if (roleManagmentVM.User.Role == Const.Role_Company)
                {
                    User.CompanyId = roleManagmentVM.User.CompanyId;
                }
                if (oldRole == Const.Role_Company)
                {
                    User.CompanyId = null;
                }
                unitOfWork.User.Update(User);
                unitOfWork.Save();

                userManager.RemoveFromRoleAsync(User, oldRole).GetAwaiter().GetResult();
                userManager.AddToRoleAsync(User, roleManagmentVM.User.Role).GetAwaiter().GetResult();

            }
            else
            {
                if (oldRole == Const.Role_Company && User.CompanyId != roleManagmentVM.User.CompanyId)
                {
                    User.CompanyId = roleManagmentVM.User.CompanyId;
                    unitOfWork.User.Update(User);
                    unitOfWork.Save();
                }
            }

            return RedirectToAction("Index");
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> objUserList = unitOfWork.User.GetAll(includeProperties: "Company").ToList();

            foreach (var user in objUserList)
            {
                user.Role = userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }

            return Json(new { data = objUserList });
        }


        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {

            var objFromDb = unitOfWork.User.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked and we need to unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            unitOfWork.User.Update(objFromDb);
            unitOfWork.Save();
            return Json(new { success = true, message = "Operation Successful" });
        }
        #endregion
    }
}
