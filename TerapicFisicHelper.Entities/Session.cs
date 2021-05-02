using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Entities
{
    public class Session
    {
        public int SpecialistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public Specialist Specialist { get; set; }
    }
}
