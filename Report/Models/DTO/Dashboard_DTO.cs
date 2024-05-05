using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report.Models.DTO
{
    public class Dashboard_DTO
    {

        public int Tong_Phieu_Nhap {  get; set; }
        public int Tong_Phieu_Thieu_Thong_Tin { get; set; }
        public string SO_PHIEU_NHAP { get; set; }
     
        public string STO_CODE { get; set; }
        public string HD_GC { get; set; }
        public string SO_VAN_DON { get; set; }
        public Nullable<DateTime> NGAY_VAN_DON { get; set; }
        public string SO_TO_KHAI_HAI_QUAN { get; set; }
        public Nullable<DateTime> NGAY_TO_KHAI_HAI_QUAN { get; set; }
        public string MA_HOP_DONG { get; set; }
        public string SO_HOP_DONG { get; set; }
     
      
        public string SO_CHUNG_TU { get; set; }
        public string MA_HAI_QUAN { get; set; }

        public string LOT_NUMBER { get; set; }
        public string NAME { get; set; }

        public IEnumerable<Dashboard_Details_DTO> Dashboard_Details_DTO { get; set; }
    }
}