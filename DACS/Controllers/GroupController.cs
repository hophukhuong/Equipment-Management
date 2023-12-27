using DACS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class GroupController : BaseController
    {
        // GET: Admin/Group
        public ActionResult Index()
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();

            List<Group> danhsachgroup = db.Groups.ToList();
            return View(danhsachgroup);
        }


        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Group model)
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();
            var check = db.Groups.FirstOrDefault(s => s.Name == model.Name);
            if (check == null)
            {


                db.Groups.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "tựa đề đã tồn tại");
                return View();
            }


        }

        public ActionResult Edit(int ID)
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();
            Group Group = db.Groups.Find(ID);
            return View(Group);
        }
        [HttpPost]
        public ActionResult Edit(Group model)
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();

            var updateModel = db.Groups.Find(model.ID);

            updateModel.ID = model.ID;
            updateModel.Name = model.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();

            var updateModel = db.Groups.Find(ID);
            db.Groups.Remove(updateModel);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}