using System.Data;

namespace N6_QuanLyPhongKham
{
    internal class Controller
    {
        DataModel dm = new DataModel();
        public void AddUser(string fullname, string phone, DateTime dateOfBirth, string gender, string option,string address,string matkhau, string loaitaikhoan, string luong)
        {
            User user = new User();
            user.HoTen = fullname;
            user.GioiTinh = gender;
            user.NgaySinh = dateOfBirth;
            user.DiaChi = address;
            user.SDT = phone;
            user.Luong = luong;
            /*user.Email= option;*/
            user.MaKhoa = option;
            Account acc = new Account();
            acc.SDT = phone;
            acc.MatKhau = matkhau;
            acc.LoaiTaiKhoan = loaitaikhoan;

            dm.AddUser(user,acc);
        }
        public void deleteUser(string bang, string id, string dkid, string sdt)
        {
            dm.deleteUser(bang, id, dkid, sdt);
        }
        /*Thay đổi thông tin cá nhân*/
        public void editUser(string bang, string id, string fullname, string phone, DateTime dateOfBirth, string gender, string email, string makhoa, string address, string luong)
        {
            User user = new User();
            user.ID = id;
            user.HoTen = fullname;
            user.GioiTinh = gender;
            user.NgaySinh = dateOfBirth;
            user.DiaChi = address;
            user.SDT = phone;
            user.Luong = luong;
            user.Email = email;
            user.MaKhoa = makhoa;
            dm.editUser(bang, user);
        }
        /*Thay đổi thông tin cá nhân của nhân viên*/
        public void editEmployeeInfo(string bang, string id, string fullname, string phone, DateTime dateOfBirth, string gender, string email, string makhoa, string address, string luong)
        {
            User user = new User();
            user.ID = id;
            user.HoTen = fullname;
            user.GioiTinh = gender;
            user.NgaySinh = dateOfBirth;
            user.DiaChi = address;
            user.SDT = phone;
            user.Luong = luong;
            user.Email = email;
            user.MaKhoa = makhoa;
            dm.editEmployeeInfo(bang, user);
        }
        public string Login(string username, string password)
        {
            Account acc = new Account();
            acc.SDT = username;
            acc.MatKhau = password;

            return dm.Login(acc);
        }
        public void ChangePsd(string newPSd, Account acc )
        {
            dm.ChangePsd(newPSd, acc );
        }
        public User ShowInfo(Account acc,string bang)
        {
            User user = dm.ShowInfo(acc, bang);
            return user;
        }
        public string ShowTypeAcc(Account acc)
        {
            return dm.ShowTypeAccount(acc);
        }
        public DataTable loadFal()
        {
            return dm.loadData("Khoa","1","1");
        }
        public DataTable loadPatient()
        {
            return dm.loadData("BenhNhan", "1", "1");
        }
        public DataTable loadPatientwithCondition(string id)
        {
            return dm.loadData("BenhNhan", "MaBenhNhan", id.ToUpper());
        }
        public DataTable loadPatientwithCondition2(string name)
        {
            return dm.loadData5("BenhNhan", "HoTen", "%"+name+"%");
        }
        public DataTable loadDoctor()
        {
            return dm.loadData("BacSi", "1", "1");
        }
        public DataTable loadDoctorwithCondition(string id)
        {
            return dm.loadData("BacSi", "MaBacSi", id.ToUpper());
        }
        public DataTable loadDoctorwithCondition2(string name)
        {
            return dm.loadData5("BacSi", "HoTen", "%"+name+"%");
        }
        public DataTable loadEmployee()
        {
            return dm.loadData("NhanVien", "1", "1");
        }
        public DataTable loadAccountant()
        {
            return dm.loadData("KeToan", "1", "1");
        }
        public DataTable loadServices()
        {
            return dm.loadData("DichVu", "1", "1");
        }
        public DataTable loadDoctor(string s)
        {
            return dm.loadData("BacSi", "MaKhoa", s);
        }
        public DataTable loadServices(string s)
        {
            return dm.loadData("DichVu", "MaKhoa", s);
        }
        /*load danh sách chi tiết đơn thuốc*/
        public DataTable loadPreDetail(string s)
        {
            return dm.loadPreDetail( s);
        }

        /*load danh sách các lịch hẹn đã đăng ký ở trạng thái xác nhận(1) và chưa xác nhận (0)*/
        public DataTable loadAppRegister(string id)
        {
            return dm.loadData2("LichHen", "0", "1", id);
        }
        /*Trả về tất cả các lịch hẹn trên hệ thống*/
        public DataTable loadListApp()
        {
            return dm.loadData("LichHen", "1", "1");
        }

