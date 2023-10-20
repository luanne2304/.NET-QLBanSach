using bansach.DAO;
using bansach.DTO;
using bansach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace bansach.Controllers
{
    public class CartController : Controller
    {
        private TiemsachcuaLuanEntities db = new TiemsachcuaLuanEntities();
        // GET: Cart
        public ActionResult Index()
        {
            if(Session["IDuser"]==null)
            {
                return RedirectToAction("Login", "Home");
            }
            List<GiohangDTO> loadgh = GiohangDAO.Loadlistgio((int)Session["IDuser"]);
            ViewBag.GH = loadgh;
            return View();
        }
        [HttpPost]
        public ActionResult Index(ThanhtoanHDDTO temp)
        {
            if (!ModelState.IsValid)
            {
                List<GiohangDTO> loadgh = GiohangDAO.Loadlistgio((int)Session["IDuser"]);
                ViewBag.GH = loadgh;
                return View();
            }
            if(!GiohangDAO.Checkgiohang((int)Session["IDuser"]))
            {
                ModelState.AddModelError("Sanpham", "Vui lòng chọn Sản phẩm");
                List<GiohangDTO> loadgh = GiohangDAO.Loadlistgio((int)Session["IDuser"]);
                ViewBag.GH = loadgh;
                return View();
            }    
            if (Session["IDuser"] != null)
            {
                var IDthanhtoan = Request.Form["phuongthucthanhtoan"];
                var Diachi = Request.Form["Diachi"];
                var IDvoucher = Request.Form["magiam"];
                var Ghichu = Request.Form["ghichu"];
                int IDuser = (int)Session["IDuser"];
                if (Ghichu == "")
                    Ghichu = "Không có ghi chú";
                int IDHD=  GiohangDAO.Thanhtoan(IDuser, IDthanhtoan, Diachi, Ghichu, IDvoucher);
                if (IDHD == -555)
                {
                    List<GiohangDTO> loadgh = GiohangDAO.Loadlistgio((int)Session["IDuser"]);
                    ViewBag.GH = loadgh;
                    ModelState.AddModelError("MaGiam", "Voucher không khả dụng!");
                    return View();
                }
                if (IDHD == -999)
                {
                    List<GiohangDTO> loadgh = GiohangDAO.Loadlistgio((int)Session["IDuser"]);
                    ViewBag.GH = loadgh;
                    ModelState.AddModelError("MaGiam", "Voucher đã sử dụng!");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Addtocart(int idsach,int soluong)
        {
            if (Session["IDuser"] != null)
            {
                int IDuser = (int)Session["IDuser"];
                GiohangDAO.Addsanpham(IDuser, idsach, soluong);
                Session["tronggio"] = GiohangDAO.soluongtronggio((int)Session["IDuser"]);
                return Json(new { Message = "Thành công", success = true, Cartcount = Session["tronggio"], JsonRequestBehavior.AllowGet });
            }
            else
            {
                return Json(new { Message = "Thất bại", success = false, JsonRequestBehavior.AllowGet });
            }

        }
        public ActionResult Subtocart(int idsach)
        {
            if (Session["IDuser"] != null)
            {
                int IDuser = (int)Session["IDuser"];
                GiohangDAO.Botsanpham(IDuser, idsach);
            }
            Session["tronggio"] = GiohangDAO.soluongtronggio((int)Session["IDuser"]);
            return Json(new { Message = "Thành công", Cartcount = Session["tronggio"], JsonRequestBehavior.AllowGet });
        }

        public ActionResult Updatetocart(int idsach, int soluong)
        {
            if (Session["IDuser"] != null)
            {
                int IDuser = (int)Session["IDuser"];
                GiohangDAO.Updatesanpham(IDuser, idsach, soluong);
            }
            Session["tronggio"] = GiohangDAO.soluongtronggio((int)Session["IDuser"]);
            return Json(new { Message = "Thành công", Cartcount = Session["tronggio"], JsonRequestBehavior.AllowGet });
        }
        public ActionResult Checkcode(string magiam)
        {
            double chietkhau=  VoucherDAO.Checkvoucher(magiam);
            if (chietkhau == -999)
            {
                return Json(new { Message = "Mã không tồn tại", Chietkhau =0, JsonRequestBehavior.AllowGet });
            }
            else
            {
                return Json(new { Message = "Thành công", Chietkhau = chietkhau, JsonRequestBehavior.AllowGet });
            }
        }
    }
}