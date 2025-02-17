
namespace Gymon.Core.Entities
{
    public class Trainer : BaseEntity
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal HourlyRate { get; set; } // Saatlik ücret

        public virtual ICollection<TrainerSportType> TrainerSportTypes { get; set; } = new List<TrainerSportType>();

        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<TrainerSchedule> Schedules { get; set; } = new List<TrainerSchedule>();
    }
}
