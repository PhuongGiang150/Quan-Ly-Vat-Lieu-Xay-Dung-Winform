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
    public partial class XemThongTin : Form
    {

        string strketnoi = @"Data Source=DESKTOP-EC413NT;Initial Catalog=DoAnQuanLyVLXD;Integrated Security=True";
        SqlConnection ketnoi = null;
        public XemThongTin()
        {
            InitializeComponent();
        }
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
        public DataSet GetDataSet(string sql)
        {
            Openketnoi();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(sql, ketnoi);
            da.Fill(ds);
            return ds;
        }

          private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTT.Text = "DANH SÁCH NHÂN VIÊN";
            DataSet ds = new DataSet();
            string sql = "select MaNV as[Mã Nhân Viên] , TenNV as[Tên Nhân Viên] , DiaChi as[Địa Chỉ], SDT as [Số Điện Thoại], Luong as [Lương] , CongViec as [Công Việc]  from NhanVien";
            ds = GetDataSet(sql);
            BangXemThongTin.DataSource = ds.Tables[0];
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTT.Text = "DANH SÁCH KHÁCH HÀNG";
            DataSet ds = new DataSet();
            string sql = "select MaKH as[Mã Khách Hàng] , TenKH as[Tên Khách Hàng] ,DiaChi as[Địa Chỉ] , SDT as[Số Điện Thoại], Diem as[Điểm] from KhachHang";
            ds = GetDataSet(sql);
            BangXemThongTin.DataSource = ds.Tables[0];
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTT.Text = "DANH SÁCH NHÀ CUNG CẤP";
            DataSet ds = new DataSet();
            string sql = "select MaNCC as[Mã Nhà Cung Cấp] , TenNCC as[Tên Nhà Cung Cấp], DiaChi as [Địa Chỉ] ,  SDT as [Số Điện Thoại], Website as [Trang Web] from NhaCungCap";
            ds = GetDataSet(sql);
            BangXemThongTin.DataSource = ds.Tables[0];
        }

        private void vậtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTT.Text = "DANH SÁCH VẬT LIỆU";
            DataSet ds = new DataSet();
            string sql = "select MaVL as [Mã Vật Liệu], TenVL as[Tên Vật Liệu], DvTinh as[Đơn Vị Đo], GiaNhap as[Giá Nhập], Loai as[Loại Vật Liệu] , MaNCC as [Mã Nhà Cung Cấp] from VatLieu";
            ds = GetDataSet(sql);
            BangXemThongTin.DataSource = ds.Tables[0];
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
