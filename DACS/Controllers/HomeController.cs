using DACS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        DoAnCoSoEntities db = new DoAnCoSoEntities();
        public ActionResult Index()
        {
            return View("Index");
        }


        public ActionResult Register()
        {

            return View();

        }
        public ActionResult NotCredential()
        {
            return View();
        }
        public int getEquipment()
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();
            return db.Equipments.Count();

        }


        public ActionResult getReportCount()
        {
            int count = db.Reports.Count(report => report.Status == "Chưa xử lý");
            return Content(count.ToString());
        }

        public int getMissions()
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();
            return db.Missions.Count();

        }

        public int getRooms()
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();
            return db.Rooms.Count();

        }
        public int getMember()
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();
            return db.Members.Count();

        }
        public int getCategory()
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();
            return db.Categories.Count();

        }


        public ActionResult getMission()
        {
            var memberId = member.ID;
            var items = db.Missions.Where(f => f.MemberId == member.ID).ToList().Select(f => new List<string>
            {
                f.ID.ToString(),
                f.Mission1,
                f.CreatedDate.ToString(),
                f.DoneDate.ToString(),
                f.Status
            }).ToList();
            return new JsonResult() { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //Thao tác xác nhận đã hoàn thành nhiệm vụ
        public ActionResult Done(int? Id)
        {
            DACS.Context.Mission item = new Context.Mission();
            if (Id != null)
            {
                item = db.Missions.Find(Id);
                item.Status = "Đã hoàn thành";
                item.DoneDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}