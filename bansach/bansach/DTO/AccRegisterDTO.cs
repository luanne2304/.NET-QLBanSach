using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bansach.DTO
{
    public class AccRegisterDTO
    {
        public int IDuser { get; set; }

        [Required(ErrorMessage = "Vui lòng điền vào")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Cần phải từ 8 đến 20 kí tự")]
        public string Tk { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng điền vào")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Cần phải từ 8 đến 20 kí tự")]               
        public string Mk { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng điền vào")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Cần phải từ 8 đến 20 kí tự")]
        [Compare("Mk", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string Mk2 { get; set; }

        [Required(ErrorMessage = "Vui lòng điền vào")]       
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng điền vào")]
        [EmailAddress(ErrorMessage = "Mail ko hợp lệ")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Vui lòng điền vào")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Cần điền đúng SDT")]
        public string Sdt { get; set; }
    }
}