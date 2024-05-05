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
        public IEnumerable<NhapXuatTon_Details_DTO> NhapXuatTon_Details_DTO { get; set; }
    }
}