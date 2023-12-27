using DACS.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class ReportController : BaseController
    {
        public DoAnCoSoEntities db = new DoAnCoSoEntities();
        // GET: Admin/Report
        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        public ActionResult Report1()
        {
            Session["Web"] = 3;
            return View();
        }
        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        public ActionResult getReport1() //In danh sách report chưa xử lý
        {
            var items = (
                from c in db.Reports
                join g in db.Members on c.Member equals g.ID
                where c.Status == "Chưa xử lý"
                select new
                {
                    Id = c.ID,
                    Name = g.Name,
                    Description = c.Description,
                    ReportDate = c.ReportDate.ToString(),
                    Status = c.Status,
                }).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        public ActionResult Done(int? ID) //Xử lý báo cáo
        {
            if (ID != null)
            {
                // Kiểm tra xem report
                var existingCartItem = db.Reports.FirstOrDefault(c => c.Status == "Chưa xử lý" && c.ID == ID.Value);
                // Nếu report tồn tại thì thay đổi status
                if (existingCartItem != null)
                {
                    existingCartItem.Status = "Đã xử lý";
                }
                else
                {
                    return RedirectToAction("Report1", "Report" );
                }
                // Lưu thay đổi vào CSDL
                db.SaveChanges();
                // Sau khi thay đổi status, chuyển hướng về trang Report1
                return RedirectToAction("Report1", "Report");
            }
            // Nếu có lỗi, chuyển hướng về trang lỗi
            return RedirectToAction("Home", "ErrorData");
        }
        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        public ActionResult Report2()
        {
            Session["Web"] = 3;
            return View();
        }
        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        public ActionResult getReport2() //In danh sách report đã xử lý
        {
            var items = (
                from c in db.Reports
                join g in db.Members on c.Member equals g.ID
                where c.Status == "Đã xử lý"
                select new
                {
                    Id = c.ID,
                    Name = g.Name,
                    Description = c.Description,
                    ReportDate = c.ReportDate.ToString(),
                    Status = c.Status,
                }).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveReport(FormCollection form)
        {
            DACS.Context.Report item;
            item = new Context.Report();
            db.Reports.Add(item);
            item.Member = member.ID;
            item.ReportDate = DateTime.Now;
            item.Description = form["description"];
            item.Status = "Chưa xử lý";
            if (item.Description != "")
            {
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("ErrorData", "Home");
        }

    }

}
