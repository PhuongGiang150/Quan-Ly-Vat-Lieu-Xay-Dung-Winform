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
    public partial class ThongKe : Form
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
        public ThongKe()
        {
            InitializeComponent();
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            layMaNV();
            layMaKH();
            layMaHD();
        }
        public void layMaKH()
        {
            Openketnoi();
            DataSet ds = new DataSet();
            ds = GetDataSet("select MaKH,TenKH from KhachHang");
            DataTable tbl = new DataTable();
            tbl = ds.Tables[0];
            cbbKH.DataSource = tbl;
            cbbKH.DisplayMember = tbl.Columns["TenKH"].ToString();
            cbbKH.ValueMember = tbl.Columns["MaKH"].ToString();
            Closeketnoi();

        }
        public void layMaNV()
        {
            Openketnoi();
            DataSet ds = new DataSet();
            ds = GetDataSet("select MaNV,TenNV from NhanVien");
            DataTable tbl = new DataTable();
            tbl = ds.Tables[0];
            cbbNV.DataSource = tbl;
            cbbNV.DisplayMember = tbl.Columns["TenNV"].ToString();
            cbbNV.ValueMember = tbl.Columns["MaNV"].ToString();
            Closeketnoi();

        }
        public void layMaHD()
        {
            Openketnoi();
            DataSet ds = new DataSet();
            ds = GetDataSet("select MaHD,TenHD from HoaDon");
            DataTable tbl = new DataTable();
            tbl = ds.Tables[0];
            cbbMaHD.DataSource = tbl;
            cbbMaHD.DisplayMember = tbl.Columns["MaHD"].ToString();
            cbbMaHD.ValueMember = tbl.Columns["MaHD"].ToString();
            Closeketnoi();

        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            try
            {
                if (raTheoNV.Checked == false && raTheoKH.Checked == false && raTheoHD.Checked == false)
                {
                    MessageBox.Show("Bạn Chưa Chọn Yêu Cầu Thống Kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (raTheoNV.Checked == true)
                    {
                        DataSet ds = new DataSet();
                        ds = GetDataSet("select HoaDon.MaHD AS [Mã Hóa Đơn], TenHD as[Tên Hóa Đơn],TenNV as [Tên Nhân Viên],TenKH as[Tên Khách Hàng],TenVL as [Dịa Chỉ],TenNCC as[Nhà Cung Cấp],SL as [Số Lượng] ,GiaBan as [Giá Bán],ThanhTien as [Thành Tiền],NgayLap as [Ngày Lập] from HoaDon,ChiTietHoaDon,KhachHang,VatLieu,NhanVien,NhaCungCap where HoaDon.MaHD =ChiTietHoaDon.MaHD and HoaDon.MaNV= NhanVien.MaNV and HoaDon.MaKH= KhachHang.MaKH and ChiTietHoaDon.MaVL = VatLieu.MaVL and VatLieu.MaNCC= NhaCungCap.MaNCC and NgayLap >= '" + dtpBD.Value.Date.ToString("MM-dd-yyyy") + "' and  NgayLap <= '" + dtpKT.Value.Date.ToString("MM-dd-yyyy") + "' and NhanVien.MaNV ='" + cbbNV.SelectedValue.ToString() + "' ");
                        BangBaoCaoVatLieu.DataSource = ds.Tables[0];
                    }
                    if (raTheoKH.Checked == true)
                    {
                        DataSet ds = new DataSet();
                        ds = GetDataSet("select HoaDon.MaHD AS [Mã Hóa Đơn], TenHD as[Tên Hóa Đơn],TenNV as [Tên Nhân Viên],TenKH as[Tên Khách Hàng],TenVL as [Dịa Chỉ],TenNCC as[Nhà Cung Cấp],SL as [Số Lượng] ,GiaBan as [Giá Bán],ThanhTien as [Thành Tiền],NgayLap as [Ngày Lập] from HoaDon,ChiTietHoaDon,KhachHang,VatLieu,NhanVien,NhaCungCap where HoaDon.MaHD =ChiTietHoaDon.MaHD and HoaDon.MaNV= NhanVien.MaNV and HoaDon.MaKH= KhachHang.MaKH and ChiTietHoaDon.MaVL = VatLieu.MaVL and VatLieu.MaNCC= NhaCungCap.MaNCC and NgayLap >= '" + dtpBD.Value.Date.ToString("MM-dd-yyyy") + "' and  NgayLap <= '" + dtpKT.Value.Date.ToString("MM-dd-yyyy") + "' and KhachHang.MaKH ='" + cbbKH.SelectedValue.ToString() + "' ");
                        BangBaoCaoVatLieu.DataSource = ds.Tables[0];
                    }
                    if (raTheoHD.Checked == true)
                    {
                        DataSet ds = new DataSet();
                        ds = GetDataSet("select HoaDon.MaHD AS [Mã Hóa Đơn], TenHD as[Tên Hóa Đơn],TenNV as [Tên Nhân Viên],TenKH as[Tên Khách Hàng],TenVL as [Dịa Chỉ],TenNCC as[Nhà Cung Cấp],SL as [Số Lượng] ,GiaBan as [Giá Bán],ThanhTien as [Thành Tiền],NgayLap as [Ngày Lập] from HoaDon,ChiTietHoaDon,KhachHang,VatLieu,NhanVien,NhaCungCap where HoaDon.MaHD =ChiTietHoaDon.MaHD and HoaDon.MaNV= NhanVien.MaNV and HoaDon.MaKH= KhachHang.MaKH and ChiTietHoaDon.MaVL = VatLieu.MaVL and VatLieu.MaNCC= NhaCungCap.MaNCC and NgayLap >= '" + dtpBD.Value.Date.ToString("MM-dd-yyyy") + "' and  NgayLap <= '" + dtpKT.Value.Date.ToString("MM-dd-yyyy") + "' and HoaDon.MaHD ='" + cbbMaHD.SelectedValue.ToString() + "' ");
                        BangBaoCaoVatLieu.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult hoi = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (hoi == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao = MessageBox.Show("Bạn Có Muốn Xuất File Này Ra File Excel?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                if (BangBaoCaoVatLieu.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet wosksheet = null;
                    wosksheet = workbook.Sheets["Sheet1"];
                    wosksheet = workbook.ActiveSheet;
                    app.Visible = true;
                    wosksheet.Cells[1, 1] = "BẢNG TỔNG HỢP DANH SÁCH HÓA ĐƠN";
                    wosksheet.Cells[3, 2] = "Mã Hóa Đơn";
                    wosksheet.Cells[3, 3] = "Tên Hóa Đơn";
                    wosksheet.Cells[3, 4] = "Tên Nhân Viên";
                    wosksheet.Cells[3, 5] = "Tên Khách Hàng";
                    wosksheet.Cells[3, 6] = "Tên Vật Liệu";
                    wosksheet.Cells[3, 7] = "Tên Nhà Cung Cấp";
                    wosksheet.Cells[3, 8] = "Số Lượng";
                    wosksheet.Cells[3, 9] = "Giá Bán";
                    wosksheet.Cells[3, 10] = "Thành Tiền";
                    wosksheet.Cells[3, 11] = "Ngày Lập";
                    for (int i = 0; i < BangBaoCaoVatLieu.Rows.Count; i++)
                    {
                        for (int j = 0; j < BangBaoCaoVatLieu.Columns.Count; j++)
                        {
                            wosksheet.Cells[i + 4, j + 1] = BangBaoCaoVatLieu.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
