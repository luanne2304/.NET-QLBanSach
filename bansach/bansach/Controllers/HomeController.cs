using bansach.DAO;
using bansach.DTO;
using bansach.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace bansach.Controllers
{
    public class HomeController : Controller
    {

        private TiemsachcuaLuanEntities db = new TiemsachcuaLuanEntities();
        public ActionResult Index(int ? page)
        {
            if (Session["IDuser"] == null)
            {
                Session["tronggio"] = 0;
            }
            else
            {
                Session["tronggio"] = GiohangDAO.soluongtronggio((int)Session["IDuser"]);
            }
            ViewBag.loai = db.Loais.ToList();
            int pageitem = 12;
            int pageNum = (page ?? 1);
            return View(SachDAO.Loadlstsachhoatdong().ToPagedList(pageNum,pageitem));
        }
        public ActionResult test(int? page)
        {
            if (Session["IDuser"] == null)
            {
                Session["tronggio"] = 0;
            }
            else
            {
                Session["tronggio"] = GiohangDAO.soluongtronggio((int)Session["IDuser"]);
            }
            ViewBag.loai = db.Loais.ToList();
            int pageitem = 12;
            int pageNum = (page ?? 1);
            return View(SachDAO.Loadlstsachhoatdong().ToPagedList(pageNum, pageitem));
        }
        public ActionResult ListProduct(string cate,string name, int? page)
        {
            if (Session["IDuser"] == null)
            {
                Session["tronggio"] = 0;
            }
            else
            {
                Session["tronggio"] = GiohangDAO.soluongtronggio((int)Session["IDuser"]);
            }
            ViewBag.loai = db.Loais.ToList();
            int pageitem = 12;
            int pageNum = (page ?? 1);
            return View(SachDAO.LoadlstsachhoatdongbyCatevName(cate,name).ToPagedList(pageNum, pageitem));
        }
        public ActionResult Voucher()
        {
            return View(VoucherDAO.Loadvoucherhoatdong());
        }
        public ActionResult Login()
        {
            if (Session["IDuser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["StatusMessage"] != null)
            {
                ViewBag.StatusMessage = Session["StatusMessage"].ToString();
                Session.Remove("StatusMessage");
            };
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccLoginDTO temp, string Tk, string Mk)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string md5 = Utils.Utils.HashPassword(Mk);
            User user = AccountDAO.Login(Tk, md5);
            if (user == null)
            {
                ModelState.AddModelError("Mk", "Tài khoản hoặc mất khẩu không chính xác!");
                return View();
            }
            if (user.Active == false)
            {
                ModelState.AddModelError("Mk", "Vui lòng kích hoạt tài khoản!");
                return View();
            }

            Session["IDuser"] = user.IDuser;
            Session["Hoten"] = user.HoTen;
            Session["IDrole"] = user.IDrole;
            Session["Mail"] = user.Mail;
            return new RedirectResult("/Home/Index");
        }

        public ActionResult Register()
        {
            if (Session["IDuser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(AccRegisterDTO acc )
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string md5 = Utils.Utils.HashPassword(acc.Mk);
            string token =  Utils.Utils.GenerateActivationToken();
            if(AccountDAO.TaoAcc(acc.Tk, md5, acc.HoTen, acc.Mail, acc.Sdt, token))
            {

                //var callbackUrl = Url.Action("ConfirmEmail", "Home", new { userId = acc.Tk, code = token }, protocol: Request.Url.Scheme);
                //string body = "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>";
                //Utils.Utils.Sendmail(acc.Mail, "Confirm your account", body);
                Session["StatusMessage"] = "Taotkthanhcong";
                return new RedirectResult("/Home/Login");
            }
            else
            {
                ModelState.AddModelError("Tk", "Tài khoản đã tồn tại!");
                return View();
            }
        }

        public ActionResult ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            if(AccountDAO.Xacnhanmail(userId, code))
            {
                return View();
            }
            else
            {
                return View("Error");
            }
        }


        public ActionResult Forgetpass()
        {
            if (Session["IDuser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Profile()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            User user = db.Users.Find(Session["IDuser"]);
            return View(user);
        }
        [HttpPost]
        public ActionResult Profile(string Hoten, string Mail, string Sdt)
        {
            AccountDAO.Editprofile(Session["IDuser"].ToString(), Hoten, Mail, Sdt);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Changepass()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Changepass(ChangePassDTO temp,string Mkcu, string Mk)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Mkcu = Utils.Utils.HashPassword(Mkcu);
            Mk = Utils.Utils.HashPassword(Mk);
            bool a = AccountDAO.Changepass(Session["IDuser"].ToString(), Mkcu, Mk);
            if (a)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Hoadon()
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            List<HoadonproDTO> lsthd = HoadonDAO.LoadHDbyiduser(Session["IDuser"].ToString());
            return View(lsthd);
        }
        public ActionResult ChitietHoadon(string IDhoadon)
        {
            if (Session["IDuser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            List<HoadonproDTO> lsthd = HoadonDAO.LoadInfoHDbyiduser(Session["IDuser"].ToString(), IDhoadon);
            if (lsthd == null) { return RedirectToAction("Index", "Home"); }
            return View(lsthd);
        }
        public ActionResult Nhanhang(string IDhoadon)
        {
            HoadonDAO.Danhanhang(Session["IDuser"].ToString(), IDhoadon);
            return RedirectToAction("Hoadon", "Home");
        }
        public ActionResult Hoanhang(string IDhoadon)
        {
            HoadonDAO.Yeucauhoanhang(Session["IDuser"].ToString(), IDhoadon);
            return RedirectToAction("Hoadon", "Home");
        }
        public ActionResult Danhgia(string submit)
        {
            string IDhoadon = submit;
            List<Int32> lst = SachDAO.Getidsachinbill(Session["IDuser"].ToString(), IDhoadon);
            int count = 0;
            foreach (var i in lst)
            {
                string temp = "i_danhgia" + count.ToString();
                string rv = Request.Form[temp];
                DanhgiaDAO.Danhgiasach(Session["IDuser"].ToString(), i,rv, IDhoadon);
                count++;
            }
            DanhgiaDAO.CloseDanhgia(Session["IDuser"].ToString(), IDhoadon);
            return RedirectToAction("Hoadon", "Home");
        }
        public ActionResult Product(string id)
        {
            Sach s = SachDAO.Loadsachbyid(id);
            ViewBag.Theloai = SachDAO.LoadloaibyIDsach(id);
            ViewBag.Danhgia = DanhgiaDAO.LoadDanhgiabyIDsach(id);
            return View(s);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}