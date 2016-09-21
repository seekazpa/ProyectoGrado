using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriVaSe.Models
{
    public class Antropometrico
    {
        [HiddenInput(DisplayValue = true)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public virtual Paciente Paciente { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name="Peso Actual")]
        public double PesoActual { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Talla")]
        public double Talla { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Circunferencia de cintura")]
        public double CircuCintura { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public double CircuCadera { get; set; }
        public double PeriCuello { get; set; }
        public double CircuCarpo { get; set; }
        public double PeriBicep { get; set; }
        public double PliegueTri { get; set; }
        public double PliegueBi { get; set; }
        public double PliegueSupra { get; set; }
        public double PliegueSube { get; set; }

        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "Datetime")]
        public DateTime Fecha { get; set; }
    }
}