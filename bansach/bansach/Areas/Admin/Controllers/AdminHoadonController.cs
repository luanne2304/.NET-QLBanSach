using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bansach.DAO;
using PagedList.Mvc;
using PagedList;
using bansach.DTO;
using bansach.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI;

namespace bansach.Areas.Admin.Controllers
{
    public class AdminHoadonController : Controller
    {
        private TiemsachcuaLuanEntities db = new TiemsachcuaLuanEntities();

        // GET: Admin/AdminHoadon
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
            int pageitem = 15;
            int pageNum = (page ?? 1);
            return View(HoadonDAO.LoadlsttHD().ToPagedList(pageNum, pageitem));
        }

        // GET: Admin/AdminHoadon/Edit/5
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
            List<ChitietHDDTO> listchitietHD = ChitietHDDAO.LoadchitietHD(id);
            if (listchitietHD == null)
            {
                return HttpNotFound();
            }
            return View(listchitietHD);
        }

        // POST: Admin/AdminHoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            var IDhoadon = Request.Form["IDhoadon"];
            if (ModelState.IsValid)
            {
                var IDtinhtrang = Request.Form["IDtinhtrang"];
                var Ngaydukiengiao = Request.Form["Ngaydukiengiao"];
                HoadonDAO.UpdateHD(IDhoadon, IDtinhtrang, DateTime.Parse(Ngaydukiengiao));
                return RedirectToAction("Index");
            }
            return View(int.Parse(IDhoadon));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Admin/AdminHoadon/Check/5
        public ActionResult Phancong(int? page)
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "3")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            int pageitem = 15;
            int pageNum = (page ?? 1);
            ViewBag.shipper = new SelectList(ShipperDAO.Loadshipperhoatdong(), "IDuser", "Hoten");
            List<HoadonPhanviecDTO> listHD = HoadonDAO.LoadlsttHDphanviec();
            return View(listHD.ToPagedList(pageNum, pageitem));
        }

        [HttpPost]
        public ActionResult Phancong(List<string> selectedIds, string idshipper)
        {
            if (idshipper == "")
            {
                return Json(new { check=0, JsonRequestBehavior.DenyGet });
            }
            if(selectedIds != null)
            {
                foreach (string idbill in selectedIds)
                {
                    HoadonDAO.Phanviecshipper(idshipper, idbill);

                }
            }
            return Json(new { check = 1,JsonRequestBehavior.AllowGet });
        }
    }
}
