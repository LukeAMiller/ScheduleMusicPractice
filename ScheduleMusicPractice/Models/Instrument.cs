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
        public bool DisplayLink(string url)
        {
            if ((url != null) && (url.Length > 0))
                return true;

            return false;
        }
        [DataType(DataType.Url)]
        [UIHint("OpenInNewWindow")]
        public string LearningMaterials { get; set; }
        public string Description { get; set; }
      
        [Display(Name = "Image")]
        public byte[] ProductImage { get; set; }
    }
}
