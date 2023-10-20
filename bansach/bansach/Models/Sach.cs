﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bansach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Sach
    {
        public int IDsach { get; set; }
        [Required(ErrorMessage = "Vui lòng điền vào")]
        public string Tensach { get; set; }
        [Required(ErrorMessage = "Vui lòng điền vào")]
        public string Tacgia { get; set; }
        [Required(ErrorMessage = "Vui lòng điền vào")]
        public string Mota { get; set; }
        [Required(ErrorMessage = "Vui lòng điền vào")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a number greater than zero.")]
        public double Gia { get; set; }
        public string Hinhanh { get; set; }
        public int SoLuong { get; set; }
        public bool Trangthai { get; set; }
        public int LuotXem { get; set; }
    }
}