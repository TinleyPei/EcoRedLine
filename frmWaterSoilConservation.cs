using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SpatialAnalyst;

using CommandLibrary;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessor;
using System.IO;

namespace EcoRedLine
{
    public partial class frmWaterSoilConservation : DevComponents.DotNetBar.OfficeForm
    {

        //临时文件夹
        string Temfile = @"C:\DaliTemfile";
        private IPageLayoutControl _PageLayoutControl = null;
        public frmWaterSoilConservation(IPageLayoutControl pPageLayoutControl)
        {
            InitializeComponent();
            this._PageLayoutControl = pPageLayoutControl;
           
        }
        //1计算参数R中的变量
        string sR = null;
        string strExp = "";
        string sR2 = null;
        string sR3 = null;
        //2计算参数K中的变量
        string sK;
        string sfcsand;
        string sfcisi;
        string sfargc;
        string sfhisand;
        string CalKpath = null;
        //3计算参数LS中的变量
        string sS;
        string sM;
        string sLs;
        string Calspath = null;
        string Calmpath = null;
        string Callspath = null;
        string FlowAcc = null;
        //4计算参数C中的变量
        string sC;
        string CalCpath;
        //5计算P参数中的变量
        string sP;
        //最后计算A
        string sA;
        

        private void frmSoilRunOffSpatial_Load(object sender, EventArgs e)
        {
            
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtR.Text = dlg.FileName;
            }
        }
        string filePath_temp;//路径存储中间量
        private void btnOpenPcp_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();//选择存储文件
            folderBrowserDialog1.Description = "请选择文件夹";
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            System.Windows.Forms.DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                filePath_temp = folderBrowserDialog1.SelectedPath;
            }
            txtPcpPath.Text = filePath_temp;
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtYear.Text = dlg.FileName;
            }
        }

        private void btSoilClay_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtSoilClay.Text = dlg.FileName;
            }
        }

        private void btSoilSlit_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtSoilSlit.Text = dlg.FileName;
            }
        }

        private void btSoilSand_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtSoilSand.Text = dlg.FileName;
            }
        }

        private void btSoilOrganic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtSoilOrganic.Text = dlg.FileName;
            }
        }

        private void btDem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtDem.Text = dlg.FileName;
            }
        }

        private void btC_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtC.Text = dlg.FileName;
            }
        }

        private void btP_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtP.Text = dlg.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSoilClay.Text.Equals(""))
            {
                MessageBox.Show("请选择输入土壤黏粒含量(%)数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSoilSlit.Text.Equals(""))
            {
                MessageBox.Show("请选择输入土壤粉粒含量(%)数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSoilSand.Text.Equals(""))
            {
                MessageBox.Show("请选择输入土壤砂粒含量(%)数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSoilOrganic.Text.Equals(""))
            {
                MessageBox.Show("请选择输入土壤有机物含量(%)数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDem.Text.Equals(""))
            {
                MessageBox.Show("请选择输入DEM数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtC.Text.Equals(""))
            {
                MessageBox.Show("请选择输入地表覆被因子相关数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtP.Text.Equals(""))
            {
                MessageBox.Show("请选择输入水土保持措施因子数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSavePath.Text.Equals(""))
            {
                MessageBox.Show("请选择结果输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rbtnR.Checked && txtR.Text.Equals(""))
            {
                MessageBox.Show("请选择输入降雨侵蚀力因子R相关数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((!rbtnR.Checked) && txtPcpPath.Text.Equals(""))
            {
                MessageBox.Show("请选择输入多年平均各月降雨量数据所在路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((!rbtnR.Checked) && txtPcpPrefix.Text.Equals(""))
            {
                MessageBox.Show("请输入数据前缀(如：pcp_*)！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((!rbtnR.Checked) && txtPcpSuffix.Text.Equals(""))
            {
                MessageBox.Show("请输入数据后缀(如：tif)！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((!rbtnR.Checked) && txtYear.Text.Equals(""))
            {
                MessageBox.Show("请输入年平均降水量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //现创建一个存放临时文件的临时文件夹
            string newPath = System.IO.Path.Combine(Temfile, "");
            System.IO.Directory.CreateDirectory(newPath);

            this.rtxtState.AppendText("正在执行，请您耐心等待...\n");
            this.rtxtState.ScrollToCaret();
            this.rtxtState.AppendText("开始准备配置文件...\n");
            this.rtxtState.ScrollToCaret();
            IVariantArray parameters = new VarArrayClass();
            Geoprocessor GP = new Geoprocessor();
            this.rtxtState.AppendText("准备调用GP工具箱...\n");
            this.rtxtState.ScrollToCaret();
            //ESRI.ArcGIS.DataManagementTools.GetRasterProperties NDVIMin = new ESRI.ArcGIS.DataManagementTools.GetRasterProperties();
            //ESRI.ArcGIS.DataManagementTools.GetRasterProperties NDVIMax = new ESRI.ArcGIS.DataManagementTools.GetRasterProperties();
            ESRI.ArcGIS.SpatialAnalystTools.Slope slo = new ESRI.ArcGIS.SpatialAnalystTools.Slope();//计算坡度
            ESRI.ArcGIS.SpatialAnalystTools.Fill demFill = new ESRI.ArcGIS.SpatialAnalystTools.Fill();
            ESRI.ArcGIS.SpatialAnalystTools.FlowDirection Filldec = new ESRI.ArcGIS.SpatialAnalystTools.FlowDirection();
            ESRI.ArcGIS.SpatialAnalystTools.FlowAccumulation DecAcc = new ESRI.ArcGIS.SpatialAnalystTools.FlowAccumulation();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCals = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCalm = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCalLS = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCalR = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCalK = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCalA = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCalC = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            //1计算参数R

            if (rbtnR.Checked)
            {
                sR = txtR.Text;
                this.rtxtState.AppendText("降水侵蚀因子R读取成功，准备计算参数K...\n");
                this.rtxtState.ScrollToCaret();

            }
            else
            {
                this.rtxtState.AppendText("开始计算参数R...\n");
                this.rtxtState.ScrollToCaret();
                string sFileName = "";
                string sYear = txtYear.Text;
                for (int i = 1; i < 13; i++)
                {
                    sFileName = txtPcpPath.Text + "\\" + this.txtPcpPrefix.Text + i.ToString() + "." + this.txtPcpSuffix.Text;
                    strExp = "(1.735 * Power(10,1.5 * Log10((" + "\"" + sFileName + "\"" + " * " + "\"" + sFileName + "\"" + ") /" + "\"" + txtYear.Text + "\")" + " - 0.08188))";
                    if (i < 12)
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
                sR = Temfile + "\\CalR.tif";
                sCalR.output_raster = sR;
                GP.Execute(sCalR, null);
                this.rtxtState.AppendText("降水侵蚀因子R计算成功，准备计算参数K...\n");
                this.rtxtState.ScrollToCaret();
            }

            //2计算参数K
            sK = "(0.2 + 0.3 * Exp(-0.0256 *" + "\"" + txtSoilSand.Text + "\"" + "* (1.0 - " + "\"" + txtSoilSlit.Text + "\"" + " / 100.0))) * Power((" + "\"" + txtSoilSlit.Text + "\"" + " * 1.0 / (" + "\"" + txtSoilClay.Text + "\"" + " * 1.0 + " + "\"" + txtSoilSlit.Text + "\"" + " * 1.0)), 0.3) * (1.0 - 0.25 * " + "\"" + txtSoilOrganic.Text + "\"" + " * 0.58 / (" + "\"" + txtSoilOrganic.Text + "\"" + " * 0.58 + Exp(3.72 - 2.95 * " + "\"" + txtSoilOrganic.Text + "\"" + " * 0.58))) * (1.0 - (0.7 * (1.0 - " + "\"" + txtSoilSand.Text + "\"" + " / 100.0)) / ((1.0 - " + "\"" + txtSoilSand.Text + "\"" + " / 100.0) + Exp(-5.51 + 22.9 * (1.0 - " + "\"" + txtSoilSand.Text + "\"" + " / 100.0))))";
            sCalK.expression = sK;
            CalKpath = Temfile + "\\CalK.tif";
            sCalK.output_raster = CalKpath;
            GP.Execute(sCalK, null);
            this.rtxtState.AppendText("土壤可蚀性因子K计算成功...\n");
            this.rtxtState.ScrollToCaret();
            this.rtxtState.AppendText("准备计算地形因子LS...\n");
            this.rtxtState.ScrollToCaret();
            //3计算参数LS
            //Fill Dem
            this.rtxtState.AppendText("开始填充洼地...\n");
            this.rtxtState.ScrollToCaret();
            demFill.in_surface_raster = txtDem.Text;
            demFill.out_surface_raster = Temfile + "\\demFill.tif";
            GP.Execute(demFill, null);
            // cal FlowDirection
            this.rtxtState.AppendText("开始计算流向...\n");
            this.rtxtState.ScrollToCaret();
            Filldec.in_surface_raster = Temfile + "\\demFill.tif";
            Filldec.out_flow_direction_raster = Temfile + "\\FillDec.tif";
            GP.Execute(Filldec, null);
            //cal FlowAccumulation
            this.rtxtState.AppendText("开始计算流量...\n");
            this.rtxtState.ScrollToCaret();
            Filldec.in_surface_raster = Temfile + "\\FillDec.tif";
            FlowAcc = Temfile + "\\FlowAcc.tif";
            Filldec.out_flow_direction_raster = FlowAcc;
            GP.Execute(Filldec, null);

            //先计算坡度
            this.rtxtState.AppendText("开始计算坡度...\n");
            this.rtxtState.ScrollToCaret();
            slo.in_raster = txtDem.Text;
            slo.output_measurement = "DEGREE";
            slo.z_factor = 1;
            string sRoad1 = Temfile + "\\Slope.tif";
            slo.out_raster = sRoad1;
            GP.Execute(slo, null);//坡度计算
            //cal S
            sS = "Con(" + "\"" + sRoad1 + "\"" + " < 5,10.8 * Sin(" + "\"" + sRoad1 + "\"" + " * 3.14 / 180) + 0.03,Con(" + "\"" + sRoad1 + "\"" + " >= 10,21.9 * Sin(" + "\"" + sRoad1 + "\"" + " * 3.14 / 180) - 0.96,16.8 * Sin(" + "\"" + sRoad1 + "\"" + " * 3.14 / 180) - 0.5))";
            sCals.expression = sS;
            Calspath = Temfile + "\\CalS.tif";
            sCals.output_raster = Calspath;
            GP.Execute(sCals, null);
            //cal m
            sM = "Con(" + "\"" + sRoad1 + "\"" + " <= 1,0.2,Con(" + "\"" + sRoad1 + "\"" + " <= 3,0.3,Con(" + "\"" + sRoad1 + "\"" + " <= 5,0.4,0.5)))";
            sCalm.expression = sM;
            Calmpath = Temfile + "\\CalM.tif";
            sCalm.output_raster = Calmpath;
            GP.Execute(sCalm, null);
            //cal ls
            sLs = "\"" + Calspath + "\"" + " * Power((" + "\"" + CalKpath + "\"" + " * " + this.txtCellSize.Text + " / 22.1)," + "\"" + Calmpath + "\"" + ")";
            sCalLS.expression = sLs;
            Callspath = Temfile + "\\CalLS.tif";
            sCalm.output_raster = Calmpath;
            sCalLS.output_raster = Callspath;
            GP.Execute(sCalLS, null);
            this.rtxtState.AppendText("地形因子LS计算成功...\n");
            this.rtxtState.ScrollToCaret();

            //4计算参数C
            if (rbtnVegCover.Checked)
            {
                CalCpath = txtC.Text;
                this.rtxtState.AppendText("地表覆盖因子C读取成功...\n");
                this.rtxtState.ScrollToCaret();
            }
            else
            {
                this.rtxtState.AppendText("准备计算地表覆盖因子C...\n");
                this.rtxtState.ScrollToCaret();
                //计算NDVI最小值
                //NDVIMin.in_raster = txtC.Text;
                //CalKpath = txtDem.Text + "/CalK.tif";
                //NDVIMin.property_type = "MINIMUM";
                //GP.Execute(sCalK, null);
                double dMin = 0;
                IGeoProcessor2 gp = new GeoProcessorClass();
                gp.OverwriteOutput = true;
                // Create a variant array to hold the parameter values.
                IVariantArray parameters2 = new VarArrayClass();
                IGeoProcessorResult result = new GeoProcessorResultClass();
                // Set parameter values.
                parameters2.Add(txtC.Text);
                parameters2.Add("MINIMUM");
                result = gp.Execute("GetRasterProperties_management", parameters2, null);
                dMin = (double)result.ReturnValue;

                //计算NDVI最大值
                double dMax = 0;
                IGeoProcessor2 gp2 = new GeoProcessorClass();
                gp2.OverwriteOutput = true;
                // Create a variant array to hold the parameter values.
                IVariantArray parameters3 = new VarArrayClass();
                IGeoProcessorResult result3 = new GeoProcessorResultClass();
                // Set parameter values.
                parameters3.Add(txtC.Text);
                parameters3.Add("MAXIMUM");
                result3 = gp2.Execute("GetRasterProperties_management", parameters3, null);
                dMax = (double)result3.ReturnValue;

                //最后计算C
                sC = "(" + "\"" + txtC.Text + "\"" + " - " + dMin + ") / (" + dMax + " - " + dMin + ")";
                sCalC.expression = sC;
                CalCpath = Temfile + "\\CalC.tif";
                sCalC.output_raster = CalCpath;
                GP.Execute(sCalC, null);
                this.rtxtState.AppendText("地表覆盖因子C计算成功...\n");
                this.rtxtState.ScrollToCaret();
            }


            //5计算P
            sP = txtP.Text;
            this.rtxtState.AppendText("读取水土保持措施因子P...\n");
            this.rtxtState.ScrollToCaret();
            //最后开始计算A=R*K*LS*C*P
            this.rtxtState.AppendText("准备计算水土流失方程...\n");
            this.rtxtState.ScrollToCaret();
            sA = "\"" + sR + "\"" + " * " + "\"" + CalKpath + "\"" + " * " + "\"" + Callspath + "\"" + " * (1 - " + "\"" + CalCpath + "\"" + ") * " + "\"" + sP + "\"";
            sCalA.expression = sA;

            sCalA.output_raster = txtSavePath.Text;
            GP.Execute(sCalA, null);
            //删除临时文件夹
            string deleteFile = Temfile;
            DeleteFolder(deleteFile);
            this.rtxtState.AppendText("计算成功，已将结果成功保存...\n");
            this.rtxtState.ScrollToCaret();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "(*.tif)|*.tif|(*.*)|*.*";
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "保存";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = "SWCons.tif";

            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                this.txtSavePath.Text = saveDlg.FileName;
        }

        private void chkbCellsize_CheckedChanged(object sender, EventArgs e)
        {
        txtCellSize.Enabled = chkbCellsize.Checked;
        }

        private void rbtnPcp_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPcpPath.Enabled = ((RadioButton)sender).Checked;
            this.btnOpenPcp.Enabled = ((RadioButton)sender).Checked;
            this.txtPcpPrefix.Enabled = ((RadioButton)sender).Checked;
            this.txtPcpSuffix.Enabled = ((RadioButton)sender).Checked;
            this.btnYear.Enabled = ((RadioButton)sender).Checked;
            this.txtYear.Enabled = ((RadioButton)sender).Checked;
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