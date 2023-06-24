using API.Base;
using API.Handlers;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace API.Controllers
{
    public class UsersController : GeneralController<IUsers, Users, int>
    {
        private readonly ITokenService _tokenService;
        private readonly ICustomer _customerRepository;

        public UsersController(
            IUsers users,
            ITokenService tokenService,
            ICustomer customerRepository) : base(users) 
        {
        _tokenService = tokenService;
        _customerRepository = customerRepository;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = _repository.Login(loginVM);
            if (!login)
            {
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Login Failed, Account or Password Not Found!"
                });
            }

            var claims = new List<Claim>() {
            new Claim("UserCode", loginVM.UserCode),
        };

            var token = _tokenService.GenerateToken(claims);

            return Ok(new ResponseDataVM<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Login Success",
                Data = token
            });
        }

    }
}
