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
    public partial class QuanLyNhaCungCap : Form
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
        public QuanLyNhaCungCap()
        {
            InitializeComponent();

        }
        private void LoadBangNhaCungCap()
        {

            DataSet ds = new DataSet();
            ds = GetDataSet("select * from NhaCungCap");
            BangQuanLyNCC.DataSource = ds.Tables[0];
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", ds.Tables[0], "MaNCC");
            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", ds.Tables[0], "TenNCC");
            txtDC.DataBindings.Clear();
            txtDC.DataBindings.Add("Text", ds.Tables[0], "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", ds.Tables[0], "SDT");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", ds.Tables[0], "Website");

        }
        public bool KiemtraMaVL(string nhacungcap)
        {
            Openketnoi();
            string sql = "select MaNCC from NhaCungCap where MaNCC = '" + nhacungcap + "'";
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

        private void QuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            if (quyen == "NhanVien")
            {
                btnXoaNCC.Enabled = false;
            }
            LoadBangNhaCungCap();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNCC.Text != "" && txtTenNCC.Text != "" && txtDC.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
                {
                    if (KiemtraMaVL(txtMaNCC.Text) == true)
                    {
                        MessageBox.Show("Mã Nhà Cung Cấp Đã Tồn Tại ", "Thông Báo");
                        txtMaNCC.Text = "";
                        txtMaNCC.Focus();
                    }
                    else
                    {
                        Openketnoi();
                        string sql = "insert into NhaCungCap values ( @MaNCC, @TenNCC, @DiaChi,@SDT,@Website)";
                        SqlCommand cmd = new SqlCommand(sql, ketnoi);
                        cmd.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text);
                        cmd.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@Website", txtEmail.Text);
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm Nhà Cung Cấp Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBangNhaCungCap();
                        }
                        else
                        {
                            MessageBox.Show("Thêm Nhà Cung Cấp Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNCC.Text != "" && txtTenNCC.Text != "" && txtDC.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
                {
                    Openketnoi();
                    string sql = "update NhaCungCap set TenNCC= @TenNCC, DiaChi = @DiaChi,SDT = @SDT, Website=@Website where MaNCC=@MaNCC";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    cmd.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text);
                    cmd.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@Website", txtEmail.Text);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Thay Đổi Thông Tin Nhà Cung Cấp Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBangNhaCungCap();
                    }
                    else
                    {
                        MessageBox.Show("Thay Đổi Thông Tin Nhà Cung Cấp Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao = MessageBox.Show("Bạn Có Muốn Xóa Nhà Cung Cấp Này Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Openketnoi();
                    string sql = "delete from NhaCungCap where MaNCC=@MaNCC";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    cmd.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa Nhà Cung Cấp Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBangNhaCungCap();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Nhà Cung Cấp Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNCC.Text = "";
            txtMaNCC.Focus();
            txtTenNCC.Text = "";
            txtDC.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
        }
    }
}
