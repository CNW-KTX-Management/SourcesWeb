using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12_NguyenTranTuanAnh_3001160301_CNW_09.Models
{
    public class GioHang
    {
        public List<CartItem> dsSP;

        public GioHang() 
        {
            dsSP = new List<CartItem>();
        }
        public GioHang(List<CartItem> lst) 
        { }

        public int Somathang()
        {
            if(dsSP == null)
                return 0;
            return dsSP.Count();
        }

        public int TongSLSP()
        {
            if (dsSP == null)
                return 0;
            return dsSP.Sum(t => t.iSoluong);            
        }

        public double ThanhTien()
        {
            if (dsSP == null)
                return 0;
            return dsSP.Sum(t => t.ThanhTien);
        }

        public double TongThanhTien()
        {
            if (dsSP == null)
                return 0;
            return dsSP.Sum(t => t.ThanhTien);
        }

        public int Them(int iMaSach)
        {
            CartItem sach = dsSP.Find(n => n.iMaSach == iMaSach);
            if (sach == null)
            {
                CartItem a = new CartItem(iMaSach);
                if (a == null)
                    return 0;
                dsSP.Add(a);
            }
            else
            {
                sach.iSoluong++;
            }
            return 1;

        }
    }
}