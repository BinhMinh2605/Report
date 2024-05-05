using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report.Models.DTO
{
    public class Responsive_NhapXuatTon_DTO
    {
        public string ICA_NAME { get; set; }

        public string IIT_CODE { get; set; }
        public string TEN_HANG { get; set; }
        public string LOT_NUMBER { get; set; }
        public string ERP_CODE { get; set; }
        public string NHA_SX { get; set; }

        public double? SL_TON { get; set; }
        public double? SL_NHAP { get; set; }
        public double? SL_XUAT { get; set; }
        public double? SL_CUOI { get; set; }
        public string HD_GC { get; set; }
        public string SO_VAN_DON { get; set; }
        public Nullable<DateTime> NGAY_VAN_DON { get; set; }
        public string SO_TO_KHAI_HAI_QUAN { get; set; }
        public Nullable<DateTime> NGAY_TO_KHAI_HAI_QUAN { get; set; }
        public string MA_HOP_DONG { get; set; }
        public string SO_HOP_DONG { get; set; }

        public string THANH_PHAN_VAI { get; set; }
        public string SO_PHIEU_NHAP { get; set; }
        public string MA_HAI_QUAN { get; set; }








    }
}