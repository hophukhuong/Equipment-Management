using DACS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class ChartController : BaseController
    {
        // GET: Admin/Chart
        DoAnCoSoEntities db = new DoAnCoSoEntities();
        public ActionResult Index()
        {
            int data1 = db.Equipments.Where(p => p.CategoryID == 1).Count();
            int data2 = db.Equipments.Where(p => p.CategoryID == 2).Count();
            int data3 = db.Equipments.Where(p => p.CategoryID == 3).Count();
            int data4 = db.Equipments.Where(p => p.CategoryID == 4).Count();
            int data5 = db.Equipments.Where(p => p.CategoryID == 5).Count();
            
            TempData["data1"] = data1;
            TempData["data2"] = data2;
            TempData["data3"] = data3;
            TempData["data4"] = data4;
            TempData["data5"] = data5;
            return View();
        }
    }
}