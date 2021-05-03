using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Web.Models
{
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "Debe incluir el email del usuario")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email del usuario debe tener entre 3 a 100 caracteres")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Debe incluir el password del usuario")]
        [StringLength(8, ErrorMessage = "Password del usuario debe tener al menos 8 caracteres")]
        public string Password { get; set; }
    }
}
