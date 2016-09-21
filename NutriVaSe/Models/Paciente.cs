using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriVaSe.Models
{
    public class Paciente
    {
        public Paciente()
        {
            antropometricos = new List<Antropometrico>();
        }

        [HiddenInput(DisplayValue = true)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Sexo { get; set; }
        public string Ocupacion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string GrupoSanguineo { get; set; }
        public string Alergias { get; set; }

        public virtual ICollection<Antropometrico> antropometricos { get; set; }
    }
}