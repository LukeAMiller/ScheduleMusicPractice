using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models.ViewModels
{
    public class RankingViewModel
    {public LearningMaterial learningMaterial { get; set; }
        public Ranking rank { get; set; }
        public User user { get; set; }
    }
}
