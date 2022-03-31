using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskie.Domain.Dto.User
{
    public class UserUpdatePasswordDto
    {
        public string Id { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Senhas não conferem")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }

    }
        
}
