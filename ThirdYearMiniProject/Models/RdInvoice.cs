namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RdInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RdInvoice()
        {
            RdProducts = new HashSet<RdProduct>();
        }

        public int RdInvoiceId { get; set; }

        public int RdId { get; set; }

        public int LocationId { get; set; }

        [Column(TypeName = "date")]
        public DateTime RdInvoiceDate { get; set; }

        public double RdInvoiceTotal { get; set; }

        public virtual Location Location { get; set; }

        public virtual Rd Rd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RdProduct> RdProducts { get; set; }
    }
}
