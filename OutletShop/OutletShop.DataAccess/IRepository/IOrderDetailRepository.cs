namespace OutletShop.DataAccess.IRepository
{
    using OutletShop.Data.EntityModels;

    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void Update(OrderDetail obj);
    }
}
