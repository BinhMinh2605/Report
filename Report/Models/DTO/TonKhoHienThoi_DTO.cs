using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report.Models.DTO
{
    public class TonKhoHienThoi_DTO
    {
        public string Ma_lo { get; set; }
        public string Ma_hang { get; set; }
        public string ERP_CODE { get; set; }
        public string Ten_hang { get; set; }
        public string Khu_vuc_kho { get; set; }
        public string Ten_thuoc_tinh { get; set; }
        public double? Ton_cuoi { get; set; }
        public string DVT { get; set; }
        public string makho { get; set; }
        public double? Ton_cuoi_quy_doi { get; set; }
        public string Mau { get; set; }
        public string SoBangKe { get; set; }
        public string SoTruc { get; set; }
        public string MaMau { get; set; }
        public string KichKho { get; set; }
        public string KhachHang { get; set; }
        public string DonDatHang { get; set; }
        public string SoHD { get; set; }
        public string Ngay_nhap { get; set; }
        public string SuDung { get; set; }
        public string PhanLoai { get; set; }
        public string PO { get; set; }
        public string YARN_LOT { get; set; }
        public string THANH_PHAN_VAI { get; set; }
        public IEnumerable<TonKhoHienThoi_Details_DTO> TonKhoHienThoi_Details_DTO { get; set; }
    }

}