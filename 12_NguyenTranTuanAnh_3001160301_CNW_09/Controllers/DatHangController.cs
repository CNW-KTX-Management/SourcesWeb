using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_NguyenTranTuanAnh_3001160301_CNW_09.Models;

namespace _12_NguyenTranTuanAnh_3001160301_CNW_09.Controllers
{
    public class DatHangController : Controller
    {
        //
        // GET: /DatHang/

        DataClasses1DataContext data = new DataClasses1DataContext();

        public ActionResult ThemMatHang(int msp)
        {
            GioHang gio = (GioHang) Session["gh"];
            if (gio == null)
            {
                gio = new GioHang();
            }
            gio.Them(msp);

            Session["gh"] = gio;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult XemGioHang()
        {
            GioHang gh =(GioHang) Session["gh"];
            return View(gh);
        }

        [HttpGet]
        public ActionResult XacNhanDonHang()
        {
            tbl_KhachHang khach = Session["kh"] as tbl_KhachHang;
            if (khach == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            //Da Dang Nhap
            ViewBag.k = khach;
            GioHang gio = Session["gh"] as GioHang;

            return View(gio);
        }

        [HttpPost]
        public ActionResult LuuDonHang(FormCollection c)
        {
            string ngaygiao = c["txtDate"];
            GioHang gio = Session["gh"] as GioHang;
            tbl_KhachHang khach = Session["kh"] as tbl_KhachHang;

            tbl_HoaDon hd = new tbl_HoaDon();
            hd.NgayHoaDon = DateTime.Now;
            hd.MaKH = khach.MaKhachHang;
            hd.NgayGiao = DateTime.Parse(ngaygiao);
            data.tbl_HoaDons.InsertOnSubmit(hd);
            data.SubmitChanges();          

            //Lưu nhiều dòng vào bảng chi tiết đơn hàng
            foreach (CartItem item in gio.dsSP)
            {
                tbl_ChiTiet ct = new tbl_ChiTiet();
                ct.MaHD = hd.MaHoaDon;
                ct.MaSP = item.iMaSach;
                ct.SoLuong = item.iSoluong;

                data.tbl_ChiTiets.InsertOnSubmit(ct);
                data.SubmitChanges();
            }

            Session["gh"] = null;
            return View();
        }
    }
}

