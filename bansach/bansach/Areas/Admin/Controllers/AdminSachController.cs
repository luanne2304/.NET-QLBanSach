using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bansach.DAO;
using bansach.DTO;
using bansach.Models;
using PagedList.Mvc;
using PagedList;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI;

namespace bansach.Areas.Admin.Controllers
{
    public class AdminSachController : Controller
    {
        private TiemsachcuaLuanEntities db = new TiemsachcuaLuanEntities();
        // GET: Admin/AdminSach
        public ActionResult Index(int? page)
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "3")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            int pageitem = 10;
            int pageNum = (page ?? 1);
            ViewBag.kho = new SelectList(ChitietkhoDAO.LoadlistkhoHoatdong(), "IDkho", "Tenkho");
            return View(db.Saches.ToList().ToPagedList(pageNum, pageitem));
        }
        // GET: Admin/AdminSach/Create
        public ActionResult Create()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "3")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            ViewBag.Theloai = db.Loais;
            return View();
        }

        // POST: Admin/AdminSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDsach,Tensach,Tacgia,Mota,Gia,Hinhanh,Trangthai")] Sach sach, HttpPostedFileBase hinhanh)
        {
            if (!ModelState.IsValid)
            {
                if(hinhanh== null)
                {
                    ModelState.AddModelError("Hinhanh", "Vui lòng chọn ảnh");
                }
                ViewBag.Theloai = db.Loais;
                return View();
            }
            else
            {
                if (hinhanh == null)
                {
                    ModelState.AddModelError("Hinhanh", "Vui lòng chọn ảnh");
                    ViewBag.Theloai = db.Loais;
                    return View();
                }
                else
                {
                string[] a = hinhanh.FileName.Split('.');
                string tempnameimg = a[0] +"."+ Guid.NewGuid().ToString("N") + ".png";
                string path = Path.Combine(Server.MapPath("~/Content/AnhSP"),tempnameimg);
                hinhanh.SaveAs(path);
                SachDAO.Addsach(sach,tempnameimg);
                int temp = db.Saches.OrderByDescending(o => o.IDsach).FirstOrDefault().IDsach;
                    foreach (var i in db.Loais)
                    {
                        int test = i.IDloai;
                        var check = Request.Form[test.ToString()];
                        if (check == "true,false")
                        {
                            ChitietSachDAO.Addchitietsach(temp, i.IDloai);
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Admin/AdminSach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "3")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Chitietsach> chitietsach = ChitietSachDAO.Loadchitietsach(id);
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.Theloaicheck = chitietsach;
            ViewBag.Theloai = db.Loais;
            return View(sach);
        }

        // POST: Admin/AdminSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDsach,Tensach,Tacgia,Mota,Gia,Hinhanh,Trangthai")] Sach sach, HttpPostedFileBase hinhanh)
        {
            if (ModelState.IsValid)
            {
                if (hinhanh== null)
                {
                    string tempnameimg = Request.Form["tempimg"];
                    SachDAO.EditSach(sach, tempnameimg);
                    foreach (var i in db.Loais)
                    {
                        int test = i.IDloai;
                        var check = Request.Form[test.ToString()];
                        if (check == "true,false")
                        {
                            ChitietSachDAO.Addchitietsach(sach.IDsach, i.IDloai);
                        }
                        else
                        {
                            ChitietSachDAO.Deletechitietsach(sach.IDsach, i.IDloai);
                        }
                    }                   
                }
                else
                {
                    string[] a = hinhanh.FileName.Split('.');
                    string tempnameimg = a[0] + "." + Guid.NewGuid().ToString("N") + ".png";
                    string path = Path.Combine(Server.MapPath("~/Content/AnhSP"), tempnameimg);
                    hinhanh.SaveAs(path);
                    SachDAO.EditSach(sach, tempnameimg);
                    foreach (var i in db.Loais)
                    {
                        int test = i.IDloai;
                        var check = Request.Form[test.ToString()];
                        if (check == "true,false")
                        {
                            ChitietSachDAO.Addchitietsach(sach.IDsach, i.IDloai);
                        }
                        else
                        {
                            ChitietSachDAO.Deletechitietsach(sach.IDsach, i.IDloai);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            List<Chitietsach> chitietsach = ChitietSachDAO.Loadchitietsach(sach.IDsach);
            ViewBag.Theloaicheck = chitietsach;
            ViewBag.Theloai = db.Loais;
            return View(sach);
        }

        public ActionResult Nhaphang(string IDkho, string IDsach,string Soluong)
        {
            bool temp =ChitietkhoDAO.Nhaphang(IDkho, IDsach, Soluong);   
            if (temp)
            {
                return Json(new { Message = "Thành công", Check = 1, JsonRequestBehavior.AllowGet });
            }
            else
            {
                return Json(new { Message = "Thất bại", Check = 0, JsonRequestBehavior.AllowGet });
            }

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