        /*Trả về lịch hẹn đối với từng bác sĩ trên hệ thống và có trạng thái là xác nhận (1)*/
        public DataTable loadListAppDoc(string id)
        {
            return dm.loadData3("LichHen", "MaBacSi", id,"TrangThai","1");
        }
        /*Trả về danh sách hóa đơn từ ngày x đến ngày y*/
        public DataTable loadPrescription(string from, string to)
        {
            return dm.loadPrescription(from, to);
        }
        /*Thêm dịch vụ*/
        public void addService(string tendichvu,string giadichvu, string makhoa)
        {
            Services s = new Services();
            s.TenDichVu = tendichvu;
            s.GiaDichVu = giadichvu;
            s.MaKhoa= makhoa;
            dm.addService(s);
        }
        /*Xóa dịch vụ*/
        public void delService(string id)
        {
            dm.deleteService(id);
        }
        /*Sửa dịch vụ*/
        public void editService(string id, string tendichvu, string giadichvu, string makhoa)
        {
            Services s = new Services();
            s.MaDichVu = id;
            s.TenDichVu= tendichvu;
            s.GiaDichVu = giadichvu;
            s.MaKhoa = makhoa;
            dm.editService(s);
        }
        /*Thêm lịch hẹn*/
        public void addAppDate(string mabenhnhan,string mabacsi, string madichvu, DateTime ngayhen, TimeSpan giohen, int trangthai, string mota)
        {
            Appointment app = new Appointment();
            app.MaBenhNhan = mabenhnhan;
            app.MaBacSi= mabacsi;
            app.MaDichVu = madichvu;
            app.NgayHen = ngayhen;
            app.GioHen = giohen;
            app.TrangThai = trangthai;
            app.MoTa = mota;

            dm.addAppDate(app);
        }
        /*Xóa lịch hẹn*/
        public void delAppDate(string id)
        {
            dm.delAppDate(id);
        }
        /*Chuyển trạng thái 0(chưa xác nhận) sang trạng thái 1 (xác nhận)*/
        public void updateConfirmState(string id)
        {
            dm.changeState(id, "1");
        }
        /*Chuyển trạng thái 1(xác nhận) sang trạng thái 2(hoàn thành)*/
        public void updateCompleteState(string id)
        {
            dm.changeState(id, "2");
        }
        /*Thêm đơn thuốc*/
        public string addPres(string mabenhnhan, string mabacsi, string malichhen, DateTime ngaykedon, string tongtien)
        {
            PRESCRIPTION pre = new PRESCRIPTION();
            pre.MaBenhNhan= mabenhnhan;
            pre.MaBacSi = mabacsi;
            pre.MaLichHen = malichhen;
            pre.NgayKeDon = ngaykedon;
            pre.TongTien = tongtien;
            return dm.addPrescription(pre);
        }
        /*trả về giá tiền của dịch vụ*/
        public string getMoneyService(string id)
        {
            return dm.getMoneyService(id);
        }
        /*Thêm chi tiết đơn thuốc*/
        public void addPrescriptionDetail(string madonthuoc, string tenthuoc, string lieuluong, string soluong, string tuansuat, string giatien)
        {
            prescriptionDetail pred = new prescriptionDetail();
            pred.maDonThuoc= madonthuoc;
            pred.tenThuoc= tenthuoc;
            pred.lieuLuong= lieuluong;
            pred.soLuong= soluong;
            pred.tanSuat= tuansuat;
            pred.giaTien= giatien;
            dm.addPrescriptionDetail(pred);

        }
        /*Thay đổi chi tiết đơn thuốc*/
        public void editPrescriptionDetail(string id, string price)
        {
            dm.editPrescriptionDetail(id,price);
        }
        /*Trả về total hóa đơn*/
        public string getTotal(string madonthuoc)
        {
            return dm.getTotal(madonthuoc);
        }
        /*Thêm hóa đơn*/
        public void addReceipt(string madonthuoc, DateTime ngaylap, string tongTien)
        {
            RECEIPT r = new RECEIPT();
            r.maDonThuoc = madonthuoc;
            r.ngayLap = ngaylap;
            r.tongTien = tongTien; 
            dm.addReceipt(r);
        }
        /*Lấy thông tin bệnh nhân*/
        public string getName(string madonthuoc)
        {
            return dm.getInforOfPa(madonthuoc);
        }
        /*Trả về thông tin của dịch vụ*/
        public DataTable getInforOfSer(string madonthuoc)
        {
            return dm.getInforOfSer(madonthuoc);
        }
        /*Trả về thông tin của hóa đơn*/
        public RECEIPT getInforOfReceipt(string madonthuoc)
        {
            return dm.getInforReceipt(madonthuoc);
        }
        /*Trả về số lượng bệnh nhân từ ngày x tới ngày y*/
        public DataTable getAppfromto(string from, string to)
        {
            return dm.loadInforOfApp(from,to);
        }
        /*Trả về số lượng dịch vụ từ ngày x tới ngày y*/
        public DataTable getSerfromto(string from, string to)
        {
            return dm.loadInforOfService(from, to);
        }
        /*Trả về số lượng hóa đơn từ ngày x tới ngày y*/
        public DataTable getIncomefromto(string from, string to)
        {
            return dm.loadInforOfIncome(from, to);
        }
        /*Trả về lịch sử khám bệnh*/
        public DataTable loadHistoryApp(string mabenhnhan)
        {
            return dm.loadHistoryApp(mabenhnhan);
        }
        /*Thêm khoa*/
        public void addSpeciality(string makhoa, string tenkhoa)
        {
            Khoa k = new Khoa();
            k.MaKhoa = makhoa;
            k.TenKhoa = tenkhoa;
            dm.addSpeciality(k);
        }
        /*Xóa khoa*/
        public void deleteSpeciality(string makhoa)
        {
            dm.deleteSpeciality(makhoa);
        }
    }
}
