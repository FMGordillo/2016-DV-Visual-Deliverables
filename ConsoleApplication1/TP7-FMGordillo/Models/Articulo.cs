using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP7_FMGordillo.Models
{
    public class Articulo
    {
        [Key]
        [Display(Name = "Codigo articulo")]
        [Remote("CodigoExiste", "Articulo", HttpMethod = "POST", ErrorMessage = "Ya existe un articulo con ese codigo. Ingrese uno diferente.")]
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
    }

    public class ArticuloDBContext : DbContext
    {
        public DbSet<Articulo> Articulo { get; set; }
    }
}