namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomerProduct
    {
        public int CustomerProductId { get; set; }

        public int MpsProductId { get; set; }

        public int CustomerInvoiceId { get; set; }

        public virtual CustomerInvoice CustomerInvoice { get; set; }

        public virtual MpsProduct MpsProduct { get; set; }
    }
}
