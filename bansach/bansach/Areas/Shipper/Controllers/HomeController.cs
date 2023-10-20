using bansach.DAO;
using bansach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bansach.Areas.Shipper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Shipper/Shipper
        public ActionResult Index()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "2")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        // GET: Shipper/Shipper
        public ActionResult Nhandon()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "2")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            List<HoadonshipperDTO> lsthd = HoadonDAO.LoadlsttHDnhanviec((int)Session["IDuser"]);
            return View(lsthd);
        }

        public ActionResult Hoanthanhdon(string idbill)
        {

            int IDuser = (int)Session["IDuser"];
            HoadonDAO.Hoanthanhdon(idbill, IDuser);
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

        public ActionResult Bomhang(string idbill)
        {
            int IDuser = (int)Session["IDuser"];
            HoadonDAO.Bomhang(idbill, IDuser);
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
        public ActionResult Donhuy()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "2")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            int IDuser = (int)Session["IDuser"];
            List<HoadonshipperDTO> listhd= HoadonDAO.LoadlsttHDShiperdahuy(IDuser);
            return View(listhd);
        }
        public ActionResult Donhoanthanh()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            if (Session["IDrole"].ToString() != "2")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            int IDuser = (int)Session["IDuser"];
            List<HoadonshipperDTO> listhd = HoadonDAO.LoadlsttHDShiperdagiao(IDuser);
            return View(listhd);
        }
    }
}