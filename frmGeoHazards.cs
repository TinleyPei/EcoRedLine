using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EcoRedLine
{
    public partial class frmGeoHazards : DevComponents.DotNetBar.OfficeForm
    {
        private IPageLayoutControl _PageLayoutControl = null;
        public frmGeoHazards(IPageLayoutControl pPageLayoutControl)
        {
            InitializeComponent();
            this._PageLayoutControl = pPageLayoutControl;
        }
        int index = 0;
        int Onebt = 0;
        //临时文件夹
        string Temfile = @"C:\DaliTemfile2";
        //1计算参数R中的变量
        string sR = null;
        string strExp = "";
        string sR2 = null;
        string sR3 = null;
        private void frmGeoHazards_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();

            col.HeaderText = "数据文件";
            col1.HeaderText = "权重";

            dataGridView1.Columns.Add(col);
            dataGridView1.Columns.Add(col1);

            dataGridView1.Columns[0].Width = 443;
            dataGridView1.Columns[1].Width = 55;
        }

        private void btInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtInput.Text = dlg.FileName;
            }
            Onebt = 1;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            dataGridView1.Rows.Add(row);
            dataGridView1.Rows[index].Cells[0].Value = txtInput.Text;
            index += 1;
            txtInput.Clear();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                index -= 1;
            }
            catch (Exception ex)
            {
                // Print geoprocessing execution error messages.
                MessageBox.Show("请用鼠标点击选中！");
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "保存";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = "地质灾害生态红线.tif";

            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                this.txtSavePath.Text = saveDlg.FileName;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            int sExcute = 0;
            int sIsNul = 0;
            int sIsThan = 0;
            double sAll = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {


                if (this.dataGridView1.Rows[i].Cells[1].Value == null)
                {
                    sIsNul = 1;    //如果权重存在空值，sIsNul=1
                }
                else
                {
                    double ssRow = double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString());
                    sAll = sAll + ssRow;
                }

            }
            if ((sAll != 1.0) && (sIsNul == 0))
            {
                sIsThan = 1;  //如果权重之和不为1，sIsThan=1
            }
            //判断权重是否为空
            if (sIsNul == 1)
            {
                MessageBox.Show("请您输入数据权重！");
            }
            //判断权重之和是否等于1
            if (sIsThan == 1)
            {
                MessageBox.Show("请您确保输入的权重之和等于1");
            }
            if (txtSavePath.Equals(""))
            {
                MessageBox.Show("请选择输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //准备后续执行

            if ((sIsNul == 0) && (sIsThan == 0) && (Onebt == 1))
            {
                //现创建一个存放临时文件的临时文件夹
                string newPath = System.IO.Path.Combine(Temfile, "");
                System.IO.Directory.CreateDirectory(newPath);
                this.rtxtState.AppendText("正在执行，请您耐心等待...\n");
                this.rtxtState.ScrollToCaret();
                this.rtxtState.AppendText("准备调用GP工具箱...\n");
                this.rtxtState.ScrollToCaret();
                IVariantArray parameters = new VarArrayClass();
                Geoprocessor GP = new Geoprocessor();

                ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCalR = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
                this.rtxtState.AppendText("开始遍历读取表中数据...\n");
                this.rtxtState.ScrollToCaret();
                this.rtxtState.AppendText("开始对栅格数据重分类...\n");
                this.rtxtState.ScrollToCaret();
                for (int m = 0; m < this.dataGridView1.Rows.Count - 1; m++)
                {
                    string sFileName;
                    sFileName = Temfile + "\\重分类" + (m + 1).ToString() + ".tif";
                    //计算栅格最小值
                    double dMin0 = 0;
                    IGeoProcessor2 gp = new GeoProcessorClass();
                    gp.OverwriteOutput = true;
                    // Create a variant array to hold the parameter values.
                    IVariantArray parameters2 = new VarArrayClass();
                    IGeoProcessorResult result = new GeoProcessorResultClass();
                    // Set parameter values.
                    parameters2.Add(this.dataGridView1.Rows[m].Cells[0].Value.ToString());
                    parameters2.Add("MINIMUM");
                    result = gp.Execute("GetRasterProperties_management", parameters2, null);
                    dMin0 = (double)result.ReturnValue;
                    int dMin = (int)dMin0;
                    //计算栅格最大值
                    double dMax0 = 0;
                    IGeoProcessor2 gp2 = new GeoProcessorClass();
                    gp2.OverwriteOutput = true;
                    // Create a variant array to hold the parameter values.
                    IVariantArray parameters3 = new VarArrayClass();
                    IGeoProcessorResult result3 = new GeoProcessorResultClass();
                    // Set parameter values.
                    parameters3.Add(this.dataGridView1.Rows[m].Cells[0].Value.ToString());
                    parameters3.Add("MAXIMUM");
                    result3 = gp2.Execute("GetRasterProperties_management", parameters3, null);
                    dMax0 = (double)result3.ReturnValue;
                    int dMax = (int)dMax0;
                    //计算分类区间
                    int Avera = (dMax - dMin) / 4;
                    int interval1 = dMin + Avera;
                    int interval2 = dMin + 2 * Avera;
                    int interval3 = dMin + 3 * Avera;
                    //开始对数据进行重分类
                    ESRI.ArcGIS.SpatialAnalystTools.Reclassify tReclass = new ESRI.ArcGIS.SpatialAnalystTools.Reclassify();
                    tReclass.in_raster = this.dataGridView1.Rows[m].Cells[0].Value.ToString();
                    tReclass.missing_values = "NODATA";
                    tReclass.out_raster = sFileName;
                    tReclass.reclass_field = "VALUE";
                    //tReclass.remap = "1400 2176 1;2176 2538 2;2538 3040 3;3040 4073 4";
                    tReclass.remap = dMin.ToString() + " " + interval1.ToString() + " " + "1;" + interval1.ToString() + " " + interval2.ToString() + " " + "2;" + interval2.ToString() + " " + interval3.ToString() + " " + "3;" + interval3.ToString() + " " + dMax.ToString() + " " + "4;";
                    // ScrollToBottom("Reclassify");  
                    //tGeoResult = (IGeoProcessorResult)tGp.Execute(tReclass, null);  
                    GP.Execute(tReclass, null);

                }
                this.rtxtState.AppendText("输入数据重分类完成...\n");
                this.rtxtState.ScrollToCaret();
                //开始进行栅格计算
                this.rtxtState.AppendText("开始准备进行栅格加权运算...\n");
                this.rtxtState.ScrollToCaret();
                string sFileName2 = "重分类";
                string sRoad = Temfile + "\\重分类";
                for (int n = 1; n < this.dataGridView1.Rows.Count; n++)
                {
                    sFileName2 = sRoad + n.ToString() + "." + "tif";
                    strExp = "\"" + sFileName2 + "\"" + "*" + double.Parse(this.dataGridView1.Rows[n - 1].Cells[1].Value.ToString());
                    if (n < this.dataGridView1.Rows.Count - 1)
                    {
                        sR2 = sR2 + strExp + "+";
                    }
                    else
                    {
                        sR2 = sR2 + strExp;
                    }
                }
                sR3 = sR2;
                sCalR.expression = sR3;
                sR = Temfile + "\\地质灾害.tif";
                sCalR.output_raster = sR;
                GP.Execute(sCalR, null);
                this.rtxtState.AppendText("栅格计算成功，得到地质灾害分布栅格影像...\n");
                this.rtxtState.ScrollToCaret();
                this.rtxtState.AppendText("开始对地质灾害影像进行重分类...\n");
                this.rtxtState.ScrollToCaret();
                //开始准备对生成的地质灾害.tif进行分类
                //计算栅格最小值
                double dMin02 = 0;
                IGeoProcessor2 gp3 = new GeoProcessorClass();
                gp3.OverwriteOutput = true;
                // Create a variant array to hold the parameter values.
                IVariantArray parameters22 = new VarArrayClass();
                IGeoProcessorResult result22 = new GeoProcessorResultClass();
                // Set parameter values.
                parameters22.Add(sR);
                parameters22.Add("MINIMUM");
                result22 = gp3.Execute("GetRasterProperties_management", parameters22, null);
                dMin02 = (double)result22.ReturnValue;

                //计算栅格最大值
                double dMax02 = 0;
                IGeoProcessor2 gp4 = new GeoProcessorClass();
                gp4.OverwriteOutput = true;
                // Create a variant array to hold the parameter values.
                IVariantArray parameters33 = new VarArrayClass();
                IGeoProcessorResult result33 = new GeoProcessorResultClass();
                // Set parameter values.
                parameters33.Add(sR);
                parameters33.Add("MAXIMUM");
                result33 = gp4.Execute("GetRasterProperties_management", parameters33, null);
                dMax02 = (double)result33.ReturnValue;

                //计算分类区间
                double Avera2 = (dMax02 - dMin02) / 4;
                double interval12 = dMin02 + Avera2;
                double interval22 = dMin02 + 2 * Avera2;
                double interval32 = dMin02 + 3 * Avera2;

                //开始对地质灾害.tif重分类
                ESRI.ArcGIS.SpatialAnalystTools.Reclassify tReclass2 = new ESRI.ArcGIS.SpatialAnalystTools.Reclassify();

                tReclass2.in_raster = Temfile + "\\地质灾害.tif";
                tReclass2.missing_values = "NODATA";
                tReclass2.out_raster = txtSavePath.Text;
                tReclass2.reclass_field = "VALUE";
                //tReclass.remap = "1400 2176 1;2176 2538 2;2538 3040 3;3040 4073 4";
                tReclass2.remap = dMin02.ToString() + " " + interval12.ToString() + " " + "1;" + interval12.ToString() + " " + interval22.ToString() + " " + "2;" + interval22.ToString() + " " + interval32.ToString() + " " + "3;" + interval32.ToString() + " " + dMax02.ToString() + " " + "4;";
                // ScrollToBottom("Reclassify");  
                //tGeoResult = (IGeoProcessorResult)tGp.Execute(tReclass, null);  
                GP.Execute(tReclass2, null);
                //删除临时文件夹
                string deleteFile = Temfile;
                DeleteFolder(deleteFile);
                this.rtxtState.AppendText("完成地质灾害生态红线的划分，已将结果成功保存...\n");
                this.rtxtState.ScrollToCaret();

            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //删除临时文件夹函数
        public void DeleteFolder(string deleteDirectory)
        {
            if (Directory.Exists(deleteDirectory))
            {
                foreach (string deleteFile in Directory.GetFileSystemEntries(deleteDirectory))
                {
                    if (File.Exists(deleteFile))
                        File.Delete(deleteFile);
                    else
                        DeleteFolder(deleteFile);
                }
                Directory.Delete(deleteDirectory);
            }
        }
    }
}
