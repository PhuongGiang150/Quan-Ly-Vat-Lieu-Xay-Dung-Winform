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
    public partial class QuanLyKhachHang : Form
    {
        public static string quyen;
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
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }
        private void LoadBangKhachHang()
        {

            DataSet ds = new DataSet();
            ds = GetDataSet("select * from KhachHang");
            BangQuanLyKH.DataSource = ds.Tables[0];
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", ds.Tables[0], "MaKH");
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", ds.Tables[0], "TenKH");
            txtDC.DataBindings.Clear();
            txtDC.DataBindings.Add("Text", ds.Tables[0], "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", ds.Tables[0], "SDT");
            txtDiem.DataBindings.Clear();
            txtDiem.DataBindings.Add("Text", ds.Tables[0], "Diem");
        }
        public bool KiemtraMaVL(string khachhang)
        {
            Openketnoi();
            string sql = "select MaKH from KhachHang where MaKH = '" + khachhang + "'";
            SqlCommand cmd = new SqlCommand(sql, ketnoi);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                Closeketnoi();
                return true;
            }
            Closeketnoi();
            return false;

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtDC.Text != "" && txtSDT.Text != "" && txtDiem.Text != "")
                {
                    if (KiemtraMaVL(txtMaKH.Text) == true)
                    {
                        MessageBox.Show("Khách Hàng Đã Tồn Tại ", "Thông Báo");
                        txtMaKH.Text = "";
                        txtMaKH.Focus();
                    }
                    else
                    {
                        Openketnoi();
                        string sql = "insert into KhachHang values ( @MaKH, @TenKH, @DC,@SDT,@Diem)";
                        SqlCommand cmd = new SqlCommand(sql, ketnoi);
                        cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                        cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                        cmd.Parameters.AddWithValue("@DC", txtDC.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@Diem", txtDiem.Text);
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm Khách Hàng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBangKhachHang();
                        }
                        else
                        {
                            MessageBox.Show("Thêm Khách Hàng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtDC.Text != "" && txtSDT.Text != "" && txtDiem.Text != "")
                {
                        Openketnoi();
                        string sql = "update KhachHang set TenKH = @TenKH,DiaChi = @DC, SDT = @SDT,Diem = @Diem where MaKH = @MaKH ";
                        SqlCommand cmd = new SqlCommand(sql, ketnoi);
                        cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                        cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                        cmd.Parameters.AddWithValue("@DC", txtDC.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@Diem", txtDiem.Text);
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thay Đổi Thông Tin Khách Hàng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBangKhachHang();
                        }
                        else
                        {
                            MessageBox.Show("Thay Đổi Thông Tin Khách Hàng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                else
                {
                    MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao = MessageBox.Show("Bạn Có Muốn Xóa Khách Này Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Openketnoi();
                    string sql = "delete from KhachHang where MaKH = @MaKH ";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa Khách Hàng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBangKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Khách Hàng Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadBangKhachHang();
            if (quyen == "NhanVien")
            {
                btnXoaKH.Enabled = false;
            }
        }

        private void btnThoatKH_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(hoi== DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDC.Text = "";
            txtSDT.Text = "";
            txtDiem.Text = "";
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtMaKH.Focus();
            txtTenKH.Text = "";
            txtDC.Text = "";
            txtSDT.Text = "";
            txtDiem.Text = "";
        }

        

    }
}
