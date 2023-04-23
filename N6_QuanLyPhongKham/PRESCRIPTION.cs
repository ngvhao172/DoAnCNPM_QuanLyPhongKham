using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N6_QuanLyPhongKham
{
    internal class PRESCRIPTION
    {
        public string MaDonThuoc { get; set; }

        public string MaBenhNhan { get; set; }
        public string MaBacSi { get; set; }
        public string MaLichHen { get; set; }
        public DateTime NgayKeDon { get; set; }

        public string TongTien { get; set; }
    }
}
