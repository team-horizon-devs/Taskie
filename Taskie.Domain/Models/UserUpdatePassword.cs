using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.User
{
    public class UserUpdatePassword
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
