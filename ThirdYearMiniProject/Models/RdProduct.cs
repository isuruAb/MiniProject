namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RdProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RdProduct()
        {
            SrProducts = new HashSet<SrProduct>();
        }

        public int RdProductId { get; set; }

        public int RdInvoiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmiNo { get; set; }

        [Required]
        [StringLength(50)]
        public string ModelName { get; set; }

        public virtual RdInvoice RdInvoice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SrProduct> SrProducts { get; set; }
    }
}
