using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bansach.DTO
{
    public class HoadonDTO
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
        public string TentinhtrangHD { get; set; }
        public int IDtaixe { get; set; }
        public bool Danhgia { get; set; }
    }
}