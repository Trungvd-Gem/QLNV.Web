using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLNV.Web.Models.NhanVien;

namespace QLNV.Web.Controllers
{
    public class NhanVienController : Controller
    {
        private static int phongBanId = 0;
        public IActionResult Index(int id)
        {
            var nhanViens = new List<NhanVienView>();
            var url = $"{Common.Common.ApiUrl}/nhanvien/danhsachnhanvientheophongban/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();

                }
                nhanViens = JsonConvert.DeserializeObject<List<NhanVienView>>(responseData);
            }
            phongBanId = id;
            ViewBag.TenPhongBan = DanhSachPhongBan().Where(p => p.ID == id).FirstOrDefault().TenPhongBan;
            return View(nhanViens);
        }

        public IActionResult TaoNhanVien()
        {
            ViewBag.PhongBans = DanhSachPhongBan();
            ViewBag.PhongBanId = phongBanId;
            return View();
        }

        [HttpPost]
        public IActionResult TaoNhanVien(TaoNhanVien model)
        {
            int ketQua = 0;
            var url = $"{Common.Common.ApiUrl}/nhanvien/taonhanvien";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var resKetQua = streamReader.ReadToEnd();
                ketQua = int.Parse(resKetQua);
            }

            if (ketQua > 0)
            {
                TempData["ThanhCong"] = "Đã tạo nhân viên thành công";
            }
            ViewBag.PhongBans = DanhSachPhongBan();
            ViewBag.PhongBanId = phongBanId;
            ModelState.Clear();
            return View(new TaoNhanVien() { });
        }

        public IActionResult SuaNhanVien (int id)
        {
            var phongban = new SuaNhanVien();
            var url = $"{Common.Common.ApiUrl}/nhanvien/suanhanvien/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();

                }
                phongban = JsonConvert.DeserializeObject<SuaNhanVien>(responseData);
            }
            TempData["ThanhCong"] = null;
            TempData["Loi"] = null;
            return View(phongban);
        }
        private List<PhongBanItem> DanhSachPhongBan()
        {
            var phongbans = new List<PhongBanItem>();
            var url = $"{Common.Common.ApiUrl}/phongban/danhsachphongban";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();

                }
                phongbans = JsonConvert.DeserializeObject<List<PhongBanItem>>(responseData);
            }
            return phongbans;
        }
    }
}
