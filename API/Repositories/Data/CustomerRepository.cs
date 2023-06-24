using API.Context;
using API.Models;
using API.Repositories.Interface;
namespace API.Repositories.Data
{
    public class CustomerRepository : GeneralRepository<Customer, int, MyContext>, ICustomer
    {
        public CustomerRepository(MyContext context) : base(context) { }
    }
}
