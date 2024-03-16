namespace OutletShop.DataAccess.Repository
{
    using OutletShop.Data;
    using OutletShop.DataAccess.IRepository;
    using OutletShop.Models;

    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private OutletDbContext context;
        public CompanyRepository(OutletDbContext _context) : base(_context)
        {
            context = _context;
        }



        public void Update(Company obj)
        {
            context.Companies.Update(obj);
        }
    }
}
