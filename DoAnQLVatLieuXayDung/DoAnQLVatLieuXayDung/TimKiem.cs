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
    public partial class TimKiem : Form
    {
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
        public DataSet GetDataSet(string sql)
        {
            Openketnoi();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(sql, ketnoi);
            da.Fill(ds);
            return ds;
        }
        public TimKiem()
        {
            InitializeComponent();
        }
        private void txtTTKH_TextChanged(object sender, EventArgs e)
        {
            if (raSeachKHName.Checked == false && raSeachKHDC.Checked == false && raSeachKHLoai.Checked == false)
            {
                MessageBox.Show("Bạn Chưa Chọn Yêu Cầu Tìm Kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            lblBangTTTimKiem.Text = "Danh Sách Khách Hàng Đã Tìm Ra";
            if (raSeachKHName.Checked == true)
            {
                DataSet ds1 = new DataSet();
                ds1 = GetDataSet("select * from KhachHang where TenKH like N'%" + txtTTKH.Text + "%'");

                BangThongTinTimKiem.DataSource = ds1.Tables[0];
            }
            if (raSeachKHDC.Checked == true)
            {
                DataSet ds2 = new DataSet();
                ds2 = GetDataSet("select * from KhachHang where DiaChi like N'%" + txtTTKH.Text + "%'");

                BangThongTinTimKiem.DataSource = ds2.Tables[0];
            }
            if (raSeachKHLoai.Checked == true)
            {
                DataSet ds3 = new DataSet();
                ds3 = GetDataSet("select * from KhachHang where MaKH like N'%" + txtTTKH.Text + "%'");

                BangThongTinTimKiem.DataSource = ds3.Tables[0];
            }
            }

        }

        private void txtTTNV_TextChanged(object sender, EventArgs e)
        {
            if (raSeachNVName.Checked == false && raSeachNVDiaChi.Checked == false && raSeachNVCV.Checked == false)
            {
                
                MessageBox.Show("Bạn Chưa Chọn Yêu Cầu Tìm Kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            lblBangTTTimKiem.Text = "Danh Sách Nhân Viên Đã Tìm Ra";
            if (raSeachNVName.Checked == true)
            {
                DataSet ds1 = new DataSet();
                ds1 = GetDataSet("select * from NhanVien where TenNV like N'%" + txtTTNV.Text + "%'");

                BangThongTinTimKiem.DataSource = ds1.Tables[0];
            }
            if (raSeachNVDiaChi.Checked == true)
            {
                DataSet ds2 = new DataSet();
                ds2 =GetDataSet("select * from NhanVien where DiaChi like N'%" + txtTTNV.Text + "%'");

                BangThongTinTimKiem.DataSource = ds2.Tables[0];
            }
            if (raSeachNVCV.Checked == true)
            {
                DataSet ds3 = new DataSet();
                ds3 = GetDataSet("select * from NhanVien where CongViec like N'%" + txtTTNV.Text + "%'");

                BangThongTinTimKiem.DataSource = ds3.Tables[0];
            }
            }

        }

        private void txtTTVL_TextChanged(object sender, EventArgs e)
        {
            if (raSeachVLName.Checked == false && raSeachVLDV.Checked == false && raSeachVLLoai.Checked == false && raSeachVLNCC.Checked ==false)
            {

                MessageBox.Show("Bạn Chưa Chọn Yêu Cầu Tìm Kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblBangTTTimKiem.Text = "Danh Sách Vật Liệu Đã Tìm Ra";
                if (raSeachVLName.Checked == true)
                {
                    DataSet ds1 = new DataSet();
                    ds1 = GetDataSet("select MaVL,TenVL,TenNCC,DvTinh,GiaNhap,Loai from VatLieu,NhaCungCap where VatLieu.MaNCC = NhaCungCap.MaNCC and TenVL like N'%" + txtTTVL.Text + "%'");

                    BangThongTinTimKiem.DataSource = ds1.Tables[0];
                }
                if (raSeachVLDV.Checked == true)
                {
                    DataSet ds2 = new DataSet();
                    ds2 = GetDataSet("select MaVL,TenVL,TenNCC,DvTinh,GiaNhap,Loai from VatLieu,NhaCungCap where VatLieu.MaNCC = NhaCungCap.MaNCC and DvTinh like N'%" + txtTTVL.Text + "%'");

                    BangThongTinTimKiem.DataSource = ds2.Tables[0];
                }
                if (raSeachVLLoai.Checked == true)
                {
                    DataSet ds3 = new DataSet();
                    ds3 = GetDataSet("select MaVL,TenVL,TenNCC,DvTinh,GiaNhap,Loai from VatLieu,NhaCungCap where VatLieu.MaNCC = NhaCungCap.MaNCC and Loai like N'%" + txtTTVL.Text + "%'");

                    BangThongTinTimKiem.DataSource = ds3.Tables[0];
                }
                if (raSeachVLNCC.Checked == true)
                {
                    DataSet ds4 = new DataSet();
                    ds4 = GetDataSet("select * from VatLieu where MaNCC like N'%" + txtTTVL.Text + "%'");

                    BangThongTinTimKiem.DataSource = ds4.Tables[0];
                }
            }
        }

        private void txtTTNCC_TextChanged(object sender, EventArgs e)
        {
            if (raSeachNCCTen.Checked == false && raSeachNCCDC.Checked == false)
            {
                MessageBox.Show("Bạn Chưa Chọn Yêu Cầu Tìm Kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            lblBangTTTimKiem.Text = "Danh Sách Nhà Cung Cấp Đã Tìm Ra";
            if (raSeachNCCTen.Checked == true)
            {
                DataSet ds1 = new DataSet();
                ds1 = GetDataSet("select * from NhaCungCap where TenNCC like N'%" + txtTTNCC.Text + "%'");

                BangThongTinTimKiem.DataSource = ds1.Tables[0];
            }
            if (raSeachNCCDC.Checked == true)
            {
                DataSet ds2 = new DataSet();
                ds2 =GetDataSet("select * from NhaCungCap where DiaChi like N'%" + txtTTNCC.Text + "%'");

                BangThongTinTimKiem.DataSource = ds2.Tables[0];
            }
            }
        }

        private void txtTTHD_TextChanged(object sender, EventArgs e)
        {
            if (raSeachHDVL.Checked == false && raSeachHDNV.Checked == false && raSeachHDKH.Checked == false && raSeachHDNCC.Checked == false)
            {

                MessageBox.Show("Bạn Chưa Chọn Yêu Cầu Tìm Kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblBangTTTimKiem.Text = "Danh Sách Hóa Đơn Đã Tìm Ra";
                if (raSeachHDVL.Checked == true)
                {
                    DataSet ds1 = new DataSet();
                    ds1 = GetDataSet("select HoaDon.MaHD, TenHD,TenNV,TenKH,TenVL,TenNCC,SL,GiaBan,NgayLap from HoaDon,ChiTietHoaDon,KhachHang,VatLieu,NhanVien,NhaCungCap where HoaDon.MaHD =ChiTietHoaDon.MaHD and HoaDon.MaNV= NhanVien.MaNV and HoaDon.MaKH = KhachHang.MaKH and ChiTietHoaDon.MaVL= VatLieu.MaVL and VatLieu.MaNCC= NhaCungCap.MaNCC and VatLieu.TenVL like N'%" + txtTTHD.Text + "%'");

                    BangThongTinTimKiem.DataSource = ds1.Tables[0];
                }
                if (raSeachHDNV.Checked == true)
                {
                    DataSet ds2 = new DataSet();
                    ds2 = GetDataSet("select HoaDon.MaHD, TenHD,TenNV,TenKH,TenVL,TenNCC,SL,GiaBan,NgayLap from HoaDon,ChiTietHoaDon,KhachHang,VatLieu,NhanVien,NhaCungCap where HoaDon.MaHD =ChiTietHoaDon.MaHD and HoaDon.MaNV= NhanVien.MaNV and HoaDon.MaKH = KhachHang.MaKH and ChiTietHoaDon.MaVL= VatLieu.MaVL and VatLieu.MaNCC= NhaCungCap.MaNCC and NhanVien.TenNV like N'%" + txtTTHD.Text + "%'");

                    BangThongTinTimKiem.DataSource = ds2.Tables[0];
                }
                if (raSeachHDKH.Checked == true)
                {
                    DataSet ds3 = new DataSet();
                    ds3 = GetDataSet("select HoaDon.MaHD, TenHD,TenNV,TenKH,TenVL,TenNCC,SL,GiaBan,NgayLap from HoaDon,ChiTietHoaDon,KhachHang,VatLieu,NhanVien,NhaCungCap where HoaDon.MaHD =ChiTietHoaDon.MaHD and HoaDon.MaNV= NhanVien.MaNV and HoaDon.MaKH = KhachHang.MaKH and ChiTietHoaDon.MaVL= VatLieu.MaVL and VatLieu.MaNCC= NhaCungCap.MaNCC and KhachHang.TenKH like N'%" + txtTTHD.Text + "%'");

                    BangThongTinTimKiem.DataSource = ds3.Tables[0];
                }
                if (raSeachHDNCC.Checked == true)
                {
                    DataSet ds4 = new DataSet();
                    ds4 = GetDataSet("select HoaDon.MaHD, TenHD,TenNV,TenKH,TenVL,TenNCC,SL,GiaBan,NgayLap from HoaDon,ChiTietHoaDon,KhachHang,VatLieu,NhanVien,NhaCungCap where HoaDon.MaHD =ChiTietHoaDon.MaHD and HoaDon.MaNV= NhanVien.MaNV and HoaDon.MaKH = KhachHang.MaKH and ChiTietHoaDon.MaVL= VatLieu.MaVL and VatLieu.MaNCC= NhaCungCap.MaNCC  and NhaCungCap.TenNCC like N'%" + txtTTHD.Text + "%'");

                    BangThongTinTimKiem.DataSource = ds4.Tables[0];
                }
            }
        }

        private void TimKiem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Closeketnoi();
        }

        private void TimKiem_Load(object sender, EventArgs e)
        {
            txtTTKH.Focus();
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
