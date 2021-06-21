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
    public partial class HoaDon : Form
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
        public HoaDon()
        {
            InitializeComponent();
        }
        private void LoadHoaDon()
        {

            DataSet ds = new DataSet();
            ds = GetDataSet("select * from HoaDon");
            BangHD.DataSource = ds.Tables[0];
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", ds.Tables[0], "MaHD");
            txtTenHD.DataBindings.Clear();
            txtTenHD.DataBindings.Add("Text", ds.Tables[0], "TenHD");
            cbbMaNV.DataBindings.Clear();
            cbbMaNV.DataBindings.Add("Text", ds.Tables[0], "MaNV");
            cbbMaKH.DataBindings.Clear();
            cbbMaKH.DataBindings.Add("Text", ds.Tables[0], "MaKH");
            dtpNgayLap.DataBindings.Clear();
            dtpNgayLap.DataBindings.Add("Text", ds.Tables[0], "NgayLap");
        }
        private void LoadChiTietHoaDon()
        {

            DataSet ds = new DataSet();
            ds = GetDataSet("select * from ChiTietHoaDon");
            BangChiTietHD.DataSource = ds.Tables[0];
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", ds.Tables[0], "ID");
            cbbMaHD.DataBindings.Clear();
            cbbMaHD.DataBindings.Add("Text", ds.Tables[0], "MaHD");
            cbbMaVL.DataBindings.Clear();
            cbbMaVL.DataBindings.Add("Text", ds.Tables[0], "MaVL");
            txtSL.DataBindings.Clear();
            txtSL.DataBindings.Add("Text", ds.Tables[0], "SL");
            txtDG.DataBindings.Clear();
            txtDG.DataBindings.Add("Text", ds.Tables[0], "GiaBan");
            txtTT.DataBindings.Clear();
            txtTT.DataBindings.Add("Text", ds.Tables[0], "ThanhTien");
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            if (quyen == "NhanVien")
            {
                btnXoaHD.Enabled = false;
                btnXoaDon.Enabled = false;
            }
            LoadHoaDon();
            LoadChiTietHoaDon();
            layMaVL();
            layMaKH();
            layMaNV();
            layMaHD();
        }
        public bool KiemtraMaHD(string maHD)
        {
            Openketnoi();
            string sql = "select MaHD from HoaDon where MaHD = '" + maHD + "'";
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
        public bool KiemtraID(string id)
        {
            Openketnoi();
            string sql = "select ID from ChiTietHoaDon where MaHD = '" + id + "'";
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
        public void layMaVL()
        {
            Openketnoi();
            DataSet ds = new DataSet();
            ds = GetDataSet("select MaVL,TenVL,GiaNhap from VatLieu");
            DataTable tbl = new DataTable();
            tbl = ds.Tables[0];
            cbbMaVL.DataSource = tbl;
            cbbMaVL.DisplayMember = tbl.Columns["TenVL"].ToString();
            cbbMaVL.ValueMember = tbl.Columns["MaVL"].ToString();
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
        public void layMaNV()
        {
            Openketnoi();
            DataSet ds = new DataSet();
            ds = GetDataSet("select MaNV,TenNV from NhanVien");
            DataTable tbl = new DataTable();
            tbl = ds.Tables[0];
            cbbMaNV.DataSource = tbl;
            cbbMaNV.DisplayMember = tbl.Columns["TenNV"].ToString();
            cbbMaNV.ValueMember = tbl.Columns["MaNV"].ToString();
            Closeketnoi();

        }
        public void layMaKH()
        {
            Openketnoi();
            DataSet ds = new DataSet();
            ds = GetDataSet("select MaKH,TenKH from KhachHang");
            DataTable tbl = new DataTable();
            tbl = ds.Tables[0];
            cbbMaKH.DataSource = tbl;
            cbbMaKH.DisplayMember = tbl.Columns["TenKH"].ToString();
            cbbMaKH.ValueMember = tbl.Columns["MaKH"].ToString();
            Closeketnoi();

        }
        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (txtMaHD.Text != "" && txtTenHD.Text != "" && cbbMaNV.Text != "" && cbbMaKH.Text != "" && dtpNgayLap.Text!="")
                {
                    if (KiemtraMaHD(txtMaHD.Text) == true)
                    {
                        MessageBox.Show("Hóa Đơn Đã Tồn Tại ", "Thông Báo");
                        txtMaHD.Text = "";
                        txtMaHD.Focus();
                    }
                    else
                    {
                        Openketnoi();
                        
                        string sql = "insert into HoaDon values (@MaHD ,@TenHD, @MaNV,@MaKH, @NgayLap)";
                        SqlCommand cmd = new SqlCommand(sql, ketnoi);
                        cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                        cmd.Parameters.AddWithValue("@TenHD", txtTenHD.Text);
                        cmd.Parameters.AddWithValue("@MaNV", cbbMaNV.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@MaKH", cbbMaKH.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm Hóa Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHoaDon();
                            LoadChiTietHoaDon();
                        }
                        else
                        {
                            MessageBox.Show("Thêm Hóa Đơn Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao = MessageBox.Show("Bạn Có Muốn Xóa Hóa Đơn Này Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                     Openketnoi();
                    string sql = "delete from HoaDon where MaHD =  @MaHD";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa Hóa Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadChiTietHoaDon();
                        LoadHoaDon();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Hóa Đơn Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                 }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddVL_Click(object sender, EventArgs e)
        {
            QuanLyVatLieu frm = new QuanLyVatLieu();
            frm.ShowDialog();
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien frm = new QuanLyNhanVien();
            frm.ShowDialog();
        }

        private void btnAddKH_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang frm = new QuanLyKhachHang();
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHD.Text != ""  && txtTenHD.Text != "" && cbbMaNV.Text != "" && cbbMaKH.Text != "" && dtpNgayLap.Text != "")
                {
                    Openketnoi();

                    string sql = "update HoaDon set TenHD = @TenHD, MaNV = @MaNV,MaKH = @MaKH,NgayLap = @NgayLap where MaHD = @MaHD";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                    cmd.Parameters.AddWithValue("@TenHD", txtTenHD.Text);
                    cmd.Parameters.AddWithValue("@MaNV", cbbMaNV.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MaKH", cbbMaKH.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                    int kq = cmd.ExecuteNonQuery();
                    
                    if (kq > 0 )
                    {
                        MessageBox.Show("Thay Đổi Hóa Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHoaDon();
                        LoadChiTietHoaDon();
                    }
                    else
                    {
                        MessageBox.Show("Thay Đổi Hóa Đơn Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnThemDon_Click(object sender, EventArgs e)
        {
           
            try
            {
                int sl, dg, gg;
                string strsl, strdg, strgg;
                strsl = txtSL.Text;
                strdg = txtDG.Text;
                strgg = txtGG.Text;
                sl = int.Parse(strsl);
                dg = int.Parse(strdg);
                gg = int.Parse(strgg);
                txtTT.Text = (sl * dg - gg).ToString();
                if (txtID.Text != "" && cbbMaHD.Text != "" && cbbMaVL.Text!="" && txtSL.Text!="" && txtDG.Text !="" && txtGG.Text !="")
                {
                    if (KiemtraID(txtID.Text) == true)
                    {
                        MessageBox.Show("ID Đơn Đã Tồn Tại ", "Thông Báo");
                        txtID.Text = "";
                        txtID.Focus();
                    }
                    else
                    {
                        Openketnoi();

                        string sql = "insert into ChiTietHoaDon values ( @ID,@MaHD, @MaVL, @SoLuong,@GiaBan,@ThanhTien)";
                        SqlCommand cmd = new SqlCommand(sql, ketnoi);
                        cmd.Parameters.AddWithValue("@ID", txtID.Text);
                        cmd.Parameters.AddWithValue("@MaHD", cbbMaHD.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@MaVL", cbbMaVL.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@SoLuong", txtSL.Text);
                        cmd.Parameters.AddWithValue("@GiaBan", txtDG.Text);
                        cmd.Parameters.AddWithValue("@ThanhTien", txtTT.Text);
                        int kq = cmd.ExecuteNonQuery();

                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHoaDon();
                            LoadChiTietHoaDon();
                        }
                        else
                        {
                            MessageBox.Show("Thêm Đơn Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSuaVL_Click(object sender, EventArgs e)
        {
            float sl, dg,gg;
            string strsl, strdg, strgg;
            strsl = txtSL.Text;
            strdg = txtDG.Text;
            strgg = txtGG.Text;
            sl = float.Parse(strsl);
            dg = float.Parse(strdg);
            gg= float.Parse(strgg);
            txtTT.Text = (sl * dg - gg).ToString();
            try
            {
                if (txtID.Text != "" && cbbMaHD.Text != "" && cbbMaVL.Text != "" && txtSL.Text != "" && txtDG.Text != "")
                {
                    if (KiemtraID(txtID.Text) == true)
                    {
                        MessageBox.Show("ID Đơn Đã Tồn Tại ", "Thông Báo");
                        txtID.Text = "";
                        txtID.Focus();
                    }
                    else
                    {
                        Openketnoi();

                        string sql = "update ChiTietHoaDon set MaHD = @MaHD,MaVL= @MaVL,SL = @SoLuong,GiaBan = @GiaBan,ThanhTien = @ThanhTien where ID=@ID";
                        SqlCommand cmd = new SqlCommand(sql, ketnoi);
                        cmd.Parameters.AddWithValue("@ID", txtID.Text);
                        cmd.Parameters.AddWithValue("@MaHD", cbbMaHD.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@MaVL", cbbMaVL.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@SoLuong", txtSL.Text);
                        cmd.Parameters.AddWithValue("@GiaBan", txtDG.Text);
                        cmd.Parameters.AddWithValue("@ThanhTien", txtTT.Text);
                        int kq = cmd.ExecuteNonQuery();

                        if (kq > 0)
                        {
                            MessageBox.Show("Sửa Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHoaDon();
                            LoadChiTietHoaDon();
                        }
                        else
                        {
                            MessageBox.Show("Sửa Đơn Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao = MessageBox.Show("Bạn Có Muốn Xóa Nhân Viên Này Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Openketnoi();

                    string sql = "delete from ChiTietHoaDon where ID=@ID";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    cmd.Parameters.AddWithValue("@ID", txtID.Text);
                    int kq = cmd.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHoaDon();
                        LoadChiTietHoaDon();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Đơn Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddVL_Click_1(object sender, EventArgs e)
        {
            QuanLyVatLieu frm = new QuanLyVatLieu();
            frm.ShowDialog();
        }
        private void ckKHnew_CheckedChanged(object sender, EventArgs e)
        {
            QuanLyKhachHang frm = new QuanLyKhachHang();
            frm.ShowDialog();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            txtMaHD.Focus();
            txtTenHD.Text = "";
            cbbMaKH.Text = "";
            cbbMaNV.Text = "";
            dtpNgayLap.Text = "";
        }

        private void btnThoatHD_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (hoi == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnThemHDCT_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtID.Focus();
            cbbMaHD.Text = "";
            cbbMaVL.Text = "";
            txtSL.Text = "";
            txtDG.Text = "";
            txtTT.Text = "";
        }

        private void btnThoatHDCT_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn Có Muốn Thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (hoi == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cbbMaVL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Openketnoi();
            DataSet ds = new DataSet();
            ds = GetDataSet("select MaVL,TenVL,GiaNhap from VatLieu where MaVL= '"+cbbMaVL.SelectedValue.ToString()+"'");
            DataTable tbl = new DataTable();
            tbl = ds.Tables[0];
            txtDG.DataBindings.Clear();
            txtDG.DataBindings.Add("Text", ds.Tables[0], "GiaNhap");
            Closeketnoi();
        }

    }
}
