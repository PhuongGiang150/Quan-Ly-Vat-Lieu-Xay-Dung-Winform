using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAnQLVatLieuXayDung
{
    public partial class Report : Form
    {
        public static string quyenloi;
        string strketnoi = @"Data Source=DESKTOP-EC413NT;Initial Catalog=DoAnQuanLyVLXD;Integrated Security=True";
        SqlConnection ketnoi = null;
        public void Openketnoi()
        {
            if (ketnoi == null) ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Closed) ketnoi.Open();
        }
        public void Closeketnoi()
        {
            if (ketnoi == null) ketnoi = new SqlConnection(strketnoi);
            if (ketnoi.State == ConnectionState.Open) ketnoi.Close();
        }
        //tạo dataset lưu dữ liệu sql
        public DataTable GetDataTable(string sql)
        {
            Openketnoi();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(sql, ketnoi);
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
        public Report()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            txtHD.Focus();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Openketnoi();
            DataTable dt = new DataTable();
            dt = GetDataTable("select HoaDon.MaHD,TenHD,TenKH,KhachHang.DiaChi,TenVL, SL,GiaBan,ThanhTien,NgayLap,TenNV from HoaDon,NhanVien,KhachHang,ChiTietHoaDon,VatLieu where  HoaDon.MaHD= ChiTietHoaDon.MaHD and HoaDon.MaKH= KhachHang.MaKH and HoaDon.MaNV= NhanVien.MaNV and ChiTietHoaDon.MaVL= VatLieu.MaVL and HoaDon.MaHD = '" + txtHD.Text + "'");
            ReportBill rp = new ReportBill();
            rp.SetDataSource(dt);
            BangReport.ReportSource = rp;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (hoi == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
