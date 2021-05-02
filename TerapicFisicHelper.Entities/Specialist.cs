﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Entities
{
    public class Specialist
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe asignar un usuario al especialista")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Debe incluir el especialidad de la sesion")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre de la especialidad debe tener entre 3 a 50 caracteres")]
        public string Specialty { get; set; }
        public User User { get; set; }
        public IList<Session> Sessions { get; set; } = new List<Session>();

        public List<Review> Reviews { get; set; }
    }
}
