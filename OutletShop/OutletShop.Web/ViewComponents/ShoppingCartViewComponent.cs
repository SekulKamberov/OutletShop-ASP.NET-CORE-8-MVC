namespace OutletShop.Web.ViewComponents
{
    using System.Security.Claims; 
    using Microsoft.AspNetCore.Mvc; 
    using OutletShop.DataAccess.IRepository;
    using OutletShop.Utility;

    public class ShoppingCartViewComponent : ViewComponent
    { 
            private readonly IUnitOfWork _unitOfWork;
            public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IViewComponentResult> InvokeAsync()
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if (claim != null)
                {

                    if (HttpContext.Session.GetInt32(Const.SessionCart) == null)
                    {
                        HttpContext.Session.SetInt32(Const.SessionCart,
                        _unitOfWork.ShoppingCart.GetAll(u => u.UserId == claim.Value).Count());
                    }

                    return View(HttpContext.Session.GetInt32(Const.SessionCart));
                }
                else
                {
                    HttpContext.Session.Clear();
                    return View(0);
                }
            } 
    } 
}
