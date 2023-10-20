using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bansach.DTO
{
    public class ShipperDTO
    {
        public int IDuser { get; set; }
        public string Tk { get; set; }
        public string HoTen { get; set; }
        public string Mail { get; set; }
        public string Sdt { get; set; }
        public int IDrole { get; set; }
        public bool TrangThai { get; set; }
    }
}