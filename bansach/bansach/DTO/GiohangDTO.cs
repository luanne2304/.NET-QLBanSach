using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bansach.DTO
{
    public class GiohangDTO
    {
        public int IDsach { get; set; }
        public string Tensach { get; set; }
        public string Hinhanh { get; set; }
        public string Tacgia { get; set; }
        public double Gia { get; set; }
        public int Soluong { get; set; }
    }
}