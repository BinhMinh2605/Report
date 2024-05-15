using Report.Models;
using Report.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Report.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IReportRepository _IReportRepository = null;
        public DashboardController()
        {
            this._IReportRepository = new ReportRepository();
        }
        public DashboardController(IReportRepository repository)
        {
            this._IReportRepository = repository;
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            List<Dashboard_DTO> stoCodeList = _IReportRepository.Dashboard("3-2024","NX").Result;
            ViewBag.StoCodeList = stoCodeList;

           // List<string> monthYearList = GetMonthYearList();
          //  ViewBag.MonthYearList = monthYearList;

            DateTime currentTime = DateTime.Now;
            string defaultTime = $"{currentTime.Month}-{currentTime.Year}";
            Session["Ape_id"] = defaultTime;
            ViewBag.SelectedApeId = defaultTime;

            return View();
        }
    }
}