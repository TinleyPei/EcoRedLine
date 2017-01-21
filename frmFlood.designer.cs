namespace EcoRedLine
{
    partial class frmFlood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFlood));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_bufferunits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_four = new System.Windows.Forms.NumericUpDown();
            this.nud_three = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_two = new System.Windows.Forms.NumericUpDown();
            this.nud_one = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bt_flooutput = new System.Windows.Forms.Button();
            this.tb_flooutput = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_state = new System.Windows.Forms.TextBox();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_waterunits = new System.Windows.Forms.ComboBox();
            this.tb_highinput = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_deminput = new System.Windows.Forms.Button();
            this.tb_demnput = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_four)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_three)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_two)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_one)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cb_bufferunits);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.nud_four);
            this.groupBox3.Controls.Add(this.nud_three);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nud_two);
            this.groupBox3.Controls.Add(this.nud_one);
            this.groupBox3.Location = new System.Drawing.Point(10, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(625, 92);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "设置缓冲参数：";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(9, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 60);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(506, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 52;
            this.label8.Text = "缓冲单位：";
            // 
            // cb_bufferunits
            // 
            this.cb_bufferunits.FormattingEnabled = true;
            this.cb_bufferunits.Items.AddRange(new object[] {
            "米（m）",
            "千米（km）"});
            this.cb_bufferunits.Location = new System.Drawing.Point(508, 59);
            this.cb_bufferunits.Name = "cb_bufferunits";
            this.cb_bufferunits.Size = new System.Drawing.Size(83, 20);
            this.cb_bufferunits.TabIndex = 51;
            this.cb_bufferunits.Text = "千米（km）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 50;
            this.label6.Text = "四级缓冲距离：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 49;
            this.label7.Text = "三级缓冲距离：";
            // 
            // nud_four
            // 
            this.nud_four.DecimalPlaces = 1;
            this.nud_four.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nud_four.Location = new System.Drawing.Point(404, 58);
            this.nud_four.Name = "nud_four";
            this.nud_four.Size = new System.Drawing.Size(52, 21);
            this.nud_four.TabIndex = 48;
            this.nud_four.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nud_three
            // 
            this.nud_three.DecimalPlaces = 1;
            this.nud_three.Location = new System.Drawing.Point(404, 26);
            this.nud_three.Name = "nud_three";
            this.nud_three.Size = new System.Drawing.Size(52, 21);
            this.nud_three.TabIndex = 47;
            this.nud_three.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "二级缓冲距离：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "一级缓冲距离：";
            // 
            // nud_two
            // 
            this.nud_two.DecimalPlaces = 1;
            this.nud_two.Location = new System.Drawing.Point(225, 58);
            this.nud_two.Name = "nud_two";
            this.nud_two.Size = new System.Drawing.Size(52, 21);
            this.nud_two.TabIndex = 44;
            this.nud_two.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_one
            // 
            this.nud_one.DecimalPlaces = 1;
            this.nud_one.Location = new System.Drawing.Point(225, 26);
            this.nud_one.Name = "nud_one";
            this.nud_one.Size = new System.Drawing.Size(52, 21);
            this.nud_one.TabIndex = 43;
            this.nud_one.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bt_flooutput);
            this.groupBox5.Controls.Add(this.tb_flooutput);
            this.groupBox5.Controls.Add(this.pictureBox5);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(12, 307);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(623, 92);
            this.groupBox5.TabIndex = 47;
            this.groupBox5.TabStop = false;
            // 
            // bt_flooutput
            // 
            this.bt_flooutput.Image = ((System.Drawing.Image)(resources.GetObject("bt_flooutput.Image")));
            this.bt_flooutput.Location = new System.Drawing.Point(525, 51);
            this.bt_flooutput.Name = "bt_flooutput";
            this.bt_flooutput.Size = new System.Drawing.Size(25, 25);
            this.bt_flooutput.TabIndex = 4;
            this.bt_flooutput.UseVisualStyleBackColor = true;
            this.bt_flooutput.Click += new System.EventHandler(this.bt_flooutput_Click);
            // 
            // tb_flooutput
            // 
            this.tb_flooutput.Location = new System.Drawing.Point(127, 55);
            this.tb_flooutput.Name = "tb_flooutput";
            this.tb_flooutput.Size = new System.Drawing.Size(369, 21);
            this.tb_flooutput.TabIndex = 3;
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
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "洪水淹没数据输出：";
            // 
            // tb_state
            // 
            this.tb_state.BackColor = System.Drawing.SystemColors.Control;
            this.tb_state.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_state.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_state.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tb_state.Location = new System.Drawing.Point(1, 451);
            this.tb_state.Name = "tb_state";
            this.tb_state.Size = new System.Drawing.Size(369, 14);
            this.tb_state.TabIndex = 46;
            this.tb_state.Text = "等待处理…";
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(389, 415);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 45;
            this.bt_cancel.Text = "取消";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(163, 415);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 44;
            this.bt_ok.Text = "确定";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_waterunits);
            this.groupBox2.Controls.Add(this.tb_highinput);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(623, 92);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // cb_waterunits
            // 
            this.cb_waterunits.FormattingEnabled = true;
            this.cb_waterunits.Items.AddRange(new object[] {
            "米（m）",
            "毫米（mm）"});
            this.cb_waterunits.Location = new System.Drawing.Point(310, 56);
            this.cb_waterunits.Name = "cb_waterunits";
            this.cb_waterunits.Size = new System.Drawing.Size(83, 20);
            this.cb_waterunits.TabIndex = 40;
            this.cb_waterunits.Text = "米（m）";
            // 
            // tb_highinput
            // 
            this.tb_highinput.Location = new System.Drawing.Point(127, 55);
            this.tb_highinput.Name = "tb_highinput";
            this.tb_highinput.Size = new System.Drawing.Size(177, 21);
            this.tb_highinput.TabIndex = 3;
            this.tb_highinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_highinput_KeyPress);
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
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入水位高程值：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_deminput);
            this.groupBox1.Controls.Add(this.tb_demnput);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 92);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // bt_deminput
            // 
            this.bt_deminput.Image = ((System.Drawing.Image)(resources.GetObject("bt_deminput.Image")));
            this.bt_deminput.Location = new System.Drawing.Point(525, 51);
            this.bt_deminput.Name = "bt_deminput";
            this.bt_deminput.Size = new System.Drawing.Size(25, 25);
            this.bt_deminput.TabIndex = 4;
            this.bt_deminput.UseVisualStyleBackColor = true;
            this.bt_deminput.Click += new System.EventHandler(this.bt_deminput_Click);
            // 
            // tb_demnput
            // 
            this.tb_demnput.Location = new System.Drawing.Point(127, 55);
            this.tb_demnput.Name = "tb_demnput";
            this.tb_demnput.Size = new System.Drawing.Size(369, 21);
            this.tb_demnput.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
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
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "地面高程数据：";
            // 
            // frmFlood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(640, 465);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tb_state);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "frmFlood";
            this.Text = "洪水淹没生态红线";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_four)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_three)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_two)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_one)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
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

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_bufferunits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_four;
        private System.Windows.Forms.NumericUpDown nud_three;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_two;
        private System.Windows.Forms.NumericUpDown nud_one;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bt_flooutput;
        private System.Windows.Forms.TextBox tb_flooutput;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_state;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_waterunits;
        private System.Windows.Forms.TextBox tb_highinput;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_deminput;
        private System.Windows.Forms.TextBox tb_demnput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;


    }
}