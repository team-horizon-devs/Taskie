using System;
using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.Avatar
{
    public class AvatarDto
    {
        public int Id{ get; set; }
        public string Desciption { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
