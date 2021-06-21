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
    public partial class DoiMatKhau : Form
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
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDN.Focus();
            //txtMKMoi.Enabled = false;
            //txtNhapLai.Enabled = false;
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            try
            {
                Openketnoi();
                SqlDataAdapter da = new SqlDataAdapter("select count (*) from TaiKhoanDangNhap where NameAcount = N'" + txtTenDN.Text + "' and PassWord = N'" + txtMKcu.Text + "' ", ketnoi);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Loi.Clear();
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (txtMKMoi.Text == txtMKMoi.Text && txtMKMoi.Text != "")
                    {
                        SqlDataAdapter da1 = new SqlDataAdapter("update TaiKhoanDangNhap set PassWord = N'" + txtMKMoi.Text + "' where NameAcount =N'" + txtTenDN.Text + "'", ketnoi);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        MessageBox.Show("Đổi Mật Khẩu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Loi.SetError(txtMKMoi,"Vui Lòng Điền Mật Khẩu Mới Vào");
                        txtMKMoi.Focus();
                        Loi.SetError(txtNhapLai,"Nhập Lại Mật Khẩu Không Đúng");
                    }
                }
                    else
                    {
                        Loi.SetError(txtTenDN,"Tên Đăng Nhập Không Đúng");
                        Loi.SetError(txtMKcu,  "Mật Khẩu Không Chính Sác");
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
