using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models
{
    public class RankingLevel
    {
        public int Id { get; set;}
        public Ranking ranking { get; set; }
        public int RankingId { get; set; }
        public Level Level { get; set; }
        public int LevelId { get; set; }
    }
}
