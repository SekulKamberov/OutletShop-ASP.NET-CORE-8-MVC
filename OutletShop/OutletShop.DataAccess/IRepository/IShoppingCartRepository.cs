namespace OutletShop.DataAccess.IRepository
{
    using OutletShop.Models;

    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart obj);
    }
}
