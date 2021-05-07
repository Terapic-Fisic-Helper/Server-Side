﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerapicFisicHelper.Web.Models
{
    public class UpdateTagModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre del Tag")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre del Tag debe tener entre 3 a 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe incluir la descripcion del Tag")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Descripcion del Tag debe tener entre 3 a 255 caracteres")]
        public string Description { get; set; }
    }
}
