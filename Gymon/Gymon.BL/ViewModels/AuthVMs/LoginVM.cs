using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.AuthVMs
{
    public class LoginVM
    {
        [Required, MaxLength(32)]
        public string UserNameOrEmail { get; set; }
        [Required, MaxLength(64), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
