using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_NguyenTranTuanAnh_3001160301_CNW_09.Models;

namespace _12_NguyenTranTuanAnh_3001160301_CNW_09.Controllers
{
    public class SinhVienController : Controller
    {
        //
        // GET: /SinhVien/
        DataClasses3DataContext data = new DataClasses3DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListSinhVien()
        {
            List<SinhVien> list = data.SinhViens.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddSinhVien(SinhVien sv)
        {
            int kq = 1;
            try
            {
                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
            }
            catch
            {
                kq = 0;
            }

            return Json(kq, JsonRequestBehavior.AllowGet);
        }

    }
}
