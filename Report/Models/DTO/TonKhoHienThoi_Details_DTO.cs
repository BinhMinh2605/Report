using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report.Models.DTO
{
    public class TonKhoHienThoi_Details_DTO
    {
        public string HD_GC { get; set; } 
        public string SO_VAN_DON { get; set; }
        public Nullable<DateTime> NGAY_VAN_DON { get; set; }
        public string SO_TO_KHAI_HAI_QUAN { get; set; }
        public Nullable<DateTime> NGAY_TO_KHAI_HAI_QUAN { get; set; }
        public string MA_HOP_DONG { get; set; }
        public string SO_HOP_DONG { get; set; }
        public string LOAI_GIAO_DICH { get; set; }
        public string THANH_PHAN_VAI { get; set; }
        public string SO_PHIEU_NHAP { get; set; }
        public string SO_CHUNG_TU { get; set; }
        public string MA_HAI_QUAN { get; set; }
    }
}