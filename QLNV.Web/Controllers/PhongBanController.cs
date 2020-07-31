 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QLNV.Web.Models;
using QLNV.Web.Models.PhongBan;

namespace QLNV.Web.Controllers
{
    public class PhongBanController : Controller
    {
        private readonly ILogger<PhongBanController> _logger;

        public PhongBanController(ILogger<PhongBanController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var phongbans = new List<PhongBanView>();
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
                    } finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                } finally
                {
                    ((IDisposable)responseStream).Dispose();

                }
                phongbans = JsonConvert.DeserializeObject<List<PhongBanView>>(responseData);
            }
            return View(phongbans);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
