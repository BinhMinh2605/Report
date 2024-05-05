using Microsoft.VisualStudio.Services.WebApi;
using Report.Models;
using Report.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web.Mvc;
using System.Web;
using System.Web.UI;
using PagedList;
using System;
using System.EnterpriseServices.Internal;
using System.Web.UI.WebControls;

namespace Report.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReportRepository _IReportRepository = null;
        public HomeController()
        {
            this._IReportRepository = new ReportRepository();
        }
        public HomeController(IReportRepository repository)
        {
            this._IReportRepository = repository;
        }
        public ActionResult Search(string Ape_id, string Sto_code)
        {
            Session["Ape_id"] = Ape_id;
            Session["Sto_code"] = Sto_code;
            return RedirectToAction("Index");
        }
        public ActionResult Index(int? page)
        {
            PagedList.IPagedList<Dashboard_DTO> pagedListDashboard = null;
            List<string> monthYearList = GetMonthYearList();
            ViewBag.MonthYearList = monthYearList;

            List<string> stoCodeList = _IReportRepository.GetStoCode().Result;
            ViewBag.StoCodeList = stoCodeList;


            var Ape_id = Session["Ape_id"] as string;
            var Sto_code = Session["Sto_code"] as string;
            if (Ape_id == null || Sto_code == null)
            {
                DateTime currentTime = DateTime.Now;
                string defaultTime = $"{currentTime.Month}-{currentTime.Year}";
                Session["Ape_id"] = defaultTime;
                ViewBag.SelectedApeId = defaultTime;
                Session["Sto_code"] = stoCodeList.FirstOrDefault();
                ViewBag.SelectedStoCode = stoCodeList.FirstOrDefault();
            }
            else
            {
                ViewBag.SelectedApeId = Ape_id;
                ViewBag.SelectedStoCode = Sto_code;

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                List<Dashboard_DTO> allDashboard = _IReportRepository.Dashboard(Ape_id, Sto_code).Result;
                ViewBag.Tong_Phieu_Nhap = allDashboard.Select(x => x.Tong_Phieu_Nhap).FirstOrDefault();
                ViewBag.Tong_Phieu_Thieu_Thong_Tin = allDashboard.Select(x => x.Tong_Phieu_Thieu_Thong_Tin).FirstOrDefault();
                pagedListDashboard = allDashboard?.ToPagedList(pageNumber, pageSize);
            }
            return View(pagedListDashboard);

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