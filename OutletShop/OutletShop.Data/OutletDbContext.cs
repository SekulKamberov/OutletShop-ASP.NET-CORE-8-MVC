namespace OutletShop.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using OutletShop.Data.EntityModels;
    using OutletShop.Models;

    public class OutletDbContext : IdentityDbContext<IdentityUser>
    {
        public OutletDbContext(DbContextOptions<OutletDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "IB Solutions",
                    StreetAddress = "Killarney Heights St",
                    City = "Dublin",
                    PostalCode = " D17",
                    State = "DB",
                    PhoneNumber = "353878789987"
                },
                new Company
                {
                    Id = 2,
                    Name = "EMT Solutions",
                    StreetAddress = "Manitoba St",
                    City = " Waterford",
                    PostalCode = "X91 A004",
                    State = "TR",
                    PhoneNumber = "353878789983"
                },
                new Company
                {
                    Id = 3,
                    Name = "SSG Corporation",
                    StreetAddress = "Tramor St",
                    City = "Dublin",
                    PostalCode = "99999",
                    State = "TR",
                    PhoneNumber = "353878789982"
                }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Microsoft SQL Server 2019 7th Edition",
                    Author = "Dusan Petkovic",
                    Description = "Start working with Microsoft SQL Server 2019 in no time with help from this thoroughly revised, practical resource. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "SQL for Data Analytics",
                    Author = "Jun Shan",
                    Description = "Take your first steps to becoming a fully qualified data analyst by learning how to explore complex datasets",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Title = "SQL Data Analytics Made Easy",
                    Author = "L.D. Knowings",
                    Description = "Your Step-by-Step Guide to Unlocking Data’s Hidden Secrets: Demystify complex concepts, and harness the power of data to drive intelligent decision-making effortlessly.",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Title = "SQL All-in-One For Dummies",
                    Author = "Allen G. Taylor",
                    Description = "Access, Microsoft SQL Server, Oracle databases, MySQL, and PostgreSQL.",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    Title = "Python Programming and SQL",
                    Author = "Mark Reed",
                    Description = "This 5-in-1 guide covers both Python and SQL fundamental and advanced concepts",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Title = "Python Crash Course, 3rd Edition",
                    Author = "Eric Matthes",
                    Description = "Python Crash Course is the world’s best-selling guide to the Python programming language. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 3
                }
                );
        }
    }
}
