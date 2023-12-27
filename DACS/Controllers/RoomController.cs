using DACS.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DACS.Common;

namespace DACS.Controllers
{
    public class RoomController : BaseController
    {
        DoAnCoSoEntities db = new DoAnCoSoEntities();

        [HasCredentialAtrribute(RoleCode = "view-add-edit-delete")]
        public ActionResult Index(string currentFilter, string SearchString, int? page, int? Id)
        {
            DoAnCoSoEntities db = new DoAnCoSoEntities();

            var danhsachphong = new List<Room>();


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
                danhsachphong = db.Rooms.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                danhsachphong = db.Rooms.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            danhsachphong = danhsachphong.OrderByDescending(n => n.ID).ToList();
            return View(danhsachphong.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult EquipmentRoom(int ID, int? page)   //hàm danh mục thiết bị
        {
            var listEquipment = db.Equipments.Where(n => n.Location == ID).ToList(); //lấy danh sách thiết bị
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
            //gán giá trị

          
           
            

            //lưu thay đổi

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditRoom(int? ID) {
            Room item = new Room();
            if (ID != null)
            {
                item = db.Rooms.Find(ID);
            }
            
            return View(item);
        }
        [HttpPost] public ActionResult EditRoom(Room model)
        {
            var updateModel = db.Rooms.Find(model.ID);
            updateModel.Name = model.Name;

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int ID)
        {// tìm 
            var updatemodel = db.Rooms.Find(ID);
            //xóa
            db.Rooms.Remove(updatemodel);

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Create()
        {
            Common objCommon = new Common();

          
            var lstRoom = db.Rooms.ToList();

            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            
            DataTable dtRoom = converter.ToDataTable(lstRoom);
            ViewBag.ListRoom = objCommon.ToSelectList(dtRoom, "ID", "Name");
            return View();
        }
        [HttpPost]

        public ActionResult Create(Room objRoom)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    db.Rooms.Add(objRoom);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Room", new { area = "" });
                }

                catch

                {
                    return View();
                }
            }
            return View(objRoom);


        }


    }
}