﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriVaSe.Models
{
    public class Menu
    {
        [HiddenInput(DisplayValue= true)]
        public int Id { get; set; }
        public virtual int PadreId { get; set; }
        [Required(ErrorMessage= "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; }
        public string Accion { get; set; }
        public string Controlador { get; set; }
        public bool Estado { get; set; }
        public List<Menu> Hijo()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Menus.Where(a => a.PadreId == this.Id).ToList();
        }
    }
}