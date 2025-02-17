namespace Gymon.Core.Entities
{
    public class TrainerSchedule : BaseEntity
    {
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; } // Lazy Loading için virtual

        public DateTime AvailableDate { get; set; } // Kullanıcının seçtiği tam tarih
        public DayOfWeek Day { get; set; } // Haftanın günü (Pazartesi, Salı, vb.)
        public TimeSpan StartTime { get; set; } // Örn. 09:00
        public TimeSpan EndTime { get; set; } // Örn. 18:00
        public bool IsBooked { get; set; } // Rezervasyon durumu

        // Validation: EndTime, StartTime'dan büyük olmalı
        public bool IsValidSchedule() => EndTime > StartTime;
    }

}
