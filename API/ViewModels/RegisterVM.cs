using API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ViewModels
{
    public class RegisterVM
    {
        public string UserCode { get; set; }
        
        public string Password { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
