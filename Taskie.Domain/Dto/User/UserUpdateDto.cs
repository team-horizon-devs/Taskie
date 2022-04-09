﻿using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.User
{
    public class UserUpdateDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(80, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [StringLength(20, ErrorMessage = "Telefone deve ter no máximo {1} caracteres.")]
        public string PhoneNumber { get; set; }

    }
        
}
