namespace OutletShop.DataAccess.Repository
{
    using OutletShop.Data;
    using OutletShop.DataAccess.IRepository;
    using OutletShop.Models;

    public class UserRepository : Repository<User>, IUserRepository
    {
        private OutletDbContext context;
        public UserRepository(OutletDbContext _context) : base(_context)
        {
            context = _context;
        }
        public void Update(User user)
        {
            context.Users.Update(user);
        }
    }
}
