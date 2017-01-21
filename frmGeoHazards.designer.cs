namespace EcoRedLine
{
    partial class frmGeoHazards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeoHazards));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btInput = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtxtState = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btRemove = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.btInput);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnSavePath);
            this.groupBox1.Controls.Add(this.txtSavePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btRemove);
            this.groupBox1.Controls.Add(this.btAdd);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 459);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // btInput
            // 
            this.btInput.Image = ((System.Drawing.Image)(resources.GetObject("btInput.Image")));
            this.btInput.Location = new System.Drawing.Point(559, 14);
            this.btInput.Name = "btInput";
            this.btInput.Size = new System.Drawing.Size(25, 25);
            this.btInput.TabIndex = 56;
            this.btInput.UseVisualStyleBackColor = true;
            this.btInput.Click += new System.EventHandler(this.btInput_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtxtState);
            this.groupBox3.Location = new System.Drawing.Point(170, 339);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 125);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "状态窗口";
            // 
            // rtxtState
            // 
            this.rtxtState.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rtxtState.Location = new System.Drawing.Point(6, 20);
            this.rtxtState.Name = "rtxtState";
            this.rtxtState.Size = new System.Drawing.Size(425, 96);
            this.rtxtState.TabIndex = 29;
            this.rtxtState.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btOk);
            this.groupBox2.Controls.Add(this.btCancel);
            this.groupBox2.Location = new System.Drawing.Point(12, 352);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 102);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(11, 36);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(51, 23);
            this.btOk.TabIndex = 7;
            this.btOk.Text = "确定";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(79, 37);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(57, 22);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePath.Image")));
            this.btnSavePath.Location = new System.Drawing.Point(559, 308);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(25, 25);
            this.btnSavePath.TabIndex = 27;
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(69, 310);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(475, 21);
            this.txtSavePath.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "输出路径：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(532, 253);
            this.dataGridView1.TabIndex = 10;
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(551, 160);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(52, 20);
            this.btRemove.TabIndex = 5;
            this.btRemove.Text = "移除";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(551, 92);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(52, 22);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "添加";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(69, 16);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(475, 21);
            this.txtInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入数据：";
            // 
            // frmGeoHazards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(611, 459);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "frmGeoHazards";
            this.Text = "地质灾害生态红线";
            this.Load += new System.EventHandler(this.frmGeoHazards_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btInput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtxtState;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;

    }
}