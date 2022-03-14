using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.User
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(80, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "UserName é um campo obrigatório")]
        [StringLength(20, ErrorMessage = "UserName deve ter no máximo {1} caracteres.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Este formato de Email é inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
