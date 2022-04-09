using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.User
{
    public class UserUpdatePhone
    {
        public string Id { get; set; }

        [StringLength(20, ErrorMessage = "Telefone deve ter no máximo {1} caracteres.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
        
}
