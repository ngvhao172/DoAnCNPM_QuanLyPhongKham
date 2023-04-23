using DevExpress.XtraBars;

namespace N6_QuanLyPhongKham
{
    public partial class Mainform : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private Account acc = new Account();
        private Controller ct = new Controller();
        private string type;
        private string madonthuoc;
        public void setAccVal(string acs, string psd)
        {
            acc.SDT = acs;
            acc.MatKhau = psd;
            type = ct.ShowTypeAcc(acc);
        }
        public void setMadonthuoc(string madonthuoc)
        {
            this.madonthuoc = madonthuoc;
        }
        public Mainform()
        {
            InitializeComponent();
        }
        private void Mainform_Load(object sender, EventArgs e)
        {
            /*fr2 = new frmLogin();*/
            ///Phân chia các chức năng dựa vào visible
            ///
            if(!string.IsNullOrEmpty(type)) {
                if (type == "Bác sĩ")
                {
                    rbAdmin.Visible = false;
                    rbService.Visible = false;
                    rbStatistic.Visible = false;
                    rbFunction3.Visible = false;
                    rbFunction5.Visible = false;
                }
                if (type == "Bệnh nhân")
                {
                    rbAdmin.Visible = false;
                    rbSearch.Visible = false;
                    rbStatistic.Visible = false;
                    rbFunction.Visible = false;
                }
                if (type == "Nhân viên")
                {
                    rbAdmin2.Visible = false;
                    rbAdmin3.Visible = false;
                    rbAdmin4.Visible = false;
                    rbAdmin5.Visible = false;
                    rbAdmin6.Visible = false;
                    rbService.Visible = false;
                    rbStatistic.Visible = false;
                    rbFunction1.Visible = false;
                    rbFunction2.Visible = false;
                }
                if (type == "Kế toán")
                {
                    rbService.Visible = false;
                    rbFunction.Visible = false;
                    rbAdmin.Visible = false;
                }
            }
            else
            {
                btnInforP.Enabled = false;
                btnChangPsd.Enabled = false;
                btnRgApp.Enabled = false;
                btnHistoryApp.Enabled = false;
                btnKB.Enabled = false;
            }
            
        }
        private void btnInforP_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            InforOfUser iu = new InforOfUser();
            iu.setAccVal(acc.SDT, acc.MatKhau);
            iu.Dock = DockStyle.Fill;
            pnMain.Controls.Add(iu);
        }

        private void btnInfoA_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;

            InforOfAcc iu = new InforOfAcc();
            iu.Dock = DockStyle.Fill;
            pnMain.Controls.Add(iu);
        }

        private void btnChangPsd_ItemClick(object sender, ItemClickEventArgs e)
        {

            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            ChangePsd iu = new ChangePsd();
            iu.setAccVal(acc.SDT, acc.MatKhau);
            iu.Dock = DockStyle.Fill;
            pnMain.Controls.Add(iu);

        }
        private void btnListEm_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            EmployeeData dd = new EmployeeData();
            dd.Dock = DockStyle.Fill;
            pnMain.Controls.Add(dd);
        }
        private void btnListPa_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            PatientData pd = new PatientData();
            pd.Dock = DockStyle.Fill;
            pnMain.Controls.Add(pd);
        }

        private void btnRgApp_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;

            AppointmentSer aps = new AppointmentSer();
            aps.setAccVal(acc.SDT, acc.MatKhau);
            aps.Dock = DockStyle.Fill;
            pnMain.Controls.Add(aps);
        }

        private void btnService_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;

            ServicesData sd = new ServicesData();
            sd.Dock = DockStyle.Fill;
            pnMain.Controls.Add(sd);
        }

        private void btnListAppointment_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;

            ListAppointment la = new ListAppointment();
            la.Dock = DockStyle.Fill;
            pnMain.Controls.Add(la);
        }

        private void btnKB_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            listAppDoc lad = new listAppDoc();
            lad.setAccVal(acc.SDT, acc.MatKhau);
            lad.Dock = DockStyle.Fill;
            pnMain.Controls.Add(lad);
        }

        private void btnPreMedicine_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            prescriptionList pl = new prescriptionList();
            pl.setMadonthuoc(madonthuoc);
            pl.Dock = DockStyle.Fill;
            pnMain.Controls.Add(pl);
        }

        private void btnPrintPre_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            printPrescription pp = new printPrescription();
            pp.Dock = DockStyle.Fill;
            pnMain.Controls.Add(pp);
        }

        private void btnReceipt_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            ReceiptFill rc = new ReceiptFill();
            rc.setAccVal(acc.SDT, acc.MatKhau);
            rc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(rc);
        }

        private void btnStatPatient_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            statPatient sp  = new statPatient();
            sp.Dock = DockStyle.Fill;
            pnMain.Controls.Add(sp);
        }

        private void btnStatService_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            statService ss = new statService();
            ss.Dock = DockStyle.Fill;
            pnMain.Controls.Add(ss);
        }

        private void btnStatIncome_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            statIncome si = new statIncome();
            si.Dock = DockStyle.Fill;
            pnMain.Controls.Add(si);
        }

        private void btnHistoryApp_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            historyApp ha = new historyApp();
            ha.setAccVal(acc.SDT, acc.MatKhau);
            ha.Dock = DockStyle.Fill;
            pnMain.Controls.Add(ha);
        }

        private void btnSpec_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            SpecialityData sd = new SpecialityData();
            sd.Dock = DockStyle.Fill;
            pnMain.Controls.Add(sd);
        }

        private void btnSearchPatient_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            listPatientSearch lps = new listPatientSearch();
            lps.Dock = DockStyle.Fill;
            pnMain.Controls.Add(lps);
        }

        private void btnSearchDoctor_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Dock = DockStyle.Fill;
            listDoctorSearch lds = new listDoctorSearch();
            lds.Dock = DockStyle.Fill;
            pnMain.Controls.Add(lds);
        }
    }
}