using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N6_QuanLyPhongKham
{
    internal class User
    {
        public string ID { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; } /*benh nhan only*/

        public string MaKhoa { get; set; } /*bac si only*/

        public string Luong { get; set; } /*bac si + nhan vien*/
    }
}
