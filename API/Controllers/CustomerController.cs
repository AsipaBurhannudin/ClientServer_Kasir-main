using API.Base;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : GeneralController<IItem, Item, string>
    {
       public ItemController(IItem item) : base(item) { }
    }
}
