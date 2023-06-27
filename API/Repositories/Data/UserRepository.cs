using API.Context;
using API.Handlers;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;

namespace API.Repositories.Data
{
    public class UsersRepository : GeneralRepository<Users, string, MyContext>, IUsers
    {
        public UsersRepository(MyContext context) : base(context) { }

        public int Register(RegisterVM registerVM)
        {
            int result = 0;

            // Insert to Users Table
            var users = new Users
            {
                user_code = registerVM.UserCode,
                password = Hashing.HashPassword(registerVM.Password),
                name = registerVM.Name,
                position = registerVM.Position,
                gender = registerVM.Gender,
                address = registerVM.Address,
                phone_number = registerVM.PhoneNumber
            };
            _context.Set<Users>().Add(users);
            result += _context.SaveChanges();

            return result;
        }

        //LOGIN MASIH ERROR
        public bool Login(LoginVM loginVm)
        {

            var getUserAccount = _context.Userss.FirstOrDefault(u => u.user_code == loginVm.UserCode);

            if (getUserAccount == null)

                return false;

            return Hashing.ValidatePassword(loginVm.Password, getUserAccount.password);
        }
    }
}