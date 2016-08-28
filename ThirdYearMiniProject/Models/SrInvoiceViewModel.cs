using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirdYearMiniProject.Models
{
    public class SrInvoiceViewModel
    {
        public RdProduct rdProducts { get; set; }
        public IPagedList rdProductList { get; set; }
        public IPagedList selectedRdProductList { get; set; }
        public Rd rdNames { get; set; }
    }
}