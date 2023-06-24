using API.Models;
using API.ViewModels;

namespace API.Repositories.Interface
{
    public interface IUsers : IGeneralRepository<Users, int>
    {
        bool Login(LoginVM loginVm);
        int Register(RegisterVM registerVM);

    }
}
