using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models
{
    public class PracticeSession
    { public int Id { get; set; }
        public string UserId { get; set; }
        public User user { get; set; }

        public DateTime dateTime { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select An Instrument")]
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select A Method of Practicing")]
        public int PracticeMethodId { get; set; }
        public PracticeMethod PracticeMethod { get; set; }
        
        public bool completed { get; set; }
        public int MinutesPracticed { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int ratethisSession {get;set;}
    }
}
