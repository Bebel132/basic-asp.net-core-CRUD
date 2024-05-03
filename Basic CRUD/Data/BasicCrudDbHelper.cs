namespace BasicCrud.Data
{
    using System;
    using System.Linq;
    using Basic_CRUD.Data;
    using Basic_CRUD.Models;

    internal static class BasicCrudDbHelper
    {
        public static void SeedDb(BasicCrudDbContext db)
        {
            if (!db.Customers.Any())
            {
                db.Add(new Customer
                {
                    Id = 1,
                    Name = "Sue",
                    Type = CustomerType.Retail,
                    CreditLimit = 3700,
                    CustomerSince = new DateTime(2022, 7, 4)
                });

                db.Add(new Customer
                {
                    Id = 2,
                    Name = "Joe",
                    Type = CustomerType.Wholesale,
                    CreditLimit = 5100,
                    CustomerSince = new DateTime(2022, 12, 12)
                });

                db.SaveChanges();
            }
        }
    }
}