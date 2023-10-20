using bansach.DAO;
using bansach.DTO;
using bansach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Web.WebPages;
using static System.Net.Mime.MediaTypeNames;

namespace bansach.Areas.Admin.Controllers
{
    public class AdminXacnhandonController : Controller
    {
        private TiemsachcuaLuanEntities db = new TiemsachcuaLuanEntities();
        // GET: Admin/AdminXacnhandon
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
            if (Session["StatusMessage"] != null)
            {
                ViewBag.StatusMessage = Session["StatusMessage"].ToString();
                Session.Remove("StatusMessage");
            };
            return View(HoadonDAO.LoadlstHDchuaxuly());
        }
        public ActionResult CheckIndex(string idhd,string status)
        {
            
            if (status == "Xacnhan") 
            {
                if (HoadonDAO.Xacnhandonauto(int.Parse(idhd)))
                {
                    Session["StatusMessage"] = "xacnhanthanhcong";
                }
                else
                {
                    Session["StatusMessage"] = "xacnhanthatbai";
                }
            }
                
            else
            {
                HoadonDAO.Khongxacnhan(idhd);
                Session["StatusMessage"] = "huydon";
            }
            return RedirectToAction("Index");
        }
        // GET: Admin/AdminHoadon/Check/5
        public ActionResult Check(int? id)
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
            var tenkho = ChitietkhoDAO.Loadlistkho();
            ViewBag.lstkho = tenkho;
            if (Session["StatusMessage"] != null)
            {
                ViewBag.StatusMessage = Session["StatusMessage"].ToString();
                Session.Remove("StatusMessage");
            }
            return View(listchitietHD);
        }

        // POST: Admin/AdminHoadon/Check/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Check(string IDhoadon, string IDtinhtrang)
        {
            List<ChitietHDDTO> listchitietHD = ChitietHDDAO.LoadchitietHD(int.Parse(IDhoadon));
            var tenkho = ChitietkhoDAO.Loadlistkho();
            ViewBag.lstkho = tenkho;
            if (ModelState.IsValid)
            {
                if(IDtinhtrang== "2")
                {
                    HoadonDAO.Khongxacnhan(IDhoadon);
                    return RedirectToAction("Index");
                }

                var checkngaygiao = Request.Form["Ngaydukiengiao"];
                if (checkngaygiao == "")
                {
                    if (HoadonDAO.Xacnhandonauto(int.Parse(IDhoadon)))
                    {
                        Session["StatusMessage"] = "xacnhanthanhcong";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.StatusMessage = "thatbai";
                        return View(listchitietHD);
                    }

                }
                else
                {
                    if (HoadonDAO.Xacnhandon(int.Parse(IDhoadon), DateTime.Parse(checkngaygiao)))
                    {
                        Session["StatusMessage"] = "xacnhanthanhcong";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.StatusMessage = "thatbai";
                        return View(listchitietHD);
                    }

                }
            }



            return View(listchitietHD);
        }

    }
}