using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bansach.DTO
{
    public class HoadonproDTO
    {
        public int IDhoadon { get; set; }
        public int IDuser { get; set; }
        public string IDvoucher { get; set; }
        public string Ghichu { get; set; }
        public double Tongtien { get; set; }
        public double Thanhtien { get; set; }
        public System.DateTime Ngaydat { get; set; }
        public Nullable<System.DateTime> Ngaydukiengiao { get; set; }
        public Nullable<System.DateTime> Ngaygiao { get; set; }
        public int IDtinhtrang { get; set; }
        public int IDtaixe { get; set; }
        public string Diachi { get; set; }
        public double TienShip { get; set; }
        public int IDthanhtoan { get; set; }
        public bool Danhgia { get; set; }
        public double Chietkhau { get; set; }
        public string Tenphuongthuc { get; set; }
        public string TentinhtrangHD { get; set; }
        public string Tentaixe { get; set; }
        public string Tenkh { get; set; }
        public string Sdtkh { get; set; }
        public string Tensach { get; set; }
        public string Hinhanh { get; set; }
        public int Soluong { get; set; }
        public double Tongdongia { get; set; }
    }
}