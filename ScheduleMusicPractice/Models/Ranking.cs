using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models
{
    public class Ranking
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        public LearningMaterial learningMaterial { get; set; }
        public int LearningMaterialId { get; set; }
        public int Rating { get; set; }
    }
}
