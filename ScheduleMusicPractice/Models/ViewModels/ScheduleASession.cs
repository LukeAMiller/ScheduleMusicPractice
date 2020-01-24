using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMusicPractice.Models.ViewModels
{
    public class ScheduleASession
    {
        public PracticeSession practiceSession { get; set; }
        public Instrument instrument { get; set; }
        public  List<SelectListItem> ListOfInstruments { get; set; }
        public DateTime dateTime { get; set; }
        public  List<SelectListItem> ListOfPracticeMethods { get; set; }
        public PracticeMethod method { get; set; }
        public int SelectedInstrumentId { get; set; }
        public int SelectedMethodId { get; set; }
    }
}
