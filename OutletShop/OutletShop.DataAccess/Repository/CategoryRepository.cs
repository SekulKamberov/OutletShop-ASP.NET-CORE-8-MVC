namespace OutletShop.DataAccess.Repository
{
    using OutletShop.Data;
    using OutletShop.DataAccess.IRepository;
    using OutletShop.Models;

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private OutletDbContext context;
        public CategoryRepository(OutletDbContext _context) : base(_context)
        {
            context = _context;
        }
         
        public void Update(Category obj)
        {
            context.Categories.Update(obj);
        }
    }
}
