using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP7_FMGordillo.Models
{
    public class Factura
    {
        [Key]
        [Display(Name = "Codigo factura")]
        [Remote("FacturaExiste", "Factura", HttpMethod = "POST", ErrorMessage = "Ya existe una factura con ese codigo. Ingrese uno diferente.")]
        public int FacturaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
    }

    public class FacturaDBContext : DbContext
    {
        public DbSet<Factura> Factura { get; set; }
    }
}