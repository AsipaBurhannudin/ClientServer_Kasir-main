using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesDetailController : GeneralController<ISalesDetail, Salesdetails, string>
    {
       public SalesDetailController(ISalesDetail salesDetails) : base(salesDetails) { }
    }
}
