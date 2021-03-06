﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLNV.Web.Models.NhanVien
{
    public class TaoNhanVien
    {
        
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Nhập họ nhân viên")]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Họ nhân viên có 1- 20 ký tự")]
        public string Ho { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Nhập tên nhân viên")]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Tên nhân viên có 1- 20 ký tự")]
        public string Ten { get; set; }
        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Nhập địa chỉ ")]
        [StringLength(maximumLength: 250, MinimumLength = 1, ErrorMessage = "Không quá 250 ký tự")]
        public string DiaChi { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Nhập  số điện thoại")]
        [StringLength(maximumLength: 20, MinimumLength = 10, ErrorMessage = "Số điện thoại phải 10 - 20 ký tự")]
        [Phone(ErrorMessage ="Số điện thoại không đúng định dạng")]
        public string DienThoai { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name = "Phòng Ban")]
        public int PhongBanId { get; set; }
    }
}
