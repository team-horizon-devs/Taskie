using System;

namespace Taskie.Domain.Models
{
    public class EmailSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public Int32 Port { get; set; }
    }
}
