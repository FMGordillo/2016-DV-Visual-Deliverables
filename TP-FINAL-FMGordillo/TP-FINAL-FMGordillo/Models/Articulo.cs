//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP_FINAL_FMGordillo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulo()
        {
            this.FacturaDetalles = new HashSet<FacturaDetalle>();
        }
    
        [Display(Name = "ID Articulo")]
        public int idarticulo { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Detalle")]
        public string detalle { get; set; }
        [Display(Name = "Precio unitario")]
        [Range(1, 1000)]
        public decimal precio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}