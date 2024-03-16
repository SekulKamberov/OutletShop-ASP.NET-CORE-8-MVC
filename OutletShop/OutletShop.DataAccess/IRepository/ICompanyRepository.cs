namespace OutletShop.DataAccess.IRepository
{
    using OutletShop.Models;

    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
