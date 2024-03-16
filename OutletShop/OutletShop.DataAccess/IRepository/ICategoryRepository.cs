namespace OutletShop.DataAccess.IRepository
{
    using OutletShop.Models;

    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
