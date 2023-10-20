using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bansach.DTO
{
    public class HoadonshipperDTO
    {
        public int IDhoadon { get; set; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }
        public string Ghichu { get; set; }
        public string Diachi { get; set; }
        public double Thanhtien { get; set; }
        public string Tenphuongthuc { get; set; }
        public System.DateTime Ngaydukiengiao { get; set; }
        public Nullable<System.DateTime> Ngaygiao { get; set; }
    }
}