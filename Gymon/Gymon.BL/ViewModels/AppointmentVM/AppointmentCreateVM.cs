using Gymon.Core.Entities;

namespace Gymon.BL.ViewModels.AppointmentVM
{
    public class AppointmentCreateVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrainerId { get; set; }
        public int SportTypeId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string PaymentMethod { get; set; } // Online veya Yerinde
        public string Notes { get; set; }
        public string Phone { get; set; }

        public IEnumerable<SportType> SportTypes { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }
        public IEnumerable<TrainerSchedule> AvailableSchedules { get; set; }
    }
}



