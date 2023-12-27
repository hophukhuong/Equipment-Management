using DACS.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DACS.Controllers
{
    public class CategoryController : BaseController
    {

        DoAnCoSoEntities db = new DoAnCoSoEntities();
        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();

            var danhsachloaithietbi = new List<Category>();


            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                danhsachloaithietbi = db.Categories.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                danhsachloaithietbi = db.Categories.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            danhsachloaithietbi = danhsachloaithietbi.OrderByDescending(n => n.ID).ToList();
            return View(danhsachloaithietbi.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EquipmentCategory(int ID, int? page)   //hàm danh mục thiết bị
        {
            var listEquipment = db.Equipments.Where(n => n.CategoryID == ID).ToList();
            
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //lấy danh sách thiết bị
            return View(listEquipment.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Edit(int? ID)
        {
            Equipment item = new Equipment();
            if (ID != null)
            {
                item = db.Equipments.Find(ID);
            }
            var CategoryID = new SelectList(db.Categories.ToList(), "ID", "Name"); // lấy list category để làm dropdownlist cho category phần tạo mới
            ViewBag.CategoryID = CategoryID;
            var Location = new SelectList(db.Rooms.ToList(), "ID", "Name");
            ViewBag.Location = Location;
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Equipment model)
        {
            //tìm đối tượng
            var updateModel = db.Equipments.Find(model.ID);
            //gán giá trị
            updateModel.IDName = model.IDName;
            updateModel.Name = model.Name;
            updateModel.Avatar = model.Avatar;
            updateModel.Status = model.Status;
            updateModel.CategoryID = model.CategoryID;
            updateModel.Price = model.Price;
            updateModel.CreatedOnUtc = model.CreatedOnUtc;
            updateModel.UpdatedOnUtc = model.UpdatedOnUtc;
            updateModel.Location = model.Location;
            updateModel.Amount = model.Amount;
            HttpPostedFileBase Avatar = Request.Files[0];
            if (Avatar != null && Avatar.ContentLength > 0)
            {
                updateModel.Avatar = Avatar.FileName;
                Avatar.SaveAs(Server.MapPath("/Content/images/items/" + Avatar.FileName));
            }

            //lưu thay đổi

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int? ID)
        {
            Category item = new Category();
            if (ID != null)
            {
                item = db.Categories.Find(ID);
            }

            return View(item);
        }
        [HttpPost]
        public ActionResult EditCategory(Category model)
        {
            var updateModel = db.Categories.Find(model.ID);
            updateModel.Name = model.Name;

            db.SaveChanges();
            return RedirectToAction("Index");
        }







        public ActionResult Delete(int ID)
        {// tìm 
            var updatemodel = db.Categories.Find(ID);
            //xóa
            db.Categories.Remove(updatemodel);

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Create(Category objCategory)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    db.Categories.Add(objCategory);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Category", new { area = "" });
                }

                catch

                {
                    return View();
                }
            }
            return View(objCategory);


        }


    }
}