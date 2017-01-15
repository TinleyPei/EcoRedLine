namespace EcoRedLine
{
    partial class frmBiodiversity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiodiversity));
            this.tb_state = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bt_biooutput = new System.Windows.Forms.Button();
            this.tb_biooutput = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bt_altinput = new System.Windows.Forms.Button();
            this.tb_altinput = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_tminput = new System.Windows.Forms.Button();
            this.tb_tminput = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_preinput = new System.Windows.Forms.Button();
            this.tb_preinput = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_nppinput = new System.Windows.Forms.Button();
            this.tb_nppinput = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_state
            // 
            this.tb_state.BackColor = System.Drawing.SystemColors.Control;
            this.tb_state.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_state.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_state.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tb_state.Location = new System.Drawing.Point(1, 581);
            this.tb_state.Name = "tb_state";
            this.tb_state.Size = new System.Drawing.Size(369, 14);
            this.tb_state.TabIndex = 39;
            this.tb_state.Text = "等待处理…";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bt_biooutput);
            this.groupBox5.Controls.Add(this.tb_biooutput);
            this.groupBox5.Controls.Add(this.pictureBox5);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(12, 404);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(623, 92);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            // 
            // bt_biooutput
            // 
            this.bt_biooutput.Image = ((System.Drawing.Image)(resources.GetObject("bt_biooutput.Image")));
            this.bt_biooutput.Location = new System.Drawing.Point(525, 51);
            this.bt_biooutput.Name = "bt_biooutput";
            this.bt_biooutput.Size = new System.Drawing.Size(25, 25);
            this.bt_biooutput.TabIndex = 4;
            this.bt_biooutput.UseVisualStyleBackColor = true;
            this.bt_biooutput.Click += new System.EventHandler(this.bt_biooutput_Click);
            // 
            // tb_biooutput
            // 
            this.tb_biooutput.Location = new System.Drawing.Point(127, 55);
            this.tb_biooutput.Name = "tb_biooutput";
            this.tb_biooutput.Size = new System.Drawing.Size(369, 21);
            this.tb_biooutput.TabIndex = 3;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.ImageLocation = "";
            this.pictureBox5.Location = new System.Drawing.Point(7, 12);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(60, 60);
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "生物多样性保护服务能力指数数据输出：";
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(389, 516);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 38;
            this.bt_cancel.Text = "取消";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(163, 516);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 37;
            this.bt_ok.Text = "确定";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bt_altinput);
            this.groupBox4.Controls.Add(this.tb_altinput);
            this.groupBox4.Controls.Add(this.pictureBox4);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 306);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(623, 92);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            // 
            // bt_altinput
            // 
            this.bt_altinput.Image = ((System.Drawing.Image)(resources.GetObject("bt_altinput.Image")));
            this.bt_altinput.Location = new System.Drawing.Point(525, 51);
            this.bt_altinput.Name = "bt_altinput";
            this.bt_altinput.Size = new System.Drawing.Size(25, 25);
            this.bt_altinput.TabIndex = 4;
            this.bt_altinput.UseVisualStyleBackColor = true;
            this.bt_altinput.Click += new System.EventHandler(this.bt_altinput_Click);
            // 
            // tb_altinput
            // 
            this.tb_altinput.Location = new System.Drawing.Point(127, 55);
            this.tb_altinput.Name = "tb_altinput";
            this.tb_altinput.Size = new System.Drawing.Size(369, 21);
            this.tb_altinput.TabIndex = 3;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.ImageLocation = "";
            this.pictureBox4.Location = new System.Drawing.Point(7, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 60);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "海拔参数数据：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_tminput);
            this.groupBox3.Controls.Add(this.tb_tminput);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(623, 92);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            // 
            // bt_tminput
            // 
            this.bt_tminput.Image = ((System.Drawing.Image)(resources.GetObject("bt_tminput.Image")));
            this.bt_tminput.Location = new System.Drawing.Point(525, 51);
            this.bt_tminput.Name = "bt_tminput";
            this.bt_tminput.Size = new System.Drawing.Size(25, 25);
            this.bt_tminput.TabIndex = 4;
            this.bt_tminput.UseVisualStyleBackColor = true;
            this.bt_tminput.Click += new System.EventHandler(this.bt_tminput_Click);
            // 
            // tb_tminput
            // 
            this.tb_tminput.Location = new System.Drawing.Point(127, 55);
            this.tb_tminput.Name = "tb_tminput";
            this.tb_tminput.Size = new System.Drawing.Size(369, 21);
            this.tb_tminput.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(6, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 60);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "平均温度（（范围：0 - 1））：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_preinput);
            this.groupBox2.Controls.Add(this.tb_preinput);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(623, 92);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // bt_preinput
            // 
            this.bt_preinput.Image = ((System.Drawing.Image)(resources.GetObject("bt_preinput.Image")));
            this.bt_preinput.Location = new System.Drawing.Point(525, 51);
            this.bt_preinput.Name = "bt_preinput";
            this.bt_preinput.Size = new System.Drawing.Size(25, 25);
            this.bt_preinput.TabIndex = 4;
            this.bt_preinput.UseVisualStyleBackColor = true;
            this.bt_preinput.Click += new System.EventHandler(this.bt_preinput_Click);
            // 
            // tb_preinput
            // 
            this.tb_preinput.Location = new System.Drawing.Point(127, 55);
            this.tb_preinput.Name = "tb_preinput";
            this.tb_preinput.Size = new System.Drawing.Size(369, 21);
            this.tb_preinput.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "平均年降水量（范围：0 - 1）：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_nppinput);
            this.groupBox1.Controls.Add(this.tb_nppinput);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 92);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // bt_nppinput
            // 
            this.bt_nppinput.Image = ((System.Drawing.Image)(resources.GetObject("bt_nppinput.Image")));
            this.bt_nppinput.Location = new System.Drawing.Point(525, 51);
            this.bt_nppinput.Name = "bt_nppinput";
            this.bt_nppinput.Size = new System.Drawing.Size(25, 25);
            this.bt_nppinput.TabIndex = 4;
            this.bt_nppinput.UseVisualStyleBackColor = true;
            this.bt_nppinput.Click += new System.EventHandler(this.bt_nppinput_Click);
            // 
            // tb_nppinput
            // 
            this.tb_nppinput.Location = new System.Drawing.Point(127, 55);
            this.tb_nppinput.Name = "tb_nppinput";
            this.tb_nppinput.Size = new System.Drawing.Size(369, 21);
            this.tb_nppinput.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "生态系统净初级生产力平均值：";
            // 
            // frmBiodiversity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(640, 594);
            this.Controls.Add(this.tb_state);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "frmBiodiversity";
            this.Text = "生物多样性生态红线";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_state;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bt_biooutput;
        private System.Windows.Forms.TextBox tb_biooutput;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bt_altinput;
        private System.Windows.Forms.TextBox tb_altinput;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_tminput;
        private System.Windows.Forms.TextBox tb_tminput;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_preinput;
        private System.Windows.Forms.TextBox tb_preinput;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_nppinput;
        private System.Windows.Forms.TextBox tb_nppinput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}