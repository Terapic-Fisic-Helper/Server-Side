using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Entities
{
    public class Session
    {
<<<<<<< Updated upstream
=======
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe asignar un especialista a la sesion")]
>>>>>>> Stashed changes
        public int SpecialistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public Specialist Specialist { get; set; }
        public List<History> Histories { get; set; }
        public List<EquipamentSession> EquipamentSessions { get; set; }
        public List<TagSession> TagSessions { get; set; }
    }
}
