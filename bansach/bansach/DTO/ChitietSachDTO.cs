using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bansach.DTO
{
    public class ChitietSachDTO
    {
        public int IDsach { get; set; }
        public string Tensach { get; set; }
        public string Tacgia { get; set; }
        public string Mota { get; set; }
        public double Gia { get; set; }
        public string Hinhanh { get; set; }
        public int SoLuong { get; set; }
        public bool Trangthai { get; set; }
        public int IDloai { get; set; }
        public string Tenloai { get; set; }
    }
}