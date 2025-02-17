using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.SportTypeVMs
{
    public class CreateAndUpdateSportTypeVM
    {
        [Required, MaxLength(32)]
        public string Name { get; set; }
    }
}
