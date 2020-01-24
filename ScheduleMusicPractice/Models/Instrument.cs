using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LearningMaterials { get; set; }
        public string Description { get; set; }
        [Display(Name = "Image")]
        public byte[] ProductImage { get; set; }

    }
}
