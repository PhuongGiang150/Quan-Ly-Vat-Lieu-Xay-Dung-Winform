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
    public partial class QuanLyNhanVien : Form
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
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        private void LoadBangNhanVien()
        {

            DataSet ds = new DataSet();
            ds = GetDataSet("select * from NhanVien");
            BangQuanLyNV.DataSource = ds.Tables[0];
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", ds.Tables[0], "MaNV");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", ds.Tables[0], "TenNV");
            txtDC.DataBindings.Clear();
            txtDC.DataBindings.Add("Text", ds.Tables[0], "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", ds.Tables[0], "SDT");
            txtLuong.DataBindings.Clear();
            txtLuong.DataBindings.Add("Text", ds.Tables[0], "Luong");
            txtCongViec.DataBindings.Clear();
            txtCongViec.DataBindings.Add("Text", ds.Tables[0], "CongViec");
        }
        public bool KiemtraMaVL(string nhanvien)
        {
            Openketnoi();
            string sql = "select MaNV from NhanVien where MaNV = '" + nhanvien + "'";
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

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text != "" && txtTenNV.Text != "" && txtDC.Text != "" && txtSDT.Text != "" && txtLuong.Text != "" && txtCongViec.Text!="")
                {
                    if (KiemtraMaVL(txtMaNV.Text) == true)
                    {
                        MessageBox.Show("Nhân Viên Đã Tồn Tại ", "Thông Báo");
                        txtMaNV.Text = "";
                        txtMaNV.Focus();
                    }
                    else
                    {
                        Openketnoi();
                        string sql = "insert into NhanVien values ( @MaNV, @TenNV, @DC,@SDT,@Luong,@CongViec)";
                        SqlCommand cmd = new SqlCommand(sql, ketnoi);
                        cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                        cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                        cmd.Parameters.AddWithValue("@DC", txtDC.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@Luong", txtLuong.Text);
                        cmd.Parameters.AddWithValue("@CongViec",txtCongViec.Text);
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm Nhân Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBangNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Thêm Nhân Viên Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text != "" && txtTenNV.Text != "" && txtDC.Text != "" && txtSDT.Text != "" && txtLuong.Text != "" && txtCongViec.Text != "")
                {
                        Openketnoi();
                        string sql = "update NhanVien set TenNV = @TenNV,DiaChi = @DC,SDT = @SDT,Luong = @Luong,CongViec = @CongViec where MaNV =  @MaNV";
                        SqlCommand cmd = new SqlCommand(sql, ketnoi);
                        cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                        cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                        cmd.Parameters.AddWithValue("@DC", txtDC.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@Luong", txtLuong.Text);
                        cmd.Parameters.AddWithValue("@CongViec", txtCongViec.Text);
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thay Đổi Thông Tin Nhân Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBangNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Thay Đổi Thông Tin Nhân Viên Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao = MessageBox.Show("Bạn Có Muốn Xóa Nhân Viên Này Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Openketnoi();
                    string sql = "delete from NhanVien where MaNV =  @MaNV";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa Nhân Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBangNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Nhân Viên Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            if (quyen == "NhanVien")
            {
                btnXoaNV.Enabled = false;
            }
            LoadBangNhanVien();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (hoi == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtCongViec.Text = "";
            txtDC.Text = "";
            txtMaNV.Text = "";
            txtMaNV.Focus();
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtLuong.Text = "";
        }

    }
}
