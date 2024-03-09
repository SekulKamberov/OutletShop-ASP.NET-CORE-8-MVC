namespace OutletShop.Data.DBInitializer
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore; 

    using OutletShop.Models;
    using OutletShop.Utility;

    public class DBInitializer : IDBInitializer
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly OutletDbContext context;

        public DBInitializer(
            UserManager<IdentityUser> _userManager,
            RoleManager<IdentityRole> _roleManager,
            OutletDbContext _context)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            context = _context;
        }

        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (context.Database.GetPendingMigrations().Count() > 0)
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            //create roles if they are not created
            if (!roleManager.RoleExistsAsync(Const.Role_Customer).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(Const.Role_Customer)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(Const.Role_Employee)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(Const.Role_Admin)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(Const.Role_Company)).GetAwaiter().GetResult();


                //if roles are not created, then we will create admin user as well
                userManager.CreateAsync(new User
                {
                    UserName = "admin@sekulkamberov.com",
                    Email = "admin@sekulkamberov.com",
                    Name = "Sekul Kamberov",
                    PhoneNumber = "359123456789",
                    StreetAddress = "Shipka Ave",
                    State = "Sofia",
                    PostalCode = "1000",
                    City = "Sofia"
                }, "Admin123*").GetAwaiter().GetResult();


                User user = context.Users.FirstOrDefault(u => u.Email == "admin@sekulkamberov.com");
                userManager.AddToRoleAsync(user, Const.Role_Admin).GetAwaiter().GetResult();

            }

            return;
        }
    }
}
