using Gymon.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities
{
    public class Appointment : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Phone { get; set; }
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

        public int SportTypeId { get; set; }
        public virtual SportType SportType { get; set; }

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        public AppointmentStatus Status { get; set; }

        // User'ı almak için ilişkiyi belirtelim
        public string Email { get; set; }  // User Email
        public string FullName { get; set; } // User Full Name
        public string Notes { get; set; }

    }

}