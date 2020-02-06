using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models.ViewModels
{
    public class LearningMaterialViewModel
    {
        public LearningMaterial learningMaterial { get; set; }
        public List<SelectListItem> instruments { get; set; }
    }
}
