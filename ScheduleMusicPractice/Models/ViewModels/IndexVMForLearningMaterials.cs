using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models.ViewModels
{
    public class IndexVMForLearningMaterials
    {
        public LearningMaterial learningmaterial { get; set; }
        public List<Ranking> rankings { get; set; }
        public Ranking ranking { get; set; }
        public double average { get; set; }
    }
}
