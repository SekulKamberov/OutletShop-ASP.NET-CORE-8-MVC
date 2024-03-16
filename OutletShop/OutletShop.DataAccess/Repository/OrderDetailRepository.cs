namespace OutletShop.DataAccess.Repository
{
    using OutletShop.Data;
    using OutletShop.Data.EntityModels;
    using OutletShop.DataAccess.IRepository;

    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private OutletDbContext context;
        public OrderDetailRepository(OutletDbContext _context) : base(_context)
        {
            context = _context;
        } 

        public void Update(OrderDetail obj)
        {
            context.OrderDetails.Update(obj);
        }
    }
}
