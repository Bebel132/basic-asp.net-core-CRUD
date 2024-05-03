namespace BasicCrud.Controllers
{
    using System.Linq;
    using Basic_CRUD.Data;
    using Basic_CRUD.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Deltas;
    using Microsoft.AspNetCore.OData.Routing.Controllers;

    public class CustomersController : ODataController
    {
        private readonly BasicCrudDbContext db;

        public CustomersController(BasicCrudDbContext db)
        {
            this.db = db;
        }

        // return all Customers
        [HttpGet("Customers")]
        public ActionResult<IQueryable<Customer>> Get()
        {
            return Ok(db.Customers);
        }

        // return specific Customer by id
        [HttpGet("Customers/{key}")]
        public ActionResult<Customer> Get([FromRoute] int key)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer == null)   
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // add a new Customer
        [HttpPost("Customers")]
        public ActionResult Post([FromBody] Customer customer)
        {
            if (db == null)
            {
                return BadRequest("Database context is null.");
            }

            if (db.Customers == null)
            {
                return BadRequest("Customers set is null.");
            }

            if (customer == null)
            {
                return BadRequest("Customer is null.");
            }

            db.Customers.Add(customer);

            return Ok(customer);
        }

        // update a specific Customer
        [HttpPut("Customers/{key}")]
        public ActionResult Put([FromRoute] int key ,[FromBody] Customer updatedCustomer)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if(customer == null)
            {
                return NotFound();
            }

            customer.Name = updatedCustomer.Name;
            customer.Type = updatedCustomer.Type;
            customer.CreditLimit = updatedCustomer.CreditLimit;
            customer.CustomerSince = updatedCustomer.CustomerSince;

            db.SaveChanges();

            return Ok(customer);
        }

        // delete a specific Customer
        [HttpDelete("Customers/{key}")]
        public ActionResult Delete([FromRoute] int key)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if(customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);

            return NoContent();
        }
    }
}