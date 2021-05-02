using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Entities
{
    public class History
    {
        [Required(ErrorMessage = "Debe asignar un cliente al historial")]
        public int CustomerId { get; set; }
        
        [Required(ErrorMessage = "Debe asignar una sesion al historial")]
        public int SessionId { get; set; }
        
        [Required]
        public DateTime Watched { get; set; }
        public Customer Customer { get; set; }
        public Session Session { get; set; }
    }
}
