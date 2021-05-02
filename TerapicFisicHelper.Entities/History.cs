using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Entities
{
    public class History
    {
        public int CustomerId { get; set; }
        public int SessionId { get; set; }
        public DateTime Watched { get; set; }
        public Customer Customer { get; set; }
        public Session Session { get; set; }
    }
}
