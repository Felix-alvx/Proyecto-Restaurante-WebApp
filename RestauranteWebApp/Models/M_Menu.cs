using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteWebApp.Models
{
    public class M_Menu
    {
        [Required(ErrorMessage = "El campo de id Menu es requerido")]
        public int id_menu { get; set; }

        [Required(ErrorMessage = "El campo de Precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public Nullable<decimal> Precio { get; set; }

        [Required(ErrorMessage = "El campo de Descripcion es requerido")]
        public string Descripcion { get; set; }
    }
}