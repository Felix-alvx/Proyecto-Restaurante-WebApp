using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteWebApp.Models
{
    public class M_Cliente
    {
        [Required(ErrorMessage = "El campo id_Cliente es requerido")]
        [Display(Name = "ID del Cliente")]
        public int id_Cliente { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MinLength(5, ErrorMessage = "El nombre debe contener al menos 5 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido")]
        [MinLength(5, ErrorMessage = "Error, el apellido debe contener al menos 5 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        [MaxLength(8, ErrorMessage = "Error, el telefono debe contener al menos 8 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [MaxLength(50, ErrorMessage = "El correo no puede superar los 50 caracteres")]
        public string Correo_Electronico { get; set; }
    }
}