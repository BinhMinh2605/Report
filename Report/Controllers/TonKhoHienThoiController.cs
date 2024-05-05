using PagedList;
using Report.Models.DTO;
using Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Report.Controllers
{
    public class TonKhoHienThoiController : Controller
    {
        // GET: TonKhoHienThoi
        private readonly IReportRepository _IReportRepository = null;
        public TonKhoHienThoiController()
        {
            this._IReportRepository = new ReportRepository();
        }
        public TonKhoHienThoiController(IReportRepository repository)
        {
            this._IReportRepository = repository;
        }
        [HttpPost]
        public ActionResult Search(string Ape_id, string Sto_code)
        {
            Session["Ape_id"] = Ape_id;
            Session["Sto_code"] = Sto_code;
            return RedirectToAction("Index");
        }
        public ActionResult Index(int? page)
        {
            PagedList.IPagedList<TonKhoHienThoi_DTO> pagedListTonKhoHienThoi = null;
            List<string> monthYearList = GetMonthYearList();
            ViewBag.MonthYearList = monthYearList;

            List<string> stoCodeList = _IReportRepository.GetStoCode().Result;
            ViewBag.StoCodeList = stoCodeList;


            var Ape_id = Session["Ape_id"] as string;
            var Sto_code = Session["Sto_code"] as string;
            if (Ape_id == null && Sto_code == null)
            {
                DateTime currentTime = DateTime.Now;
                string defaultTime = $"{currentTime.Month}-{currentTime.Year}";
                Session["Ape_id"] = defaultTime;
                ViewBag.SelectedApeId = defaultTime;
            }
            else
            {
                ViewBag.SelectedApeId = Ape_id;
                ViewBag.SelectedStoCode = Sto_code;

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                List<TonKhoHienThoi_DTO> allTonKhoHienThoi = _IReportRepository.ReportTonKhoHienThoi(Ape_id, Sto_code).Result;
                pagedListTonKhoHienThoi = allTonKhoHienThoi?.ToPagedList(pageNumber, pageSize);
            }
            return View(pagedListTonKhoHienThoi);

            //  var s = _IReportRepository.ReportNhapXuatTon("01-04-2024","29-02-2024", "S1").Result;
            // return View(s);
        }

        public static List<string> GetMonthYearList()
        {
            List<string> monthYearList = new List<string>();
            DateTime currentDate = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                int year = currentDate.Year - i;
                for (int month = 1; month <= 12; month++)
                {
                    string monthYear = $"{month}-{year}";
                    monthYearList.Add(monthYear);
                }
            }
            return monthYearList.ToList();
        }
    }
}