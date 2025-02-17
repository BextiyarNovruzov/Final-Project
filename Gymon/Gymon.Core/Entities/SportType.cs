using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities
{
    public class SportType : BaseEntity
    {
        public string Name { get; set; }
        public decimal PriceMultiplier { get; set; }
        // SportType'a ait olan tüm TrainerSportType ilişkileri
        public ICollection<TrainerSportType> TrainerSportTypes { get; set; } = new List<TrainerSportType>(); // SportType ile Trainer ilişkisi

        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();
}
}
