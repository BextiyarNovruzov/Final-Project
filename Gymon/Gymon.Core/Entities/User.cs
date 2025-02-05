using Gymon.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities
{
    public class User:BaseEntity
    {
        public string Username { get; set; }
        public string ComplateName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Roles Role { get; set; }
    }
}
