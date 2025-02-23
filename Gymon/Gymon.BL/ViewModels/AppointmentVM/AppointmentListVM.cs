using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.AppointmentVM
{
    public class AppointmentListVM
    {
        public int Id { get; set; }
        public string TrainerName { get; set; }
        public string SportType { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; } // e.g., Confirmed, Canceled
    }

}
