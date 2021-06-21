namespace DoAnQLVatLieuXayDung
{
    partial class ThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKe));
            this.cbbNV = new System.Windows.Forms.ComboBox();
            this.cbbKH = new System.Windows.Forms.ComboBox();
            this.lblKH = new System.Windows.Forms.Label();
            this.lblNV = new System.Windows.Forms.Label();
            this.raTheoNV = new System.Windows.Forms.RadioButton();
            this.raTheoKH = new System.Windows.Forms.RadioButton();
            this.dtpKT = new System.Windows.Forms.DateTimePicker();
            this.dtpBD = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BangBaoCaoVatLieu = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbMaHD = new System.Windows.Forms.ComboBox();
            this.lblHD = new System.Windows.Forms.Label();
            this.raTheoHD = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnThucHien = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BangBaoCaoVatLieu)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbNV
            // 
            this.cbbNV.FormattingEnabled = true;
            this.cbbNV.Location = new System.Drawing.Point(559, 73);
            this.cbbNV.Name = "cbbNV";
            this.cbbNV.Size = new System.Drawing.Size(178, 29);
            this.cbbNV.TabIndex = 3;
            // 
            // cbbKH
            // 
            this.cbbKH.FormattingEnabled = true;
            this.cbbKH.Location = new System.Drawing.Point(559, 22);
            this.cbbKH.Name = "cbbKH";
            this.cbbKH.Size = new System.Drawing.Size(178, 29);
            this.cbbKH.TabIndex = 2;
            // 
            // lblKH
            // 
            this.lblKH.AutoSize = true;
            this.lblKH.Location = new System.Drawing.Point(427, 30);
            this.lblKH.Name = "lblKH";
            this.lblKH.Size = new System.Drawing.Size(102, 21);
            this.lblKH.TabIndex = 3;
            this.lblKH.Text = "Khách Hàng";
            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Location = new System.Drawing.Point(427, 81);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(87, 21);
            this.lblNV.TabIndex = 3;
            this.lblNV.Text = "Nhân Viên";
            // 
            // raTheoNV
            // 
            this.raTheoNV.AutoSize = true;
            this.raTheoNV.Location = new System.Drawing.Point(231, 79);
            this.raTheoNV.Name = "raTheoNV";
            this.raTheoNV.Size = new System.Drawing.Size(149, 25);
            this.raTheoNV.TabIndex = 2;
            this.raTheoNV.TabStop = true;
            this.raTheoNV.Text = "Theo Nhân Viên";
            this.raTheoNV.UseVisualStyleBackColor = true;
            // 
            // raTheoKH
            // 
            this.raTheoKH.AutoSize = true;
            this.raTheoKH.Location = new System.Drawing.Point(231, 28);
            this.raTheoKH.Name = "raTheoKH";
            this.raTheoKH.Size = new System.Drawing.Size(164, 25);
            this.raTheoKH.TabIndex = 2;
            this.raTheoKH.TabStop = true;
            this.raTheoKH.Text = "Theo Khách Hàng";
            this.raTheoKH.UseVisualStyleBackColor = true;
            // 
            // dtpKT
            // 
            this.dtpKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKT.Location = new System.Drawing.Point(18, 130);
            this.dtpKT.Name = "dtpKT";
            this.dtpKT.Size = new System.Drawing.Size(178, 29);
            this.dtpKT.TabIndex = 1;
            // 
            // dtpBD
            // 
            this.dtpBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBD.Location = new System.Drawing.Point(22, 63);
            this.dtpBD.Name = "dtpBD";
            this.dtpBD.Size = new System.Drawing.Size(174, 29);
            this.dtpBD.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đến Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ Ngày";
            // 
            // BangBaoCaoVatLieu
            // 
            this.BangBaoCaoVatLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BangBaoCaoVatLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BangBaoCaoVatLieu.Location = new System.Drawing.Point(8, 224);
            this.BangBaoCaoVatLieu.Name = "BangBaoCaoVatLieu";
            this.BangBaoCaoVatLieu.Size = new System.Drawing.Size(1264, 325);
            this.BangBaoCaoVatLieu.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(12, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1260, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "BÁO CÁO VẬT LIỆU ĐÃ BÁN";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbMaHD);
            this.groupBox1.Controls.Add(this.lblHD);
            this.groupBox1.Controls.Add(this.raTheoHD);
            this.groupBox1.Controls.Add(this.cbbNV);
            this.groupBox1.Controls.Add(this.lblNV);
            this.groupBox1.Controls.Add(this.dtpBD);
            this.groupBox1.Controls.Add(this.raTheoNV);
            this.groupBox1.Controls.Add(this.cbbKH);
            this.groupBox1.Controls.Add(this.lblKH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpKT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.raTheoKH);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 172);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yêu Cầu";
            // 
            // cbbMaHD
            // 
            this.cbbMaHD.FormattingEnabled = true;
            this.cbbMaHD.Location = new System.Drawing.Point(559, 126);
            this.cbbMaHD.Name = "cbbMaHD";
            this.cbbMaHD.Size = new System.Drawing.Size(178, 29);
            this.cbbMaHD.TabIndex = 5;
            // 
            // lblHD
            // 
            this.lblHD.AutoSize = true;
            this.lblHD.Location = new System.Drawing.Point(427, 134);
            this.lblHD.Name = "lblHD";
            this.lblHD.Size = new System.Drawing.Size(79, 21);
            this.lblHD.TabIndex = 6;
            this.lblHD.Text = "Hóa Đơn";
            // 
            // raTheoHD
            // 
            this.raTheoHD.AutoSize = true;
            this.raTheoHD.Location = new System.Drawing.Point(231, 132);
            this.raTheoHD.Name = "raTheoHD";
            this.raTheoHD.Size = new System.Drawing.Size(141, 25);
            this.raTheoHD.TabIndex = 4;
            this.raTheoHD.TabStop = true;
            this.raTheoHD.Text = "Theo Hóa Đơn";
            this.raTheoHD.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnXuatFile);
            this.groupBox2.Controls.Add(this.btnThucHien);
            this.groupBox2.Location = new System.Drawing.Point(859, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 168);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::DoAnQLVatLieuXayDung.Properties.Resources.Thoát;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(164, 111);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(126, 40);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = " Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Image = global::DoAnQLVatLieuXayDung.Properties.Resources.XuatFile;
            this.btnXuatFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatFile.Location = new System.Drawing.Point(265, 41);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(126, 40);
            this.btnXuatFile.TabIndex = 5;
            this.btnXuatFile.Text = "Xuất File";
            this.btnXuatFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Image = global::DoAnQLVatLieuXayDung.Properties.Resources.thuchien;
            this.btnThucHien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThucHien.Location = new System.Drawing.Point(48, 41);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(126, 40);
            this.btnThucHien.TabIndex = 4;
            this.btnThucHien.Text = "Thống Kê";
            this.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BangBaoCaoVatLieu);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BangBaoCaoVatLieu)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.ComboBox cbbNV;
        private System.Windows.Forms.ComboBox cbbKH;
        private System.Windows.Forms.Label lblKH;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.RadioButton raTheoNV;
        private System.Windows.Forms.RadioButton raTheoKH;
        private System.Windows.Forms.DateTimePicker dtpKT;
        private System.Windows.Forms.DateTimePicker dtpBD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView BangBaoCaoVatLieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbMaHD;
        private System.Windows.Forms.Label lblHD;
        private System.Windows.Forms.RadioButton raTheoHD;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}