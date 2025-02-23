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
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string ComplateName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<OrderDetail> Orders { get; set; } = new List<OrderDetail>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public Roles Role { get; set; }
    }
}
