using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteWebApp.Models
{
    public class M_Mesa
    {
        [Required(ErrorMessage = "El campo id mesa es requerido")]
        public int id_mesa { get; set; }

        [Required(ErrorMessage = "El campo número de mesa es requerido")]
        [Range(1, 100, ErrorMessage = "El número de mesa debe estar entre 1 y 100")]
        public int Numero_Mesa { get; set; }

        [Required(ErrorMessage = "El campo descripción es requerido")]
        public string Descripcion { get; set; }
    }
}