using API.Context;
using API.Models;
using API.Repositories.Interface;
namespace API.Repositories.Data
{
    public class SellingRepository : GeneralRepository<Selling, string, MyContext>, ISelling
    {
        public SellingRepository(MyContext context) : base(context) { }
    }
}
