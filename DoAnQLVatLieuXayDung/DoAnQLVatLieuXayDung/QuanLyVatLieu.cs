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
    public partial class QuanLyVatLieu : Form
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
        public QuanLyVatLieu()
        {
            InitializeComponent();
        }
        private void LoadBangVatLieu()
        {

            DataSet ds = new DataSet();
            ds = GetDataSet("select * from VatLieu");
            BangQuanLyVL.DataSource = ds.Tables[0];
            txtMaVL.DataBindings.Clear();
            txtMaVL.DataBindings.Add("Text", ds.Tables[0], "MaVL");
            txtTenVL.DataBindings.Clear();
            txtTenVL.DataBindings.Add("Text", ds.Tables[0], "TenVL");
            txtDVTinh.DataBindings.Clear();
            txtDVTinh.DataBindings.Add("Text", ds.Tables[0], "DvTinh");
            txtGiaNhap.DataBindings.Clear();
            txtGiaNhap.DataBindings.Add("Text", ds.Tables[0], "GiaNhap");
            txtLoai.DataBindings.Clear();
            txtLoai.DataBindings.Add("Text", ds.Tables[0], "Loai");
            cbbMaNCC.DataBindings.Clear();
            cbbMaNCC.DataBindings.Add("Text", ds.Tables[0], "MaNCC");
        }
        public void layMANCC()
        {
            Openketnoi();
            DataSet ds = new DataSet();
            ds = GetDataSet("select MaNCC,TenNCC from NhaCungCap");
            DataTable tbl = new DataTable();
            tbl= ds.Tables[0];
            cbbMaNCC.DataSource =tbl;
            cbbMaNCC.DisplayMember = tbl.Columns["TenNCC"].ToString();
            cbbMaNCC.ValueMember = tbl.Columns["MaNCC"].ToString();
            Closeketnoi();

        }
        public bool KiemtraMaVL(string vatlieu)
        {
            Openketnoi();
            string sql = "select MaVL from VatLieu where MaVL = '" + vatlieu + "'";
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
        private void btnThemVL_Click(object sender, EventArgs e)
        {
                try
            {
                    if (txtMaVL.Text != "" && txtTenVL.Text!="" && txtDVTinh.Text!="" && txtGiaNhap.Text!="" && txtLoai.Text!="" )
                    {
                        if (KiemtraMaVL(txtMaVL.Text) == true)
                        {
                            MessageBox.Show("Mã Vật Liệu Đã Tồn Tại ", "Thông Báo");
                            txtMaVL.Text = "";
                            txtMaVL.Focus();
                        }
                        else
                        {
                            Openketnoi();
                            string sql = "insert into VatLieu values ( @MaVL, @TenVL, @DvTinh,@GiaNhap,@Loai,@MaNCC)";
                            SqlCommand cmd = new SqlCommand(sql, ketnoi);
                            cmd.Parameters.AddWithValue("@MaVL", txtMaVL.Text);
                            cmd.Parameters.AddWithValue("@TenVL", txtTenVL.Text);
                            cmd.Parameters.AddWithValue("@DvTinh", txtDVTinh.Text);
                            cmd.Parameters.AddWithValue("GiaNhap",txtGiaNhap.Text);
                             cmd.Parameters.AddWithValue("Loai",txtLoai.Text);
                             cmd.Parameters.AddWithValue("MaNCC", cbbMaNCC.SelectedValue.ToString());
                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Thêm Vật Liệu Thành Công", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                LoadBangVatLieu();
                            }
                            else
                            {
                                MessageBox.Show("Thêm Vật Liệu Thất Bại", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnSuaVL_Click(object sender, EventArgs e)
        {
                 try
            {
                    if (txtMaVL.Text != "" && txtTenVL.Text!="" && txtDVTinh.Text!="" && txtGiaNhap.Text!="" && txtLoai.Text!="" )
                    {
                            Openketnoi();
                            string sql = "update VatLieu set TenVL = @TenVL,DvTinh = @DvTinh,GiaNhap = @GiaNhap,Loai = @Loai, MaNCC= @MaNCC where MaVL= @MaVL";
                            SqlCommand cmd = new SqlCommand(sql, ketnoi);
                            cmd.Parameters.AddWithValue("@MaVL", txtMaVL.Text);
                            cmd.Parameters.AddWithValue("@TenVL", txtTenVL.Text);
                            cmd.Parameters.AddWithValue("@DvTinh", txtDVTinh.Text);
                            cmd.Parameters.AddWithValue("GiaNhap",txtGiaNhap.Text);
                             cmd.Parameters.AddWithValue("Loai",txtLoai.Text);
                             cmd.Parameters.AddWithValue("MaNCC", cbbMaNCC.SelectedValue.ToString());
                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Sửa Thông Tin Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadBangVatLieu();
                            }
                            else
                            {
                                MessageBox.Show("Sửa Thông Tin Vật Liệu Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXoaVL_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao = MessageBox.Show("Bạn Có Muốn Xóa Vật Liệu Này Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Openketnoi();
                    string sql = "delete from VatLieu  where MaVL = @MaVL";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    cmd.Parameters.AddWithValue("@MaVL", txtMaVL.Text);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa Vật Liệu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBangVatLieu();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Vật Liệu Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void QuanLyVatLieu_Load(object sender, EventArgs e)
        {
            if (quyen == "NhanVien")
            {
                btnXoaVL.Enabled = false;
            }
            LoadBangVatLieu();
            layMANCC();
        }

        private void btnAddNCC_Click(object sender, EventArgs e)
        {
            QuanLyNhaCungCap frm = new QuanLyNhaCungCap();
            frm.ShowDialog();
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
            txtMaVL.Text = "";
            txtMaVL.Focus();
            txtTenVL.Text = "";
            txtLoai.Text = "";
            txtGiaNhap.Text = "";
            txtDVTinh.Text = "";
        }
    }
}
