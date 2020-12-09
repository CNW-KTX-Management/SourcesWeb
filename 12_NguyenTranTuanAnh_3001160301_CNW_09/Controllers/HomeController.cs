using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_NguyenTranTuanAnh_3001160301_CNW_09.Models;
namespace _12_NguyenTranTuanAnh_3001160301_CNW_09.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DataClasses1DataContext data = new DataClasses1DataContext();

       public ActionResult Login()
        {
            return View();
        }
        public ActionResult Create()
        {
           
            return View();
        }

       

    }
}
