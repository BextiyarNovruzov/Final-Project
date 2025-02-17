using Gymon.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gymon.BL.ViewModels.TrainnerVMs
{
    public class UpdateTrainerVM
    {
            public string? FullName { get; set; }

            public IFormFile? Image { get; set; }

            public decimal? HourlyRate { get; set; }

            // Trainer'ın seçili Spor Türleri
            public List<int> TrainerSportTypesId { get; set; } = new List<int>();

            // SportTypes listesini dropdown için kullanacağız
            public List<SelectListItem> SportTypes { get; set; } = new List<SelectListItem>();

            // Email ve Phone alanları
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public string? ImageUrl { get; set; }
            public int Id { get; set; }

    }
}
