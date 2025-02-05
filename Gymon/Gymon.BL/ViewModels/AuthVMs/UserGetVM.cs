using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.AuthVMs
{
    public class UserGetVM
    {
        public string ComplateName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }
    }
}
