using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models.ViewModels
{
    public class createAndEditAnInstrument
    {
        public Instrument instrument { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
