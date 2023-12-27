using DACS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class MissionController : BaseController
    {
        // GET: Mission
        DoAnCoSoEntities db = new DoAnCoSoEntities();

        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        public ActionResult Mission()
        {
            return View();
        }
        public ActionResult getMission()
        {
            var items = db.Missions.ToList().Select(f => new List<string>
            {
                f.ID.ToString(),
                f.Mission1,
                //MissionUser = db.Members.Where(m => m.ID == f.MemberID).ToList(),
                f.MemberId.ToString(),
                f.CreatedDate.ToString(),
                f.DoneDate.ToString(),
                f.Status
            }).ToList();
            return new JsonResult() { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult Edit(int? ID)
        {

            DACS.Context.Mission item = new Context.Mission();
            if (ID != null)
            {
                item = db.Missions.Find(ID);
            }
            return View(item);
        }
        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            int ID = 0;
            int.TryParse(form["ID"], out ID);
            DACS.Context.Mission item;
            if (ID == 0)
            {
                item = new Context.Mission();
                item.ID = db.Missions.Any() ? db.Missions.Max(f => f.ID) + 1 : 1;
                db.Missions.Add(item);
            }
            else
            {
                item = db.Missions.FirstOrDefault(f => f.ID == ID);
            }
            item.Mission1 = form["mission"];
            item.MemberId = int.Parse(form["memberID"]);
            item.CreatedDate = DateTime.Now;
            item.DoneDate = null;
            item.Status = "Chưa hoàn thành";
            if (item.Mission1 != null && item.MemberId != null)
            {
                db.SaveChanges();
                return RedirectToAction("Mission", "Mission");
            }
            return RedirectToAction("ErrorData", "Home");
        }
        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        [HttpGet]
        public ActionResult Remove(int ID)
        {
            var item = db.Missions.Find(ID);
            db.Missions.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Mission", "Mission");
        }
    }
}