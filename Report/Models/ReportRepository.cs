using Oracle.ManagedDataAccess.Client;
using Report.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Report.Models
{
    public class ReportRepository : IReportRepository
    {
        public async Task<List<TonKhoHienThoi_DTO>> ReportTonKhoHienThoi(string Ape_id, string Sto_code)
        {
            try
            {
                using (var ctx = new ReportEntities())
                {
                    var param0 = new OracleParameter("pApe_id", OracleDbType.Varchar2, Ape_id, ParameterDirection.Input);
                    var param1 = new OracleParameter("pSto_code", OracleDbType.Varchar2, Sto_code, ParameterDirection.Input);
                    var param3 = new OracleParameter("out_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    var res = ctx.Database.SqlQuery<Responsive_TonKhoHienThoi_DTO>(
                    "BEGIN TC_REPORT.EXCEL_TON_KHO_HIEN_THOI(:pApe_id,:pSto_code,:rpt); end;",
                    param0, param1, param3);
                    var results = res.GroupBy(x => new
                    {
                        x.Ma_lo,
                        x.Ma_hang,
                        x.ERP_CODE,
                        x.Ten_hang,
                        x.Khu_vuc_kho,
                        x.Ten_thuoc_tinh,
                        x.Ton_cuoi,
                        x.DVT,
                        x.makho,
                        x.Ton_cuoi_quy_doi,
                        x.Mau,
                        x.SoBangKe,
                        x.SoTruc,
                        x.MaMau,
                        x.KichKho,
                        x.KhachHang,
                        x.DonDatHang,
                        x.SoHD,
                        x.Ngay_nhap,
                        x.SuDung,
                        x.PhanLoai,
                        x.PO,
                        x.YARN_LOT,
                        x.THANH_PHAN_VAI
                    }).Select(x => new TonKhoHienThoi_DTO
                    {
                        Ma_lo = x.Key.Ma_lo,
                        Ma_hang = x.Key.Ma_hang,
                        ERP_CODE = x.Key.ERP_CODE,
                        Ten_hang = x.Key.Ten_hang,
                        Khu_vuc_kho = x.Key.Khu_vuc_kho,
                        Ten_thuoc_tinh = x.Key.Ten_thuoc_tinh,
                        Ton_cuoi = x.Key.Ton_cuoi,
                        DVT = x.Key.DVT,
                        makho = x.Key.makho,
                        Ton_cuoi_quy_doi = x.Key.Ton_cuoi_quy_doi,
                        Mau = x.Key.Mau,
                        SoBangKe = x.Key.SoBangKe,
                        SoTruc = x.Key.SoTruc,
                        MaMau = x.Key.MaMau,
                        KichKho = x.Key.KichKho,
                        KhachHang = x.Key.KhachHang,
                        DonDatHang = x.Key.DonDatHang,
                        SoHD = x.Key.SoHD,
                        Ngay_nhap = x.Key.Ngay_nhap,
                        SuDung = x.Key.SuDung,
                        PhanLoai = x.Key.PhanLoai,
                        PO = x.Key.PO,
                        YARN_LOT = x.Key.YARN_LOT,
                        THANH_PHAN_VAI = x.Key.THANH_PHAN_VAI,
                        TonKhoHienThoi_Details_DTO = x.Select(y => new TonKhoHienThoi_Details_DTO
                        {
                            HD_GC = y.HD_GC,
                            SO_VAN_DON = y.SO_VAN_DON,
                            NGAY_VAN_DON = y.NGAY_VAN_DON,
                            SO_TO_KHAI_HAI_QUAN = y.SO_TO_KHAI_HAI_QUAN,
                            NGAY_TO_KHAI_HAI_QUAN = y.NGAY_TO_KHAI_HAI_QUAN,
                            MA_HOP_DONG = y.MA_HOP_DONG,
                            SO_HOP_DONG = y.SO_HOP_DONG,
                            LOAI_GIAO_DICH = y.LOAI_GIAO_DICH,
                            THANH_PHAN_VAI = y.THANH_PHAN_VAI,
                            SO_PHIEU_NHAP = y.SO_PHIEU_NHAP,
                            SO_CHUNG_TU = y.SO_CHUNG_TU,
                            MA_HAI_QUAN = y.MA_HAI_QUAN
                        }).ToList()
                    });
                    return await System.Threading.Tasks.Task.FromResult(results.ToList());
                }
            }
            catch { throw; }
        }
        public async Task<List<NhapXuatTon_DTO>> ReportNhapXuatTon(string ToDate, string FromDate, string Sto_code)
        {
            try
            {
                using (var ctx = new ReportEntities())
                {
                    string Ape_id = "4-2024";

                    string Ape_id2 = "3-2024";
                    var param1 = new OracleParameter("pApe_id_2", OracleDbType.Varchar2, Ape_id2, ParameterDirection.Input);
                    var param2 = new OracleParameter("pSto_code", OracleDbType.Varchar2, Sto_code, ParameterDirection.Input);
                    var param3 = new OracleParameter("pApe_id", OracleDbType.Varchar2, Ape_id, ParameterDirection.Input);
                    var param4 = new OracleParameter("out_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    var res = ctx.Database.SqlQuery<Responsive_NhapXuatTon_DTO>(
                    "BEGIN TC_REPORT.EXCEL_NHAP_XUAT_TON(:pApe_id_2,:pSto_code,:pApe_id,:rpt); end;",
                    param1, param2, param3, param4).ToList();
                    var results = res.GroupBy(x => new
                    {
                        x.ICA_NAME,
                        x.IIT_CODE,
                        x.TEN_HANG,
                        x.LOT_NUMBER,
                        x.ERP_CODE,
                        x.NHA_SX,

                    }).Select(x => new NhapXuatTon_DTO
                    {
                        ICA_NAME = x.Key.ICA_NAME,
                        IIT_CODE = x.Key.IIT_CODE,
                        TEN_HANG = x.Key.TEN_HANG,
                        LOT_NUMBER = x.Key.LOT_NUMBER,
                        ERP_CODE = x.Key.ERP_CODE,
                        NHA_SX = x.Key.NHA_SX,
                        SL_TON = x.Sum(a => a.SL_TON).Value,
                        SL_NHAP = x.Sum(a => a.SL_NHAP).Value,
                        SL_XUAT = x.Sum(a => a.SL_XUAT).Value,
                        SL_CUOI = x.Sum(a => a.SL_TON).Value + x.Sum(a => a.SL_NHAP).Value - x.Sum(a => a.SL_XUAT).Value,


                        NhapXuatTon_Details_DTO = x.Select(y => new NhapXuatTon_Details_DTO
                        {
                            HD_GC = y.HD_GC,
                            SO_VAN_DON = y.SO_VAN_DON,
                            NGAY_VAN_DON = y.NGAY_VAN_DON,
                            SO_TO_KHAI_HAI_QUAN = y.SO_TO_KHAI_HAI_QUAN,
                            NGAY_TO_KHAI_HAI_QUAN = y.NGAY_TO_KHAI_HAI_QUAN,
                            MA_HOP_DONG = y.MA_HOP_DONG,
                            SO_HOP_DONG = y.SO_HOP_DONG,
                            // LOAI_GIAO_DICH = y.LOAI_GIAO_DICH,
                            THANH_PHAN_VAI = y.THANH_PHAN_VAI,
                            SO_PHIEU_NHAP = y.SO_PHIEU_NHAP,
                            MA_HAI_QUAN = y.MA_HAI_QUAN


                        })
                    });
                    return await System.Threading.Tasks.Task.FromResult(results.ToList());
                }
            }
            catch { throw; }
        }
        public async Task<List<String>> GetStoCode()
        {
            using (var ctx = new ReportEntities())
            {
                return await Task.FromResult(ctx.STORES.Where(x => x.CCE_ID == "A11").Select(X => X.STO_CODE).ToList());
            }
        }
    }
}