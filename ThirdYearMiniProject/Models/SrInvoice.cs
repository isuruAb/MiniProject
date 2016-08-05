namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SrInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SrInvoice()
        {
            SrProducts = new HashSet<SrProduct>();
        }

        public int SrInvoiceId { get; set; }

        public int RdId { get; set; }

        public int SrId { get; set; }

        [Column(TypeName = "date")]
        public DateTime SrInvoiceDate { get; set; }

        public double SrInvoiceTotal { get; set; }

        public virtual Rd Rd { get; set; }

        public virtual Sr Sr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SrProduct> SrProducts { get; set; }
    }
}
