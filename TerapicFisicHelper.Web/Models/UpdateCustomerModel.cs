using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Web.Models
{
    public class UpdateCustomerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Todo cliente debe tener una descripción")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Descripcion del cliente debe tener entre 3 a 255 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Debe incluir el codigo del usuario")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "El codigo del usuario debe tener de 3 a 5 caracteres")]
        public int UserId { get; set; }

    }
}
