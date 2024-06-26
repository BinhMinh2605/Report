﻿using Report.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Report.Models
{
    public interface IReportRepository
    {
        Task<List<TonKhoHienThoi_DTO>> ReportTonKhoHienThoi(string Ape_id, string Sto_code);
        Task<List<NhapXuatTon_DTO>> ReportNhapXuatTon(string Ape_id, string Sto_code);
        Task<List<String>> GetStoCode();
        Task<List<Responsive_NhapXuatTon_DTO>> ExportNhapXuatTon(string Ape_id, string Sto_code);
        Task<List<Responsive_TonKhoHienThoi_DTO>> EportTonKhoHienThoi(string Ape_id, string Sto_code);
        Task<List<Dashboard_DTO>> Dashboard(string Ape_id, string Sto_code);
    }
}