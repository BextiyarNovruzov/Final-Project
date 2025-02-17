using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities
{
    public class TrainerSportType:BaseEntity
    {
            public int TrainerId { get; set; }
            public virtual Trainer Trainer { get; set; }

            public int SportTypeId { get; set; }
            public virtual SportType SportType { get; set; }
    }

}
