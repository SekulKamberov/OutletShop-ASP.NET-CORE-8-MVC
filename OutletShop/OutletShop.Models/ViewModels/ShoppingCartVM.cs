namespace OutletShop.Models.ViewModels
{
    using OutletShop.Data.EntityModels;

    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader { get; set; } 
    }
}
