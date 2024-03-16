namespace OutletShop.DataAccess.Repository
{
    using OutletShop.Data;
    using OutletShop.DataAccess.IRepository;
    using OutletShop.Models;

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private OutletDbContext context;
        public ProductRepository(OutletDbContext _context) : base(_context)
        {
            context = _context;
        } 
        public void Update(Product obj)
        {
            var objFromDb = context.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                objFromDb.ProductImages = obj.ProductImages;
                //if (obj.ImageUrl != null)
                //{
                //    objFromDb.ImageUrl = obj.ImageUrl;
                //}
            }
        }
    }
}
