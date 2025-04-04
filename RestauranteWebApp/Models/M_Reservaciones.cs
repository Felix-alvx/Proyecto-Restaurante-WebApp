using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteWebApp.Models
{
    public class M_Reservaciones
    {
        [Required(ErrorMessage = "El campo id Reservacion es requerido")]
        public int id_reservacion { get; set; }

        [Required(ErrorMessage = "El campo id cliente es requerido")]
        public Nullable<int> ID_cliente { get; set; }

        [Required(ErrorMessage = "El campo id mesa es requerido")]
        public Nullable<int> ID_mesa { get; set; }

        [Required(ErrorMessage = "El campo id menu es requerido")]
        public Nullable<int> ID_menu { get; set; }

        [Required(ErrorMessage = "El campo cantidad es requerido")]
        [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100")]
        public Nullable<int> Cantidad { get; set; }

        [Required(ErrorMessage = "El campo de fecha es requerido")]
        [DataType(DataType.DateTime, ErrorMessage = "Debe ingresar una fecha válida")]
        public Nullable<System.DateTime> Fecha_reservacion { get; set; }
    }
}