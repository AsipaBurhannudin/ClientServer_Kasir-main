using API.Context;
using API.Handlers;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;

namespace API.Repositories.Data
{
    public class UsersRepository : GeneralRepository<Users, int, MyContext>, IUsers
    {
        public UsersRepository(MyContext context) : base(context) { }

        public int Register(RegisterVM registerVM)
        {
            int result = 0;

            // Insert to Users Table
            var users = new Users
            {
                user_code = registerVM.UserCode,
                password = registerVM.Password,
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

            var getUserAccount = _context.Userss.Join(_context.Userss,
                u => u.user_code,
                p => p.password,
                (u, p) => new
                {
                    UserCode = u.user_code,
                    Password = p.password,
                }).FirstOrDefault(u => u.UserCode == loginVm.UserCode);

            if (getUserAccount == null)
            {
                return false;
            }

            return Hashing.ValidatePassword(loginVm.Password, getUserAccount.Password);
        }
    }
}
