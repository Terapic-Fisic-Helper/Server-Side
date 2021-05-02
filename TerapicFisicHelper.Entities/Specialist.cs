using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Entities
{
    public class Specialist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Specialty { get; set; }
        public User User { get; set; }
    }
}
