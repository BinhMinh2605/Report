﻿using PagedList;
using Report.Models.DTO;
using Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;
using System.IO;
using Microsoft.VisualStudio.Services.Common;
using System.Web.UI.WebControls;

namespace Report.Controllers
{
    public class NhapXuatTonController : Controller
    {
        // GET: NhapXuatTon
        private readonly IReportRepository _IReportRepository = null;
        public NhapXuatTonController()
        {
            this._IReportRepository = new ReportRepository();
        }
        public NhapXuatTonController(IReportRepository repository)
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
            PagedList.IPagedList<NhapXuatTon_DTO> pagedListNhapXuatTon = null;
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
                List<NhapXuatTon_DTO> allNhapXuatTon = _IReportRepository.ReportNhapXuatTon(Ape_id, Sto_code).Result;
                pagedListNhapXuatTon = allNhapXuatTon?.ToPagedList(pageNumber, pageSize);
            }
            return View(pagedListNhapXuatTon);


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
        [HttpPost]
        public ActionResult Export(string Export_Sto_code, string Export_Ape_id)
        {
            Export_Ape_id = Session["Ape_id"] as string;
            Export_Sto_code = Session["Sto_code"] as string;
            List<Responsive_NhapXuatTon_DTO> allNhapXuatTon = _IReportRepository.ExportNhapXuatTon(Export_Ape_id, Export_Sto_code).Result;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells["A1"].LoadFromCollection(allNhapXuatTon, true);
                string Name = "~/App_Data/NhapXuatTon_" + Export_Sto_code + "_" + Export_Ape_id + ".xlsx";
                string filePath = Server.MapPath(Name);
                FileInfo excelFile = new FileInfo(filePath);
                package.SaveAs(excelFile);
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("Content-Disposition", "attachment; filename=NhapXuatTon_" + Export_Sto_code + "_" + Export_Ape_id + ".xlsx");
                Response.TransmitFile(excelFile.FullName);
                Response.End();
            }

            return RedirectToAction("Index");
        }
    }
}
