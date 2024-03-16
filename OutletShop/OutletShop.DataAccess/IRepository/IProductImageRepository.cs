namespace OutletShop.DataAccess.IRepository
{
    using OutletShop.Models;

    public interface IProductImageRepository : IRepository<ProductImage>
    {
        void Update(ProductImage obj);
    }
}
