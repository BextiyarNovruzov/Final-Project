using Gymon.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.TrainnerVMs
{
    public class CreateTrainerVM
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public List<int> TrainerSportTypesId { get; set; } = new List<int>();

        public List<SelectListItem> SportTypes { get; set; } = new List<SelectListItem>();
    }
}
