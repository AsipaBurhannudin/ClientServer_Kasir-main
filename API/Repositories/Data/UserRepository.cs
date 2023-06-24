using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;

namespace API.Repositories.Data
{
    public class UsersRepository : GeneralRepository<Users, int, MyContext>, IUsers
    {
        public UsersRepository(MyContext context) : base(context) { }

        public bool Login(LoginVM loginVm)
        {
            throw new NotImplementedException();
        }
    }
}
