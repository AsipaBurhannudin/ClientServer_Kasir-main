using API.Context;
using API.Models;
using API.Repositories.Interface;
namespace API.Repositories.Data
{
    public class PurchaseRepository : GeneralRepository<Purchase, string, MyContext>, IPurchase
    {
        public PurchaseRepository(MyContext context) : base(context) { }
    }
}
