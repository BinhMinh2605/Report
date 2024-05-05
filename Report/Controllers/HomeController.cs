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
        public ActionResult Index()
        {
            List<string> stoCodeList = _IReportRepository.GetStoCode().Result;
            ViewBag.StoCodeList = stoCodeList;

            List<string> monthYearList = GetMonthYearList();
            ViewBag.MonthYearList = monthYearList;

            DateTime currentTime = DateTime.Now;
            string defaultTime = $"{currentTime.Month}-{currentTime.Year}";
            Session["Ape_id"] = defaultTime;
            ViewBag.SelectedApeId = defaultTime;

            return View();
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