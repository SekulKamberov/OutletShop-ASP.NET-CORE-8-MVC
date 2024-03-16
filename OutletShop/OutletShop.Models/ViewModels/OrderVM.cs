namespace OutletShop.Models.ViewModels
{
    using OutletShop.Data.EntityModels;

    public class OrderVM
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetail> OrderDetail { get; set; }
    }
}
