namespace Basic_CRUD.Models
{
    using System;
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public CustomerType Type { get; set; }
        public decimal CreditLimit { get; set; }
        public DateTime CustomerSince { get; set; }
    }
}
