using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models
{
    public class LearningMaterial
    {
        public int id { get; set; }
        [DataType(DataType.Url)]
        [UIHint("OpenInNewWindow")]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select An Instrument")]
        public int InstrumentId { get; set; }
        public Instrument instrument { get; set; }
        public List<Ranking> rankings { get; set; }
    }
}
