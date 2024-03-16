namespace OutletShop.DataAccess.Repository
{
    using OutletShop.Data;
    using OutletShop.DataAccess.IRepository;
    using OutletShop.Models;

    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private OutletDbContext context;
        public ShoppingCartRepository(OutletDbContext _context) : base(_context)
        {
            context = _context;
        }
         
        public void Update(ShoppingCart obj)
        {
            context.ShoppingCarts.Update(obj);
        }
    }
}
