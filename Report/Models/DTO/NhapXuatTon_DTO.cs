using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report.Models.DTO
{
    public class NhapXuatTon_DTO
    {
        public string ICA_NAME { get; set; }

        public string IIT_CODE { get; set; }
        public string TEN_HANG { get; set; }
        public string LOT_NUMBER { get; set; }
        public string ERP_CODE { get; set; }
        public string NHA_SX { get; set; }

        public double SL_TON { get; set; }
        public double SL_NHAP { get; set; }
        public double SL_XUAT { get; set; }
        public double SL_CUOI { get; set; }
        //public string HD_GC { get; set; }
        //public string SO_VAN_DON { get; set; }
        //public Nullable<DateTime> NGAY_VAN_DON { get; set; }
        //public string SO_TO_KHAI_HAI_QUAN { get; set; }
        //public Nullable<DateTime> NGAY_TO_KHAI_HAI_QUAN { get; set; }
        //public string MA_HOP_DONG { get; set; }
        //public string SO_HOP_DONG { get; set; }

        //public string THANH_PHAN_VAI { get; set; }
        //public string SO_PHIEU_NHAP { get; set; }
        //public string MA_HAI_QUAN { get; set; }
        //public string Ica_Code { get; set; }
        //public string Ica_Name { get; set; }
        //public string Iit_Code { get; set; }
        //public string Vattu { get; set; }
        //public string Uom_Code { get; set; }
        //public string Critical { get; set; }
        //public string Aun_Id { get; set; }
        //public string Cce_Id { get; set; }
        //public string Acc_Id { get; set; }
        //public string Pro_Id { get; set; }
        //public double Sl_Ton { get; set; }
        //public double Gt_Ton { get; set; }
        //public double Sl_Nhap { get; set; }
        //public double Gt_Nhap { get; set; }
        //public double Sl_Xuat { get; set; }
        //public double Gt_Xuat { get; set; }
        //public double Gt_Cuoi { get; set; }
        //public string Sto_Code { get; set; }
        //public string Ky_Ke_Toan { get; set; }
        public IEnumerable<NhapXuatTon_Details_DTO> NhapXuatTon_Details_DTO { get; set; }
    }
}