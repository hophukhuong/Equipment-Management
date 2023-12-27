using DACS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;
using static DACS.Common;

namespace DACS.Controllers
{
    public class StatusController : BaseController
    {
        // GET: Status
        DoAnCoSoEntities db = new DoAnCoSoEntities();
        public ActionResult Index(int? page)
        {
            var lstEquipment = new List<Equipment>();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            lstEquipment = lstEquipment.OrderByDescending(n => n.IDName).ToList();

            return View(lstEquipment.ToPagedList(pageNumber, pageSize));
        }
    }
}