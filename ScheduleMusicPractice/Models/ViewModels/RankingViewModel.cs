using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models.ViewModels
{
    public class RankingViewModel
    { public LearningMaterial learningMaterial { get; set; }
        public Ranking rank { get; set; }
        public Level level { get; set; }
        public List<SelectListItem> Levels { get; set; }
        public List<int> SelectedLevelId { get; set; }
        public User user { get; set; }
        public RankingLevel rankingLevel { get; set; }
        public int BeginnerCount { get; set; }
        public int IntermediateCount { get; set; }
        public int AdvancedCount {get;set;}
        public int ProCount { get; set; }
    }
}
