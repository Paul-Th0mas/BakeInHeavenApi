using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataservices.Models.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage ="UserName is required ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required ")]
        public string password { get; set; }
    }
}
