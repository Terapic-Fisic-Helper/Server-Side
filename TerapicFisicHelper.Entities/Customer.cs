using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
