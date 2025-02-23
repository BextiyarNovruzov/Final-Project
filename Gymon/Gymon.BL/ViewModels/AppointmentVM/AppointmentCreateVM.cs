using Gymon.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gymon.BL.ViewModels.AppointmentVM
{
    public class AppointmentCreateVM
    {
        public string FullName { get; set; } // User Full Name
        public int TrainerId { get; set; }
        public int SportTypeId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Notes { get; set; }
        public string Phone { get; set; }
        public string Email {get;set;}
        public IEnumerable<SportType> SportTypes { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }
    }
}



