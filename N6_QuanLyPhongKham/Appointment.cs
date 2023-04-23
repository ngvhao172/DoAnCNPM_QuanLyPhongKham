using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N6_QuanLyPhongKham
{
    internal class Appointment
    {
        public string MaLichHen { get; set; }
        public string MaBacSi { get; set; }
        public string MaBenhNhan { get; set; }
        public string MaDichVu { get; set; }
        public DateTime NgayHen { get; set; }   
        public TimeSpan GioHen { get; set; }
        public int TrangThai { get; set; } /*0: chưa xác nhận, 1: đã xác nhận, 2: hoàn thành, 3: hủy */
        public string MoTa { get; set; }

    }
}
