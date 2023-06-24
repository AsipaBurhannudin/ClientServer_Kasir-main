using API.Context;
using API.Models;
using API.Repositories.Interface;
namespace API.Repositories.Data
{
    public class SalesDetailRepository : GeneralRepository<Salesdetails, string, MyContext>, ISalesDetail
    {
        public SalesDetailRepository(MyContext context) : base(context) { }
    }
}
