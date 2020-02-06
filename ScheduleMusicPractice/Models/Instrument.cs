using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace ScheduleMusicPractice.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
      //byte array for image file
        [Display(Name = "Image")]
        public byte[] ProductImage { get; set; }
    }
}
