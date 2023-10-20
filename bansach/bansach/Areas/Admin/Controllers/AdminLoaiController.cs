using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bansach.Models;

namespace bansach.Areas.Admin.Controllers
{
    public class AdminLoaiController : Controller
    {
        private TiemsachcuaLuanEntities db = new TiemsachcuaLuanEntities();

        // GET: Admin/AdminLoai
        public ActionResult Index()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "3")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View(db.Loais.ToList());
        }
        // GET: Admin/AdminLoai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminLoai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDloai,Tenloai")] Loai loai)
        {
            if (ModelState.IsValid)
            {
                db.Loais.Add(loai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loai);
        }

        // GET: Admin/AdminLoai/Edit/5
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
            Loai loai = db.Loais.Find(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            return View(loai);
        }

        // POST: Admin/AdminLoai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDloai,Tenloai")] Loai loai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loai);
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
