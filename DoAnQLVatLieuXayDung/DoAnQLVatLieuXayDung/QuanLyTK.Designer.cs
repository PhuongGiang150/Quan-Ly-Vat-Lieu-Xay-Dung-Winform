namespace DoAnQLVatLieuXayDung
{
    partial class QuanLyTK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyTK));
            this.txtTenUserDK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenAcountDK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassDK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbLoaiTK = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BangTaiKhoan = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.btnThayDoi = new System.Windows.Forms.Button();
            this.btnThemTK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BangTaiKhoan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTenUserDK
            // 
            this.txtTenUserDK.Location = new System.Drawing.Point(10, 56);
            this.txtTenUserDK.MaxLength = 50;
            this.txtTenUserDK.Name = "txtTenUserDK";
            this.txtTenUserDK.Size = new System.Drawing.Size(240, 29);
            this.txtTenUserDK.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Người Dùng";
            // 
            // txtTenAcountDK
            // 
            this.txtTenAcountDK.Location = new System.Drawing.Point(10, 128);
            this.txtTenAcountDK.MaxLength = 50;
            this.txtTenAcountDK.Name = "txtTenAcountDK";
            this.txtTenAcountDK.Size = new System.Drawing.Size(240, 29);
            this.txtTenAcountDK.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Đăng Nhập";
            // 
            // txtPassDK
            // 
            this.txtPassDK.Location = new System.Drawing.Point(10, 198);
            this.txtPassDK.MaxLength = 10;
            this.txtPassDK.Name = "txtPassDK";
            this.txtPassDK.Size = new System.Drawing.Size(240, 29);
            this.txtPassDK.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật Khẩu";
            // 
            // cbbLoaiTK
            // 
            this.cbbLoaiTK.FormattingEnabled = true;
            this.cbbLoaiTK.Items.AddRange(new object[] {
            "NhanVien",
            "QuanLy",
            "Admin"});
            this.cbbLoaiTK.Location = new System.Drawing.Point(10, 272);
            this.cbbLoaiTK.Name = "cbbLoaiTK";
            this.cbbLoaiTK.Size = new System.Drawing.Size(240, 29);
            this.cbbLoaiTK.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Loại Tài Khoản";
            // 
            // BangTaiKhoan
            // 
            this.BangTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BangTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BangTaiKhoan.Location = new System.Drawing.Point(280, 65);
            this.BangTaiKhoan.Name = "BangTaiKhoan";
            this.BangTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BangTaiKhoan.Size = new System.Drawing.Size(633, 346);
            this.BangTaiKhoan.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbbLoaiTK);
            this.groupBox1.Controls.Add(this.txtPassDK);
            this.groupBox1.Controls.Add(this.txtTenAcountDK);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenUserDK);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 399);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnXoaTK);
            this.groupBox2.Controls.Add(this.btnThayDoi);
            this.groupBox2.Controls.Add(this.btnThemTK);
            this.groupBox2.Location = new System.Drawing.Point(919, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 399);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(280, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(633, 39);
            this.label4.TabIndex = 9;
            this.label4.Text = "DANH SÁCH TÀI KHOẢN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::DoAnQLVatLieuXayDung.Properties.Resources.Thoát;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(35, 286);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 49);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = " Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Image = global::DoAnQLVatLieuXayDung.Properties.Resources.Xoa;
            this.btnXoaTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaTK.Location = new System.Drawing.Point(35, 209);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(112, 49);
            this.btnXoaTK.TabIndex = 0;
            this.btnXoaTK.Text = "Xóa";
            this.btnXoaTK.UseVisualStyleBackColor = true;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // btnThayDoi
            // 
            this.btnThayDoi.Image = global::DoAnQLVatLieuXayDung.Properties.Resources.repair;
            this.btnThayDoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThayDoi.Location = new System.Drawing.Point(35, 128);
            this.btnThayDoi.Name = "btnThayDoi";
            this.btnThayDoi.Size = new System.Drawing.Size(112, 49);
            this.btnThayDoi.TabIndex = 0;
            this.btnThayDoi.Text = "Sửa";
            this.btnThayDoi.UseVisualStyleBackColor = true;
            this.btnThayDoi.Click += new System.EventHandler(this.btnThayDoi_Click);
            // 
            // btnThemTK
            // 
            this.btnThemTK.Image = global::DoAnQLVatLieuXayDung.Properties.Resources.add;
            this.btnThemTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemTK.Location = new System.Drawing.Point(35, 45);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(112, 49);
            this.btnThemTK.TabIndex = 0;
            this.btnThemTK.Text = "Thêm";
            this.btnThemTK.UseVisualStyleBackColor = true;
            this.btnThemTK.Click += new System.EventHandler(this.btnThemTK_Click);
            // 
            // QuanLyTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 430);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BangTaiKhoan);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "QuanLyTK";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ TÀI KHOẢN";
            this.Load += new System.EventHandler(this.QuanLyTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BangTaiKhoan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenUserDK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenAcountDK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassDK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThayDoi;
        private System.Windows.Forms.ComboBox cbbLoaiTK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.Button btnThemTK;
        private System.Windows.Forms.DataGridView BangTaiKhoan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label4;
    }
}