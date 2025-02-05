using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.AuthVMs
{
    public class RegisterVM
    {
        [Required, MaxLength(32)]
        public string Username { get; set; }
        [Required, MaxLength(64)]
        public string ComplateName { get; set; }
        [Required, MaxLength(64), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(64), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(64), DataType(DataType.Password), Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
