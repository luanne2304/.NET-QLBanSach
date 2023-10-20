using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bansach.DTO
{
    public class AccLoginDTO
    {
        [Required(ErrorMessage = "Vui lòng điền vào")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Cần phải từ 8 đến 20 kí tự")]
        public string Tk { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng điền vào")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Cần phải từ 8 đến 20 kí tự")]
        public string Mk { get; set; }
    }
}