namespace OutletShop.DataAccess.Repository
{
    using OutletShop.Data;
    using OutletShop.Data.EntityModels;
    using OutletShop.DataAccess.IRepository;

    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private OutletDbContext context;
        public OrderHeaderRepository(OutletDbContext _context) : base(_context)
        {
            context = _context;
        } 

        public void Update(OrderHeader obj)
        {
            context.OrderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = context.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = context.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PaymentIntentId = paymentIntentId;
                orderFromDb.PaymentDate = DateTime.Now;
            }
        }
    }
}
