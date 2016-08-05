namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MpsInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MpsInvoice()
        {
            MpsProducts = new HashSet<MpsProduct>();
        }

        public int MpsInvoiceId { get; set; }

        public int SrId { get; set; }

        public int MpsId { get; set; }

        [Column(TypeName = "date")]
        public DateTime MpsInvoiceDate { get; set; }

        public double MpsInvoiceTotal { get; set; }

        public virtual Mpss Mpss { get; set; }

        public virtual Sr Sr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MpsProduct> MpsProducts { get; set; }
    }
}
