namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SrProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SrProduct()
        {
            MpsProducts = new HashSet<MpsProduct>();
        }

        public int SrProductId { get; set; }

        public int SrInvoiceId { get; set; }

        public int RdProductId { get; set; }

        public double SrProductPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MpsProduct> MpsProducts { get; set; }

        public virtual RdProduct RdProduct { get; set; }

        public virtual SrInvoice SrInvoice { get; set; }
    }
}
