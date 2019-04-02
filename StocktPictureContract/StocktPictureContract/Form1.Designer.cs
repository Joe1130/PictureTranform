namespace StocktPictureContract
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PicBoxShow = new System.Windows.Forms.PictureBox();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.labShow = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxShow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(63, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接收设置";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(452, 29);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(175, 25);
            this.txtPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(124, 30);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(149, 25);
            this.txtIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP地址";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PicBoxShow);
            this.groupBox2.Location = new System.Drawing.Point(63, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 420);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片信息";
            // 
            // PicBoxShow
            // 
            this.PicBoxShow.Location = new System.Drawing.Point(35, 46);
            this.PicBoxShow.Name = "PicBoxShow";
            this.PicBoxShow.Size = new System.Drawing.Size(646, 355);
            this.PicBoxShow.TabIndex = 0;
            this.PicBoxShow.TabStop = false;
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(53, 547);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(716, 25);
            this.txtAdress.TabIndex = 2;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(53, 587);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(121, 40);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "选择图片";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(623, 587);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(121, 40);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // labShow
            // 
            this.labShow.AutoSize = true;
            this.labShow.Location = new System.Drawing.Point(50, 642);
            this.labShow.Name = "labShow";
            this.labShow.Size = new System.Drawing.Size(63, 15);
            this.labShow.TabIndex = 5;
            this.labShow.Text = "labShow";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 681);
            this.Controls.Add(this.labShow);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "图片传输";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox PicBoxShow;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label labShow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

