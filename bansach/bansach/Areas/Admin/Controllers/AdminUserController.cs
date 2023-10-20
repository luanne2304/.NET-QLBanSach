using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bansach.DAO;
using bansach.Models;
using Microsoft.AspNet.Identity;

namespace bansach.Areas.Admin.Controllers
{
    public class AdminUserController : Controller
    {
        private TiemsachcuaLuanEntities db = new TiemsachcuaLuanEntities();

        // GET: Admin/AdminUser
        public ActionResult Khachhang()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "3")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View(db.Users.Where(u => u.IDrole == 1).ToList());
        }
        public ActionResult Nhansu()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "3")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View(db.Users.Where(u => u.IDrole != 1).ToList());
        }
        // GET: Admin/AdminUser/Edit/5
        public ActionResult EditKH(int? id)
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
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDrole = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Khachhang" },
                new SelectListItem { Value = "2", Text = "Shipper" },
                new SelectListItem { Value = "3", Text = "Quanly" }
            }, "Value", "Text",user.IDrole);
            return View(user);
        }
        public ActionResult EditNS(int? id)
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
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDrole = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Khachhang" },
                new SelectListItem { Value = "2", Text = "Shipper" },
                new SelectListItem { Value = "3", Text = "Quanly" }
            }, "Value", "Text", user.IDrole);
            return View(user);
        }


        // POST: Admin/AdminUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditKH( string IDuser, string TrangThai,string IDrole)
        {
            AccountDAO.EditUserbyAdmin(int.Parse(IDuser), bool.Parse(TrangThai), int.Parse(IDrole));
            return RedirectToAction("Khachhang");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNS(string IDuser, string TrangThai, string IDrole)
        {
            AccountDAO.EditUserbyAdmin(int.Parse(IDuser), Boolean.Parse(TrangThai), int.Parse(IDrole));
            return RedirectToAction("Nhansu");
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
