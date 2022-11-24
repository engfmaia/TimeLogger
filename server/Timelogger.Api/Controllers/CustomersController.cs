using Microsoft.AspNetCore.Mvc;
using Timelogger.Api.Models;
using Timelogger.Services.Customers;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_customersService.GetCustomer(id));
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            return Ok(_customersService.GetCustomers());
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewCustomer newCustomer)
        {
            return Ok(_customersService.CreateCustomer(newCustomer.Name));
        }
    }
}
