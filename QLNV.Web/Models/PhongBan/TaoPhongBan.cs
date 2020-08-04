using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace QLNV.Web.Models.PhongBan
{
    public class TaoPhongBan
    {
        [Display(Name = "Mã Phòng Ban")]
        [Required(ErrorMessage ="Nhập mã phòng ban")]
        [StringLength(maximumLength:5, MinimumLength =5, ErrorMessage ="Mã Phòng Ban có 5 ký tự")]
        public string MaPhongBan { get; set; }
        [Display(Name = "Tên Phòng Ban")]
        [Required(ErrorMessage = "Nhập tên phòng ban")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "TênPhòng Ban từ 1 - 50 ký tự")]
        public string TenPhongBan { get; set; }
        
    }
}
