namespace OutletShop.DataAccess.IRepository
{
    using OutletShop.Models;

    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
