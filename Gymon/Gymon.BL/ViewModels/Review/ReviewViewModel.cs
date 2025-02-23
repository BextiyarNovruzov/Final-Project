using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.Review
{
        public class ReviewViewModel
        {
            public int ProductId { get; set; }
            public int UserId { get; set; }
            public string ReviewerName { get; set; }
            public string Comment { get; set; }
            public int Rating { get; set; }
            public DateTime CreatedDate { get; set; } // New property for reviewer's name
        }

}
    