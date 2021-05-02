using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Entities
{
    public class TagSession
    {
        public int TagId { get; set; }
        public int SessionId { get; set; }
        public Tag Tag { get; set; }
        public Session Session { get; set; }
    }
}
