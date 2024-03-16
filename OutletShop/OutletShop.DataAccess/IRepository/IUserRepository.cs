namespace OutletShop.DataAccess.IRepository
{
    using OutletShop.Models;

    public interface IUserRepository : IRepository<User>
    {
        public void Update(User user);
    }
}
