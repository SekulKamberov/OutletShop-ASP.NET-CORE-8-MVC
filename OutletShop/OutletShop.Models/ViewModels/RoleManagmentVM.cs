namespace OutletShop.Models.ViewModels
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class RoleManagmentVM
    {
        public User User { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
    }
}
