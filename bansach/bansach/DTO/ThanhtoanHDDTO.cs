using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bansach.DAO
{
    public class ThanhtoanHDDTO
    {

        [Required(ErrorMessage = "Vui lòng điền vào")]
        public string Diachi { get; set; }
        public string Sanpham { get; set; }
        public string MaGiam { get; set; }
    }
}