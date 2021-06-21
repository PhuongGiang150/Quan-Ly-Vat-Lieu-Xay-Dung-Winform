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
    public partial class QuanLyTK : Form
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
        public QuanLyTK()
        {
            InitializeComponent();
        }
        private void QuanLyTK_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void LoadTable(){
            
            DataSet ds = new DataSet();
            ds= GetDataSet("select * from TaiKhoanDangNhap");
            BangTaiKhoan.DataSource = ds.Tables[0];
            txtTenUserDK.DataBindings.Clear();
            txtTenUserDK.DataBindings.Add("Text", ds.Tables[0], "NameUser");
            txtTenAcountDK.DataBindings.Clear();
            txtTenAcountDK.DataBindings.Add("Text", ds.Tables[0], "NameAcount");
            txtPassDK.DataBindings.Clear();
            txtPassDK.DataBindings.Add("Text", ds.Tables[0], "PassWord");
            cbbLoaiTK.DataBindings.Clear();
            cbbLoaiTK.DataBindings.Add("Text", ds.Tables[0], "Quyen");
        }
        public bool KiemtraAcount(string Acount)
        {
            Openketnoi();
            string sql = "select NameAcount from TaiKhoanDangNhap where NameAcount = '" + Acount + "'";
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
        private void btnThemTK_Click(object sender, EventArgs e)
        {
            try
            {
                    if (txtTenAcountDK.Text != "" && txtTenUserDK.Text!="" && txtPassDK.Text!="")
                    {
                        if (KiemtraAcount(txtTenAcountDK.Text) == true)
                        {
                            MessageBox.Show("Tên Tài Khoản Đã Tồn Tại", "Thông Báo");
                            txtTenAcountDK.Text = "";
                            txtTenAcountDK.Focus();
                        }
                        else
                        {
                            Openketnoi();
                            string sql = "insert into TaiKhoanDangNhap values (@NameUser, @NameAcount, @PassWord, @Quyen)";
                            SqlCommand cmd = new SqlCommand(sql, ketnoi);
                            cmd.Parameters.AddWithValue("@NameUser", txtTenUserDK.Text);
                            cmd.Parameters.AddWithValue("@NameAcount", txtTenAcountDK.Text);
                            cmd.Parameters.AddWithValue("@PassWord", txtPassDK.Text);
                            cmd.Parameters.AddWithValue("@Quyen", cbbLoaiTK.SelectedItem);
                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Thêm Tài Khoản Thành Công", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                LoadTable();
                            }
                            else
                            {
                                MessageBox.Show("Thêm Tài Khoản Thất Bại", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            try
            {
                 DialogResult thongbao = MessageBox.Show("Bạn Có Muốn Xóa Tài Khoản Này Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                 if (thongbao == DialogResult.OK)
                 {
                     Openketnoi();
                     string sql = "delete from TaiKhoanDangNhap  where NameAcount = @NameAcount";
                     SqlCommand cmd = new SqlCommand(sql, ketnoi);
                     cmd.Parameters.AddWithValue("@NameAcount", txtTenAcountDK.Text);
                     int kq = cmd.ExecuteNonQuery();
                     if (kq > 0)
                     {
                         MessageBox.Show("Xóa TK Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         LoadTable();
                     }
                     else
                     {
                         MessageBox.Show("Xóa Tài Khoản Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                    Openketnoi();
                    string sql = "update TaiKhoanDangNhap set  NameUser = @NameUser, PassWord = @PassWord, Quyen = @Quyen where NameAcount= @NameAcount";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    cmd.Parameters.AddWithValue("@NameUser", txtTenUserDK.Text);
                    cmd.Parameters.AddWithValue("@NameAcount", txtTenAcountDK.Text);
                    cmd.Parameters.AddWithValue("@PassWord", txtPassDK.Text);
                    cmd.Parameters.AddWithValue("@Quyen", cbbLoaiTK.SelectedItem);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Thay Đổi Tài Khoản Thành Công", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        LoadTable();
                    }
                    else
                    {
                        MessageBox.Show("Thay Đổi Tài Khoản Thất Bại", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
    }
}
