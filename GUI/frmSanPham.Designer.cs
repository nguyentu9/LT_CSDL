namespace LT_CSDL.GUI
{
    partial class frmSanPham
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboloai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtten = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtma = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gvdanhsach = new System.Windows.Forms.DataGridView();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtgiatien = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvdanhsach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgiatien)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtgiatien);
            this.groupBox2.Controls.Add(this.cboloai);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtten);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtma);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(78, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 234);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin sản phẩm";
            // 
            // cboloai
            // 
            this.cboloai.FormattingEnabled = true;
            this.cboloai.Location = new System.Drawing.Point(155, 140);
            this.cboloai.Name = "cboloai";
            this.cboloai.Size = new System.Drawing.Size(292, 21);
            this.cboloai.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Giá tiền";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Loại";
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(155, 91);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(292, 20);
            this.txtten.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tên sản phẩm";
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(155, 43);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(292, 20);
            this.txtma.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mã sản phẩm";
            // 
            // gvdanhsach
            // 
            this.gvdanhsach.AllowUserToOrderColumns = true;
            this.gvdanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvdanhsach.Location = new System.Drawing.Point(83, 391);
            this.gvdanhsach.Name = "gvdanhsach";
            this.gvdanhsach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvdanhsach.Size = new System.Drawing.Size(584, 189);
            this.gvdanhsach.TabIndex = 27;
            this.gvdanhsach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvdanhsach_CellClick);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(561, 333);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(113, 41);
            this.btnthoat.TabIndex = 22;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(442, 333);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(113, 41);
            this.btnxoa.TabIndex = 23;
            this.btnxoa.Text = "Xoá";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(204, 333);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(113, 41);
            this.btnluu.TabIndex = 24;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(323, 333);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(113, 41);
            this.btnsua.TabIndex = 25;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(83, 333);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(113, 41);
            this.btnthem.TabIndex = 26;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // txtgiatien
            // 
            this.txtgiatien.Location = new System.Drawing.Point(155, 187);
            this.txtgiatien.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtgiatien.Name = "txtgiatien";
            this.txtgiatien.Size = new System.Drawing.Size(292, 20);
            this.txtgiatien.TabIndex = 9;
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 625);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gvdanhsach);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.label1);
            this.Name = "frmSanPham";
            this.Text = "frmSanPham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvdanhsach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgiatien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView gvdanhsach;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboloai;
        private System.Windows.Forms.NumericUpDown txtgiatien;
    }
}