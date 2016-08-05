namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomerInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerInvoice()
        {
            CustomerProducts = new HashSet<CustomerProduct>();
        }

        public int CustomerInvoiceId { get; set; }

        public int CustomerId { get; set; }

        public int MpsId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CustomerInvoiceDate { get; set; }

        public double CustomerInvoicePrice { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Mpss Mpss { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; }
    }
}
