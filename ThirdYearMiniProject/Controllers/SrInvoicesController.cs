using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThirdYearMiniProject.Models;
using PagedList;
using PagedList.Mvc;

namespace ThirdYearMiniProject.Controllers
{
    public class SrInvoicesController : Controller
    {
        MiniProjectDbContext db = new MiniProjectDbContext();


        // GET: SrInvoics
        public ActionResult Index(int? page,int? selected,int? page_two)
        {
            List<RdProduct> modifiedProductsList = new List<RdProduct>();
            SrInvoiceViewModel objViewModel = new SrInvoiceViewModel();
            List<RdProduct> SelectediList = new List<RdProduct>();

            if (Session["modifiedProd"]==null)
            {
                modifiedProductsList = db.RdProducts.OrderByDescending(c => c.RdProductId).ToList<RdProduct>();

            }
            else
            {
                modifiedProductsList = (List<RdProduct>)(Session["modifiedProd"]);
            }
            if (Session["selectedProd"]!=null)
            {
                SelectediList = (List<RdProduct>)(Session["selectedProd"]);
                objViewModel.selectedRdProductList = SelectediList.ToPagedList(page ?? 1,5);
            }
            if (selected != null)
            {
                modifiedProductsList = (List<RdProduct>)(Session["modifiedProd"]);
                objViewModel.rdProducts = db.RdProducts.Find(selected);
                var item = modifiedProductsList.First(x => x.RdProductId == selected);
                modifiedProductsList.Remove(item);
                SelectediList.Add(objViewModel.rdProducts);
                Session["selectedProd"] = SelectediList;

            }
            Session["modifiedProd"] = modifiedProductsList;
            objViewModel.selectedRdProductList = SelectediList.ToPagedList(page_two ?? 1, 5);
            objViewModel.rdProductList = modifiedProductsList.ToPagedList(page ?? 1, 5);

            var srnames = (from t1 in db.Persons
                           join t2 in db.Srs
                           on t1.PersonId equals t2.PersonId
                           select new
                           {
                               t1.PersonName,
                               t2.SrId
                           }).ToList();
            Dictionary<int, string> dictNames = new Dictionary<int, string>();
            dictNames.Add(0, "Select SR");
            foreach (var item in srnames)
            {
                dictNames.Add(item.SrId, item.PersonName);
            }
            ViewBag.SrDropDown = dictNames;

            return View(objViewModel);
        }
        public void AssignToSr(int SrId)
        {
            List<RdProduct> todbSelected = new List<RdProduct>();
            todbSelected=(List<RdProduct>)(Session["selectedProd"]);
            SrInvoice srinvo = new SrInvoice();
            //srinvo.RdId= from t1 in db.RdInvoices where t1.RdInvoiceId==
            //db.RdInvoices.Add();
            foreach (RdProduct product in todbSelected)
            {
               
                SrProduct srprod = new SrProduct();
                srprod.RdProductId = product.RdProductId;
                
               // db.SrProducts.Add(product);
                //db.SaveChanges();
            }
            SrInvoice srInvoice = new SrInvoice();
            //srInvoice.RdId = db.Rd();
            if (ModelState.IsValid)
            {
                
            }
        }

    }
}