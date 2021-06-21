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
    public partial class frmLogin : Form
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
        public DataTable GetDataTable(string sql)
        {
            Openketnoi();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sql, ketnoi);
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Focus();
        }

        private void btnMatKhau_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Openketnoi();
            DataTable dt = new DataTable();
            dt =GetDataTable("select * from TaiKhoanDangNhap where NameAcount='" + txtTenDangNhap.Text + "' and PassWord='" + txtMatKhau.Text + "'");
             if (dt.Rows.Count > 0)
                {
                    MdiTrangChu.ten =GetDataTable("select NameUser from TaiKhoanDangNhap where NameAcount='" + txtTenDangNhap.Text + "' and PassWord='" + txtMatKhau.Text + "'").Rows[0][0].ToString().Trim();
                    MdiTrangChu.acount =GetDataTable("select NameAcount from TaiKhoanDangNhap where NameAcount='" + txtTenDangNhap.Text + "' and PassWord='" + txtMatKhau.Text + "'").Rows[0][0].ToString().Trim();
                    MdiTrangChu.quyen =GetDataTable("select Quyen from TaiKhoanDangNhap where NameAcount='" + txtTenDangNhap.Text + "' and PassWord='" + txtMatKhau.Text + "'").Rows[0][0].ToString().Trim();
                    QuanLyKhachHang.quyen = GetDataTable("select Quyen from TaiKhoanDangNhap where NameAcount='" + txtTenDangNhap.Text + "' and PassWord='" + txtMatKhau.Text + "'").Rows[0][0].ToString().Trim();
                    QuanLyNhaCungCap.quyen = GetDataTable("select Quyen from TaiKhoanDangNhap where NameAcount='" + txtTenDangNhap.Text + "' and PassWord='" + txtMatKhau.Text + "'").Rows[0][0].ToString().Trim();
                    QuanLyNhanVien.quyen = GetDataTable("select Quyen from TaiKhoanDangNhap where NameAcount='" + txtTenDangNhap.Text + "' and PassWord='" + txtMatKhau.Text + "'").Rows[0][0].ToString().Trim();
                    QuanLyVatLieu.quyen = GetDataTable("select Quyen from TaiKhoanDangNhap where NameAcount='" + txtTenDangNhap.Text + "' and PassWord='" + txtMatKhau.Text + "'").Rows[0][0].ToString().Trim();
                    HoaDon.quyen = GetDataTable("select Quyen from TaiKhoanDangNhap where NameAcount='" + txtTenDangNhap.Text + "' and PassWord='" + txtMatKhau.Text + "'").Rows[0][0].ToString().Trim();
                    MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MdiTrangChu frm = new MdiTrangChu();
                    frm.ShowDialog();
                    this.Close();
                   }
                else
                {
                    txtTenDangNhap.Text = "";
                    txtMatKhau.Text = "";
                    txtTenDangNhap.Focus();
                    lblLoginSai.Visible = true;
                }      
        }

        private void ckbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPass.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
                Closeketnoi();
            }
            
        }
    }
}
