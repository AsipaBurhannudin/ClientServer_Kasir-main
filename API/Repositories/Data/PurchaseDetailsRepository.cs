using API.Context;
using API.Models;
using API.Repositories.Interface;
namespace API.Repositories.Data
{
    public class PurchaseDetailsRepository : GeneralRepository<PurchaseDetails, string, MyContext>, IPurchaseDetails
    {
        public PurchaseDetailsRepository(MyContext context) : base(context) { }
    }
}
