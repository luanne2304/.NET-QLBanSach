using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bansach.DAO;
using bansach.DTO;
using bansach.Models;
using PagedList.Mvc;
using PagedList;

namespace bansach.Areas.Admin.Controllers
{
    public class AdminKhoController : Controller
    {
        private TiemsachcuaLuanEntities db = new TiemsachcuaLuanEntities();

        // GET: Admin/AdminKho
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
            return View(db.Khoes.ToList());
        }

        // GET: Admin/AdminKho/Details/5
        public ActionResult Details(int? id, int? page)
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
            Kho kho = db.Khoes.Find(id);
            if (kho == null)
            {
                return HttpNotFound();
            }
            if (Session["StatusMessage"] != null)
            {
                ViewBag.StatusMessage = Session["StatusMessage"].ToString();
                Session.Remove("StatusMessage");
            }
            ViewBag.khoden = new SelectList(ChitietkhoDAO.Loadlistkhochuyen(kho.IDkho),"IDkho","Tenkho");
            ViewBag.thongtinkho = db.Khoes.Find(id);
            int pageitem = 10;
            int pageNum = (page ?? 1);
            List<ChitietkhoDTO> listchitietkho = ChitietkhoDAO.Loadchitietkhobyid(id);
            return View(listchitietkho.ToPagedList(pageNum, pageitem));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string khodi = form["submit"];
                string soluong = form["md_soluongcanchuyen"];
                string khoden = form["khoden"];
                string idsach = form["md_idsach"];
                if(ChitietkhoDAO.Chuyenkho(khodi, khoden, idsach, soluong))
                {
                    Session["StatusMessage"] = "thanhcong";
                }
                else
                {
                    Session["StatusMessage"] = "thatbai";
                }
                if (Request.UrlReferrer != null)
                {
                    return Redirect(Request.UrlReferrer.AbsoluteUri);
                }
                else
                    return RedirectToAction("Index", "AdminKho","Admin");
            }
            return View();
        }
        // GET: Admin/AdminKho/Create
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
            return View();
        }

        // POST: Admin/AdminKho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDkho,Tenkho,Diachikho,Trangthai,Trungtam")] Kho kho)
        {
            if (ModelState.IsValid)
            {
                db.Khoes.Add(kho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kho);
        }

        // GET: Admin/AdminKho/Edit/5
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
            Kho kho = db.Khoes.Find(id);
            if (kho == null)
            {
                return HttpNotFound();
            }
            return View(kho);
        }

        // POST: Admin/AdminKho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDkho,Tenkho,Diachikho,Trangthai,Trungtam")] Kho kho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kho);
        }

        // GET: Admin/AdminKho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kho kho = db.Khoes.Find(id);
            if (kho == null)
            {
                return HttpNotFound();
            }
            return View(kho);
        }

        // POST: Admin/AdminKho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kho kho = db.Khoes.Find(id);
            db.Khoes.Remove(kho);
            db.SaveChanges();
            return RedirectToAction("Index");
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
