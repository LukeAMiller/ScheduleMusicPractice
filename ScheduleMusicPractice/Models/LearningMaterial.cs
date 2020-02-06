using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models
{
    public class LearningMaterial
    {
        public int id { get; set; }
        //telling C# that this is a URL
        [DataType(DataType.Url)]
        [UIHint("OpenInNewWindow")]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select An Instrument")]
        public int InstrumentId { get; set; }
        public Instrument instrument { get; set; }
        public List<Ranking> rankings { get; set; }
 
      
        public double Sum()
        {
            double answer = rankings.Average(l => l.Rating);
            return answer;
        }
    }
}
