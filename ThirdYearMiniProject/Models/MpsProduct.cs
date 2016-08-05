namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MpsProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MpsProduct()
        {
            CustomerProducts = new HashSet<CustomerProduct>();
        }

        public int MpsProductId { get; set; }

        public int MpsInvoiceId { get; set; }

        public int SrProductId { get; set; }

        public double MpsProductPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; }

        public virtual MpsInvoice MpsInvoice { get; set; }

        public virtual SrProduct SrProduct { get; set; }
    }
}
