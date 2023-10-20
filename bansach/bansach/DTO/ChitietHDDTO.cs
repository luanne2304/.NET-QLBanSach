using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bansach.DTO
{
    public class ChitietHDDTO
    {
        public int IDhoadon { get; set; }
        public int IDuser { get; set; }
        public String IDvoucher { get; set; }
        public string Ghichu { get; set; }
        public double Tongtien { get; set; }
        public double Thanhtien { get; set; }
        public System.DateTime Ngaydat { get; set; }
        public Nullable<System.DateTime> Ngaydukiengiao { get; set; }
        public Nullable<System.DateTime> Ngaygiao { get; set; }
        public int IDtinhtrang { get; set; }
        public string TentinhtrangHD { get; set; }
        public int IDsach { get; set; }
        public string Tensach { get; set; }
        public string Hinhanh { get; set; }
        public int Soluong { get; set; }
        public double Tongdongia { get; set; }
        public int IDtaixe { get; set; }
    }
}