namespace OutletShop.DataAccess.Repository
{
    using OutletShop.Data;
    using OutletShop.DataAccess.IRepository;
    using OutletShop.Models;

    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        private OutletDbContext context;
        public ProductImageRepository(OutletDbContext _context) : base(_context)
        {
            context = _context;
        } 

        public void Update(ProductImage obj)
        {
            context.ProductImages.Update(obj);
        }
    }
}
