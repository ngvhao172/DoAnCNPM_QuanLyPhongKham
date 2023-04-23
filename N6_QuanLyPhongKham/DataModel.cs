using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Xpo.DB.Helpers;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace N6_QuanLyPhongKham
{
    internal class DataModel
    {
        private SqlConnection connection;
        string str = @"Data Source=DESKTOP-QK2LSSI\SQLEXPRESS;Initial Catalog=QLPK;Integrated Security=True; MultipleActiveResultSets=true";
        public DataModel()
        {
            connection = new SqlConnection(str);
        }
        /*Trả về id tự động tăng*/
        public string autoID(string s)
        {
            string autoID = "";
            string rolebrief = "";
            string query = "";
            if (s == "Bệnh nhân")
            {
                rolebrief = "BN";
                query = "Select top 1 MaBenhNhan from BenhNhan order by MaBenhNhan desc";
            }

            else if (s == "Bác sĩ")
            {
                rolebrief = "BS";
                query = "Select top 1 MaBacSi from BacSi order by MaBacSi desc";
            }

            else if (s == "Nhân viên")
            {
                rolebrief = "NV";
                query = "Select top 1 MaNhanVien from NhanVien order by MaNhanVien desc";
            }

            else if (s == "Kế toán")
            {
                rolebrief = "KT";
                query = "Select top 1 MaKeToan from KeToan order by MaKeToan desc";
            }
            else if (s == "Dịch vụ")
            {
                rolebrief = "DV";
                query = "Select top 1 MaDichVu from DichVu order by MaDichVu desc";
            }
            else if (s == "Thiết bị")
            {
                rolebrief = "TB";
                query = "Select top 1 MaThietBi from ThietBi order by MaThietBi desc";
            }
            else if (s.Contains("LH"))
            {
                rolebrief = s;
                query = "Select top 1 MaLichHen from LichHen order by MaLichHen desc";
            }
            else if (s == "Đơn thuốc")
            {
                rolebrief = "DT";
                query = "Select top 1 MaDonThuoc from DonThuoc order by MaDonThuoc desc";
            }
            else if (s == "Chi tiết đơn thuốc")
            {
                rolebrief = "CTDT";
                query = "Select top 1 MaChiTietDonThuoc from ChiTietDonThuoc order by MaChiTietDonThuoc desc";
            }
            else if (s == "Hóa đơn")
            {
                rolebrief = "HD";
                query = "Select top 1 MaHoaDon from HoaDon order by MaHoaDon desc";
            }
            using (SqlConnection connection = new SqlConnection(str))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string numberstr = (string)command.ExecuteScalar();
                    string nums = numberstr.Trim();
                    string subStr = nums.Substring(nums.Length - 4);
                    int num = Int32.Parse(subStr) + 1;
                    if (num < 10)
                        autoID = rolebrief + "000" + num.ToString();
                    else if (num < 100)
                        autoID = rolebrief + "00" + num.ToString();
                    else if (num < 1000)
                        autoID = rolebrief + "0" + num.ToString();
                    else
                        autoID = rolebrief + num.ToString();
                }
                else
                {
                    // handle case where no record is found or the result is not a valid integer
                    autoID = rolebrief + "0001";
                }

            }

            return autoID;

        }
        /*Thêm người dùng*/
        public void AddUser(User user, Account acc)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                SqlCommand command;

                string query = ""; //Them nhieu tac nhan
                if (acc.LoaiTaiKhoan == "Bệnh nhân")
                {
                    query = "INSERT INTO BenhNhan (MaBenhNhan, HoTen, SDT, NgaySinh, GioiTinh, Email, DiaChi) " +
                    "VALUES (@ID, @HoTen, @SDT, @NgaySinh, @GioiTinh, @Email, @DiaChi)";
                }
                else if (acc.LoaiTaiKhoan == "Bác sĩ")
                {
                    query = "INSERT INTO BacSi (MaBacSi, HoTen, SDT, NgaySinh, GioiTinh, MaKhoa, Luong, DiaChi) " +
                   "VALUES (@ID, @HoTen, @SDT, @NgaySinh, @GioiTinh, @MaKhoa,@Luong,@DiaChi)";
                }
                else if (acc.LoaiTaiKhoan == "Nhân viên")
                {
                    query = "INSERT INTO NhanVien (MaNhanVien, HoTen, SDT, NgaySinh, GioiTinh, Luong, DiaChi) " +
                   "VALUES (@ID, @HoTen, @SDT, @NgaySinh, @GioiTinh,@Luong,@DiaChi)";

                }
                else if (acc.LoaiTaiKhoan == "Kế toán")
                {
                    query = "INSERT INTO KeToan (MaKeToan, HoTen, SDT, NgaySinh, GioiTinh, Luong, DiaChi) " +
                   "VALUES (@ID, @HoTen, @SDT, @NgaySinh, @GioiTinh,@Luong,@DiaChi)";

                }
                string query3 = "SELECT COUNT(*) FROM TaiKhoan where SDT = @SDT";
                connection.Open();
                SqlCommand command3 = new SqlCommand(query3, connection);
                command3.Parameters.AddWithValue("@SDT", user.SDT);
                int rowsAffected = (int)command3.ExecuteScalar();
                if (rowsAffected == 0)
                {
                    string query2 = "INSERT INTO TaiKhoan (SDT, MatKhau, LoaiTaiKhoan) VALUES (@SDT,@MatKhau,@LoaiTaiKhoan)";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", autoID(acc.LoaiTaiKhoan));
                    command.Parameters.AddWithValue("@HoTen", user.HoTen);
                    command.Parameters.AddWithValue("@SDT", user.SDT);
                    command.Parameters.AddWithValue("@NgaySinh", user.NgaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", user.GioiTinh);
                    command.Parameters.AddWithValue("@Email", "");
                    command.Parameters.AddWithValue("@DiaChi", "");
                    command.Parameters.AddWithValue("@MaKhoa", user.MaKhoa);
                    command.Parameters.AddWithValue("@Luong", user.Luong);


                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@SDT", acc.SDT);
                    command2.Parameters.AddWithValue("@MatKhau", acc.MatKhau);
                    command2.Parameters.AddWithValue("@LoaiTaiKhoan", acc.LoaiTaiKhoan);

                    command2.ExecuteNonQuery();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                else
                {
                    MessageBox.Show("SDT đã được đăng ký");
                }
            }
        }
        /*login code*/
        public string Login(Account acc)
        {
            string stri = "";
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "Select * from TaiKhoan where SDT = '" + acc.SDT + "'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                if (command.ExecuteReader().Read())
                {
                    connection.Close();
                    stri = "exist";
                }
                if (stri == "exist")
                {
                    string query2 = "Select * from TaiKhoan where SDT = '" + acc.SDT + "' and MatKhau = '" + acc.MatKhau + "'";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    connection.Open();
                    if (command2.ExecuteReader().Read())
                    {
                        connection.Close();
                        stri = "success";
                    }
                    else
                    {
                        stri = "failed";
                    }
                }
                else
                {
                    stri = "notexist";
                }
                connection.Close();
                return stri;

            }
        }
        /*Đổi mật khẩu*/
        public void ChangePsd(string newPsd, Account acc)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "Update TaiKhoan set MatKhau = '" + newPsd + "' where SDT = '" + acc.SDT + "'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Trả về thông tin cá nhân*/
        public User ShowInfo(Account acc, string bang)
        {

            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT * FROM " + bang + " WHERE SDT = @sdt";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@sdt", acc.SDT);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                User us = null;
                if (reader.Read())
                {
                    us = new User();
                    us.ID = reader.GetString(0);
                    us.HoTen = reader.GetString(1);
                    us.SDT = reader.GetString(2);
                    us.NgaySinh = reader.GetDateTime(3);
                    us.GioiTinh = reader.GetString(4);
                    if (bang == "BenhNhan")
                    {
                        us.Email = reader.IsDBNull(5) ? " " : reader.GetString(5);
                        us.DiaChi = reader.IsDBNull(6) ? " " : reader.GetString(6);
                    }
                    else if (bang == "BacSi")
                    {
                        us.Luong = reader.GetDecimal(5).ToString();
                        us.MaKhoa = reader.GetString(6);
                        us.DiaChi = reader.IsDBNull(7) ? " " : reader.GetString(7);
                    }
                    else
                    {
                        us.Luong = reader.GetDecimal(5).ToString();
                        us.DiaChi = reader.IsDBNull(6) ? " " : reader.GetString(6);
                    }

                }

                connection.Close();
                return us;
            }
        }
        /*Trả về loại account: bác sĩ, nhân viên, bệnh nhân, kế toán*/
        public string ShowTypeAccount(Account acc)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT LoaiTaiKhoan FROM TaiKhoan WHERE SDT = @sdt";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@sdt", acc.SDT);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                string type = "";
                if (reader.Read())
                {
                    type = reader.GetString(0);
                }

                connection.Close();
                return type;
            }
        }
        /*Trả về giá trị của bảng kèm theo 1 điều kiện*/
        public DataTable loadData(string s, string dk1, string dk2)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT * FROM " + s + " WHERE " + dk1 + "=@dk2";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@dk2", dk2);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }
        /*Trả về danh sách với điều kiện like*/
        public DataTable loadData5(string s, string dk1, string dk2)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT * FROM " + s + " WHERE " + dk1 + " like @dk2";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@dk2", dk2);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }
        /*Trả về thông tin từ bảng ChiTietHoaDon*/
        public DataTable loadPreDetail(string s)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT MaChiTietDonThuoc,TenThuoc,LieuLuong,SoLuong,TanSuat, GiaTien FROM ChiTietDonThuoc WHERE MaDonThuoc =@madonthuoc";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@madonthuoc", s);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }
        /*Trả về lịch hẹn của bệnh nhân có id và trạng thai chưa xác nhận (0) và xác nhận(1)*/
        public DataTable loadData2(string s, string dk1, string dk2, string sid)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT * FROM " + s + " WHERE (TrangThai =@dk1 or TrangThai =@dk2) and MaBenhNhan=@id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@dk1", dk1);
                command.Parameters.AddWithValue("@dk2", dk2);
                command.Parameters.AddWithValue("@id", sid);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }
        /*Trả về thông tin dưới dạng bảng có nhiều điều kiện*/
        public DataTable loadData3(string s, string dk1, string dk2, string dk3, string dk4)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT * FROM " + s + " WHERE " + dk1 + "=@dk2 and " + dk3 + "=@dk4";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@dk2", dk2);
                command.Parameters.AddWithValue("@dk4", dk4);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }

        /*Xoa tai khoan trong do: s la bang(rieng), id ma mabenhnhan hoac mabacsi(chung), sid cot dieu kien trong tung bang, sdt la sotaikhoan can xoa*/
        public void deleteUser(string bang, string id, string dkid, string sdt)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "DELETE FROM " + bang + " WHERE " + dkid + " = @id";
                string query2 = "DELETE FROM TAIKHOAN WHERE SDT=@sdt";
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand command2 = new SqlCommand(query2, connection);
                command.Parameters.AddWithValue("@id", id);
                command2.Parameters.AddWithValue("@sdt", sdt);

                connection.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                connection.Close();

            }
        }
        /*Thay đổi thông tin*/
        public void editUser(string bang, User user)
        {
            string query = "";
            if (bang == "BenhNhan")
            {
                query = "UPDATE BenhNhan set HoTen = @hoten, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, Email = @email, DiaChi = @diachi where MaBenhNhan =@id ";
            }
            else if (bang == "BacSi")
            {
                query = "UPDATE BacSi set HoTen = @hoten, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, Luong = @luong, MaKhoa = @makhoa, DiaChi = @diachi where MaBacSi =@id ";
            }
            else if (bang == "NhanVien")
            {
                query = "UPDATE NhanVien set HoTen = @hoten, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, Luong = @luong, DiaChi = @diachi where MaNhanVien =@id ";
            }
            else if (bang == "KeToan")
            {
                query = "UPDATE KeToan set HoTen = @hoten, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, Luong = @luong, DiaChi = @diachi where MaKeToan =@id ";
            }
            using (SqlConnection connection = new SqlConnection(str))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", user.ID);
                command.Parameters.AddWithValue("@hoten", user.HoTen);
                command.Parameters.AddWithValue("@sdt", user.SDT);
                command.Parameters.AddWithValue("@ngaysinh", user.NgaySinh);
                command.Parameters.AddWithValue("@gioitinh", user.GioiTinh);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@diachi", user.DiaChi);
                command.Parameters.AddWithValue("@luong", user.Luong);
                command.Parameters.AddWithValue("@makhoa", user.MaKhoa);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Thay đổi thông tin cá nhân nhân viên*/
        public void editEmployeeInfo(string bang, User user)
        {
            string query = "";
            if (bang == "BacSi")
            {
                query = "UPDATE BacSi set HoTen = @hoten, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, DiaChi = @diachi where MaBacSi =@id ";
            }
            else if (bang == "NhanVien")
            {
                query = "UPDATE NhanVien set HoTen = @hoten, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, DiaChi = @diachi where MaNhanVien =@id ";
            }
            else if (bang == "KeToan")
            {
                query = "UPDATE KeToan set HoTen = @hoten, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, SDT = @sdt, DiaChi = @diachi where MaKeToan =@id ";
            }
            using (SqlConnection connection = new SqlConnection(str))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", user.ID);
                command.Parameters.AddWithValue("@hoten", user.HoTen);
                command.Parameters.AddWithValue("@sdt", user.SDT);
                command.Parameters.AddWithValue("@ngaysinh", user.NgaySinh);
                command.Parameters.AddWithValue("@gioitinh", user.GioiTinh);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@diachi", user.DiaChi);
                command.Parameters.AddWithValue("@makhoa", user.MaKhoa);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Thêm dịch vụ*/
        public void addService(Services ser)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "INSERT INTO DichVu values (@id,@tendichvu,@giadichvu,@makhoa)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", autoID("Dịch vụ"));
                command.Parameters.AddWithValue("@tendichvu", ser.TenDichVu);
                command.Parameters.AddWithValue("@giadichvu", ser.GiaDichVu);
                command.Parameters.AddWithValue("@makhoa", ser.MaKhoa);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Xóa dịch vụ*/
        public void deleteService(string id)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "DELETE From DichVu where MaDichVu = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Sửa dịch vụ*/
        public void editService(Services s)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "UPDATE DichVu set TenDichVu = @tendichvu, GiaDichvu = @giadichvu, MaKhoa = @makhoa where MaDichVu = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", s.MaDichVu);
                command.Parameters.AddWithValue("@tendichvu", s.TenDichVu);
                command.Parameters.AddWithValue("@giadichvu", s.GiaDichVu);
                command.Parameters.AddWithValue("@makhoa", s.MaKhoa);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Thêm lịch hẹn*/
        public void addAppDate(Appointment app)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT COUNT(*) FROM LichHen WHERE NgayHen = @NgayHen AND GioHen = @GioHen";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ngayhen", app.NgayHen.ToString("d"));
                command.Parameters.AddWithValue("@giohen", app.GioHen);
                connection.Open();
                int rowsAffected = (int)command.ExecuteScalar();
                if (rowsAffected >= 1)
                {
                    MessageBox.Show("Bạn đã có lịch hẹn vào ngày " + app.NgayHen.ToString("dd-MM-yyyy") + " vào " + app.GioHen.ToString() + ". Hãy chọn lại giờ hẹn khác hoặc vào ngày khác.");
                }
                else
                {
                    string query2 = "INSERT INTO LichHen (MaLichHen, MaBenhNhan, MaBacSi, MaDichVu, NgayHen, GioHen, TrangThai, MoTa) VALUES (@id, @mabenhnhan, @mabacsi, @madichvu, @ngayhen, @giohen, @trangthai, @mota) ";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@id", autoID("LH" + app.NgayHen.ToString("yyyyMMdd")));
                    command2.Parameters.AddWithValue("@mabenhnhan", app.MaBenhNhan);
                    command2.Parameters.AddWithValue("@mabacsi", app.MaBacSi);
                    command2.Parameters.AddWithValue("@madichvu", app.MaDichVu);
                    command2.Parameters.AddWithValue("@ngayhen", app.NgayHen.ToString("yyyy-MM-dd"));
                    command2.Parameters.AddWithValue("@giohen", app.GioHen.ToString());
                    command2.Parameters.AddWithValue("@trangthai", app.TrangThai);
                    command2.Parameters.AddWithValue("@mota", app.MoTa);
                    command2.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký thành công");
                }
                connection.Close();
            }
        }
        /*Hủy lịch hẹn*/
        public void delAppDate(string id)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "DELETE From LichHen where MaLichHen = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Update trạng thái bệnh nhân*/
        public void changeState(string id, string state)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "Update LichHen set TrangThai = @state where MaLichHen = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@state", state);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Thêm hóa đơn*/
        public string addPrescription(PRESCRIPTION pre)
        {
            string mahoadon = autoID("Đơn thuốc");
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "INSERT INTO DonThuoc values (@madonthuoc,@mabenhnhan, @mabacsi, @malichhen, @ngaykedon, @tongtien)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@madonthuoc", mahoadon);
                command.Parameters.AddWithValue("@mabenhnhan", pre.MaBenhNhan);
                command.Parameters.AddWithValue("@mabacsi", pre.MaBacSi);
                command.Parameters.AddWithValue("@malichhen", pre.MaLichHen);
                command.Parameters.AddWithValue("@ngaykedon", pre.NgayKeDon);
                command.Parameters.AddWithValue("@tongtien", pre.TongTien);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return mahoadon;
        }
        /*Trả về tiền dịch vụ*/
        public string getMoneyService(string id)
        {
            string giaTien = "";
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT GiaDichVu from DichVu where MaDichVu = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) // Kiểm tra giá trị trả về có null không
                {
                    giaTien = Convert.ToString(result); // Chuyển đổi giá trị trả về thành string                                                 
                }
                connection.Close();
            }
            return giaTien;
        }

        /*Thêm chi tiết đơn thuốc*/
        public void addPrescriptionDetail(prescriptionDetail pred)
        {
            string machitiet = autoID("Chi tiết đơn thuốc");
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "INSERT INTO ChiTietDonThuoc values (@machitiet,@madonthuoc,@tenthuoc, @lieuluong, @soluong, @tuansuat, @giatien)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@machitiet", machitiet);
                command.Parameters.AddWithValue("@madonthuoc", pred.maDonThuoc);
                command.Parameters.AddWithValue("@tenthuoc", pred.tenThuoc);
                command.Parameters.AddWithValue("@lieuluong", pred.lieuLuong);
                command.Parameters.AddWithValue("@soluong", pred.soLuong);
                command.Parameters.AddWithValue("@tuansuat", pred.tanSuat);
                command.Parameters.AddWithValue("@giatien", pred.giaTien);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /*Trả về đơn thuốc*/
        public DataTable loadPrescription(string from, string to)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "select o.MaDonThuoc, b.HoTen as BacSi, c.MaBenhNhan, c.HoTen as BenhNhan,  C. SDT, o.NgayKeDon " +
                                         "from DonThuoc o inner join BenhNhan c on o.MaBenhNhan = c.MaBenhNhan inner join BacSi b on o.MaBacSi = b.MaBacSi " +
                                         "where o.NgayKeDon between @fromdate AND @todate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fromdate", from);
                command.Parameters.AddWithValue("@todate", to);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }
        /*Trả về danh sách chi tiết đơn thuốc*/

        public void editPrescriptionDetail(string id, string price)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "UPDATE ChiTietDonThuoc set GiaTien = @giatien where MaChiTietDonThuoc = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@giatien", price);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /*Trả về tổng tiền hóa đơn*/
        public string getTotal(string id)
        {
            string giaTien = "";
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT SUM(TotalCost) AS GrandTotal " +
                    "FROM (SELECT GiaTien AS TotalCost FROM ChiTietDonThuoc WHERE MaDonThuoc = @madonthuoc " +
                    "UNION ALL SELECT GiaDichVu FROM DichVu WHERE MaDichVu = (SELECT MaDichVu FROM LichHen  " +
                    "WHERE MaLichHen = (SELECT MaLichHen FROM DonThuoc WHERE MaDonThuoc = @madonthuoc))) AS SubQuery;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@madonthuoc", id);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) // Kiểm tra giá trị trả về có null không
                {
                    giaTien = Convert.ToString(result); // Chuyển đổi giá trị trả về thành string                                                 
                }
                connection.Close();
            }
            return giaTien;
        }
        /*Thêm hóa đơn*/
        public void addReceipt(RECEIPT r)
        {
            string mahoadon = autoID("Hóa đơn");
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "INSERT INTO HoaDon values (@mahoadon,@madonthuoc,@tongtien,@ngaylap)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mahoadon", mahoadon);
                command.Parameters.AddWithValue("@madonthuoc", r.maDonThuoc);
                command.Parameters.AddWithValue("@ngaylap", r.ngayLap);
                command.Parameters.AddWithValue("@tongtien", r.tongTien);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Trả về tên bệnh nhân*/
        public string getInforOfPa(string madonthuoc)
        {
            string tenBenhNhan = "";
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT BenhNhan.HoTen " +
                    "FROM DonThuoc JOIN BenhNhan ON DonThuoc.MaBenhNhan = BenhNhan.MaBenhNhan " +
                    "WHERE DonThuoc.MaDonThuoc = @madonthuoc";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@madonthuoc", madonthuoc);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) // Kiểm tra giá trị trả về có null không
                {
                    tenBenhNhan = Convert.ToString(result); // Chuyển đổi giá trị trả về thành string                                                 
                }
                connection.Close();
            }
            return tenBenhNhan;
        }
        /*Trả về thông tin dịch vụ đã sử dụng*/
        public DataTable getInforOfSer(string madonthuoc)
        {

            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT TenDichVu, GiaDichVu FROM DichVu WHERE MaDichVu = (SELECT MaDichVu FROM LichHen  " +
                "WHERE MaLichHen = (SELECT MaLichHen FROM DonThuoc WHERE MaDonThuoc = @madonthuoc))";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@madonthuoc", madonthuoc);
                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }
        /*Trả về thông tin của hóa đơn*/
        public RECEIPT getInforReceipt(string madonthuoc)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT * from HoaDon WHERE MaDonThuoc = @madonthuoc";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@madonthuoc", madonthuoc);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                RECEIPT rc = null;
                if (reader.Read())
                {
                    rc = new RECEIPT();
                    rc.maHoaDon = reader.GetString(0);
                    rc.maDonThuoc = reader.GetString(1);
                    rc.tongTien = reader.GetDecimal(2).ToString();
                    rc.ngayLap = reader.GetDateTime(3);
                }
                connection.Close();
                return rc;
            }
        }

        /*Thống kê bệnh nhân*/
        public DataTable loadInforOfApp(string from, string to)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "select BenhNhan.MaBenhNhan, BenhNhan.HoTen, BenhNhan.SDT, BenhNhan.NgaySinh, " +
                    "BenhNhan.GioiTinh, LichHen.NgayHen, LichHen.GioHen from BenhNhan inner join LichHen on " +
                    "LichHen.MaBenhNhan = BenhNhan.MaBenhNhan where LichHen.NgayHen between " +
                    "@fromdate and @todate and LichHen.TrangThai = 2";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fromdate", from);
                command.Parameters.AddWithValue("@todate", to);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;

            }
        }
        /*Thống kê dịch vụ*/
        public DataTable loadInforOfService(string from, string to)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "SELECT DichVu.MaDichVu, DichVu.TenDichVu, COUNT(*) AS SoLanXuatHien" +
                    " FROM DichVu INNER JOIN LichHen ON LichHen.MaDichVu = DichVu.MaDichVu  WHERE LichHen.NgayHen " +
                    "BETWEEN @fromdate AND @todate AND LichHen.TrangThai = 2  GROUP BY DichVu.MaDichVu, DichVu.TenDichVu";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fromdate", from);
                command.Parameters.AddWithValue("@todate", to);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }
        /*Thống kê thu chi*/
        public DataTable loadInforOfIncome(string from, string to)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "Select HoaDon.MaHoaDon, HoaDon.TongTien, HoaDon.NgayLap from HoaDon where HoaDon.NgayLap BETWEEN @fromdate AND @todate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fromdate", from);
                command.Parameters.AddWithValue("@todate", to);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }
        /*Trả về lịch sử khám*/
        public DataTable loadHistoryApp(string mabenhnhan)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "Select DichVu.MaDichVu, DichVu.TenDichVu, NgayHen from LichHen inner join DichVu on DichVu.MaDichVu = LichHen.MaDichVu where LichHen.MaBenhNhan = @mabenhnhan and LichHen.TrangThai = '2'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mabenhnhan", mabenhnhan);

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                connection.Close();
                return dataTable;
            }
        }
        /*Thêm khoa*/
        public void addSpeciality(Khoa k)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "INSERT INTO Khoa values (@makhoa,@tenkhoa)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@makhoa", k.MaKhoa);
                command.Parameters.AddWithValue("@tenkhoa", k.TenKhoa);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        /*Xóa khoa*/
        public void deleteSpeciality(string makhoa)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                string query = "DELETE FROM Khoa WHERE MaKhoa = @makhoa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@makhoa", makhoa);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
