using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoAnQLVatLieuXayDung
{
    public partial class MdiTrangChu : Form
    {
        public static string quyen;
        public static string ten;
        public static string acount;

        public MdiTrangChu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {

        }

        private void OpenFile(object sender, EventArgs e)
        {

        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void mdiTrangChu_Load(object sender, EventArgs e)
        {
            if (quyen == "Admin")
            {
                lblTen2.Text = "Admin:" + ten + "         -         Tài Khoản Đang Đăng Nhập: " + acount;
            }
            if (quyen == "QuanLy")
            {
                lblTen2.Text = "Quản Lý:" + ten + "         -         Tài Khoản Đang Đăng Nhập: " + acount;
                quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnToolStripMenuItem.Enabled = false;
            }
            if (quyen == "NhanVien")
            {
                quảnLýAcountToolStripMenuItem.Visible = false;
                quảnLýToolStripMenuItem.Visible = false;
                lblTen2.Text = "Nhân Viên: " + ten + "         -         Tài Khoản Đang Đăng Nhập: " + acount;
                qUẢNLÝToolStripMenuItem1.Visible = false;
                quảnLýNhânViênToolStripMenuItem.Visible = false;
                quảnLýNhânViênToolStripMenuItem.Enabled = false;
                quảnLýKháchHàngToolStripMenuItem.Visible = false;
                quảnLýKháchHàngToolStripMenuItem.Enabled = false;
                quảnLýVậtLiệuToolStripMenuItem.Visible = false;
                quảnLýVậtLiệuToolStripMenuItem.Enabled = false;
                quảnLýNhàCungCấpToolStripMenuItem.Visible = false;
                quảnLýNhàCungCấpToolStripMenuItem.Enabled = false;
                quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnToolStripMenuItem.Enabled = false;
            }
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTK frm = new QuanLyTK();
            frm.Show();
            frm.MdiParent = this;
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau frm = new DoiMatKhau();
            frm.Show();
            frm.MdiParent = this;
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             DialogResult hoi = MessageBox.Show("Bạn Có Chắc Chắn Muốn Đăng Xuất?","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
             if (hoi == DialogResult.OK)
             {
                 this.Close();
             }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien frm = new QuanLyNhanVien();
            frm.Show();
            frm.MdiParent = this;
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang frm = new QuanLyKhachHang();
            frm.Show();
            frm.MdiParent = this;
        }

        private void quảnLýVậtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyVatLieu frm = new QuanLyVatLieu();
            frm.Show();
            frm.MdiParent = this;
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhaCungCap frm = new QuanLyNhaCungCap();
            frm.Show();
            frm.MdiParent = this;
        }

        private void xEMTHÔNGTINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemThongTin fr = new XemThongTin();
            fr.Show();
            fr.MdiParent = this;
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon frm = new HoaDon();
            frm.Show();
            frm.MdiParent = this;
        }

        private void inHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Report frm = new Report();
            frm.Show();
            frm.MdiParent = this;
        }

        private void tÌMKIẾMToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            TimKiem frm = new TimKiem();
            frm.Show();
            frm.MdiParent = this;
        }

        private void tHỐNGKÊToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe frm = new ThongKe();
            frm.Show();
            frm.MdiParent = this;
        }

        private void gIỚITHIỆUToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GioiThieu frm = new GioiThieu();
            frm.Show();
            frm.MdiParent = this;
        }

      
    }
}
