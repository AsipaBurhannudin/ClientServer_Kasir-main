using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : GeneralController<ICustomer, Customer, int>
    {
       public CustomerController(ICustomer customer) : base(customer) { }
    }
}
