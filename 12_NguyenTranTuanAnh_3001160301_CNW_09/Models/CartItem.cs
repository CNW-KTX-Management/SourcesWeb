using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12_NguyenTranTuanAnh_3001160301_CNW_09.Models
{
    public class CartItem
    {
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoluong { get; set; }

        public double ThanhTien
        {
            get { return iSoluong * dDonGia; }
        }

        DataClasses1DataContext data = new DataClasses1DataContext();

        public CartItem(int ms)
        {
            tbl_SanPham a = data.tbl_SanPhams.SingleOrDefault(t => t.MaSanPham == ms);
            if (a != null)
            {
                iMaSach = ms;
                sTenSach = a.TenSP;
                sAnhBia = a.HinhAnh;
                dDonGia = (double)a.DonGia;
                iSoluong = 1;
            }
        }


    }
}