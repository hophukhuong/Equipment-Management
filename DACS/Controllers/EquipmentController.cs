using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACS.Context;
using PagedList;
using static DACS.Common;


namespace DACS.Controllers
{
    public class EquipmentController : BaseController
    {
        DoAnCoSoEntities db = new DoAnCoSoEntities();
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstEquipment = new List<Equipment>();
            var lstRoom = new List<Room>();

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
                lstEquipment = db.Equipments.Where(n => n.Name.Contains(SearchString) || n.IDName.Contains(SearchString)).ToList();
            }
            else
            {
                lstEquipment = db.Equipments.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            lstEquipment = lstEquipment.OrderByDescending(n => n.IDName).ToList();



            return View(lstEquipment.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            Common objCommon = new Common();

            var lstCat = db.Categories.ToList();
            var categoryList = lstCat.Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Name });
            var lstRoom = db.Rooms.ToList();

            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            DataTable dtRoom = converter.ToDataTable(lstRoom);

            // Truyền dữ liệu trực tiếp từ action xuống view
            ViewData["ListCategory"] = objCommon.ToSelectList(dtCategory, "ID", "Name");
            ViewData["ListRoom"] = objCommon.ToSelectList(dtRoom, "ID", "Name");

            var Name = new SelectList(db.Categories.ToList(), "ID", "Name");
            ViewData["Name"] = Name;

            var Location = new SelectList(db.Rooms.ToList(), "ID", "Name");
            ViewData["Location"] = Location;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Equipment objEquipment, string IDName)
        {
            if (!string.IsNullOrEmpty(IDName))
            {
                // Kiểm tra xem IDName đã tồn tại trong cơ sở dữ liệu hay chưa
                Equipment existingEquipment = db.Equipments.FirstOrDefault(e => e.IDName == IDName);

                if (existingEquipment != null)
                {
                    // Nếu IDName đã tồn tại, cập nhật thông tin của thiết bị có sẵn hoặc xử lý theo ý định của bạn
                    existingEquipment.IDName = objEquipment.IDName;
                    // Cập nhật các trường khác tùy thuộc vào ý định của bạn
                }
                else
                {
                    try
                    {
                        // Nếu IDName chưa tồn tại, thêm mới thiết bị
                        HttpPostedFileBase Avatar = Request.Files[0];
                        if (Avatar != null && Avatar.ContentLength > 0)
                        {
                            objEquipment.Avatar = Avatar.FileName;
                            Avatar.SaveAs(Server.MapPath("/Content/images/items/" + Avatar.FileName));
                        }
                        objEquipment.IDName = IDName;
                        db.Equipments.Add(objEquipment);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Equipment", new { area = "" });
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", "An error occurred while saving the equipment."); 
                        return View(objEquipment);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("IDName", "IDName is required.");
            }

            // Invalid ModelState, return to the create view with the provided data
            return View(objEquipment);
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
        public ActionResult Delete(int ID)
        {// tìm 
            var updatemodel = db.Equipments.Find(ID);
            //xóa
            db.Equipments.Remove(updatemodel);

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public void TrangThai(int id)
        {
            // Retrieve the equipment item with the specified ID from the database
            var equipment = (from d in db.Equipments where d.ID == id select d).SingleOrDefault();

            // Initialize a variable to store the image path
            string _Hinh = "";

            // Toggle the status and set the image path accordingly
            if (equipment.Status == true)
            {
                equipment.Status = false;
                _Hinh = "/Content/images/Icons/icon_An.png";
            }
            else
            {
                equipment.Status = true;
                _Hinh = "/Content/images/Icons/icon_Hien.png";
            }

            // Update the model with the modified equipment status
            UpdateModel(equipment);

            // Save changes to the database
            db.SaveChanges();

            // Write the image path as a response
            Response.Write(_Hinh);
        }

     

    }
}