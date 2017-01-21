using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
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
    public partial class frmBiodiversity : DevComponents.DotNetBar.OfficeForm
    {
        private IPageLayoutControl _PageLayoutControl = null;

        public frmBiodiversity(IPageLayoutControl pPageLayoutControl)
        {
            InitializeComponent();
            this._PageLayoutControl = pPageLayoutControl;

            //禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //去除图标
            this.ShowIcon = false;
            tb_nppinput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\sun.tif";
            tb_preinput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\rain.tif";
            tb_tminput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\ta_Resample.tif";
            tb_altinput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\dem.tif";
            tb_biooutput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\Biodiversity.tif";
        }

        private void bt_nppinput_Click(object sender, EventArgs e)
        {
            //输入生态系统净初级生产力平均值文件
            tb_nppinput.Text = null;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckPathExists = true;
            openfile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            openfile.Title = "打开";
            openfile.RestoreDirectory = true;
            DialogResult dr = openfile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_nppinput.Text = openfile.FileName;
            }

        }

        private void bt_preinput_Click(object sender, EventArgs e)
        {
            //输入平均年降水量（范围：0 - 1）文件
            tb_preinput.Text = null;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckPathExists = true;
            openfile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            openfile.Title = "打开";
            openfile.RestoreDirectory = true;
            DialogResult dr = openfile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_preinput.Text = openfile.FileName;
            }

        }

        private void bt_tminput_Click(object sender, EventArgs e)
        {
            //输入平均温度（（范围：0 - 1））文件
            tb_tminput.Text = null;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckPathExists = true;
            openfile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            openfile.Title = "打开";
            openfile.RestoreDirectory = true;
            DialogResult dr = openfile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_tminput.Text = openfile.FileName;
            }

        }

        private void bt_altinput_Click(object sender, EventArgs e)
        {
            //输入海拔参数数据文件
            tb_altinput.Text = null;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckPathExists = true;
            openfile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            openfile.Title = "打开";
            openfile.RestoreDirectory = true;
            DialogResult dr = openfile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_altinput.Text = openfile.FileName;
            }

        }

        private void bt_biooutput_Click(object sender, EventArgs e)
        {
            //输入生物多样性保护服务能力指数数据输出路径
            tb_biooutput.Text = null;
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.CheckPathExists = true;
            savefile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            savefile.OverwritePrompt = true;
            savefile.Title = "保存";
            savefile.RestoreDirectory = true;
            savefile.FileName = "Biodiversity";
            DialogResult dr = savefile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_biooutput.Text = savefile.FileName + ".tif";
            }

        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            //关闭当前窗口
            this.Close();

        }

        private void bt_ok_Click(object sender, EventArgs e)
        {

            //判断输入路径是否正确
            #region
            try
            {
                if (!File.Exists(tb_nppinput.Text))
                {
                    MessageBox.Show("生态系统净初级生产力平均值数据输入路径不正确或文件被占用，请重新输入路径！", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (!File.Exists(tb_preinput.Text))
                {
                    MessageBox.Show("平均年降水量数据输入路径不正确或文件被占用，请重新输入路径！", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (!File.Exists(tb_tminput.Text))
                {
                    MessageBox.Show("平均温度数据输入路径不正确或文件被占用，请重新输入路径！", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (!File.Exists(tb_altinput.Text))
                {
                    MessageBox.Show("海拔参数数据输入路径不正确或文件被占用，请重新输入路径！", "提示", MessageBoxButtons.OK);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("设置路径不合法，请检查！");
                return;
            }
            #endregion
            object sev = null;
            tb_state.Text = "正在处理……";
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rc = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.Float tofloat = new ESRI.ArcGIS.SpatialAnalystTools.Float();
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            try
            {
                //输入数据类型转换
                #region
                //npp输入数据转化为浮点型
                string floatfilepath_npp = System.IO.Path.GetDirectoryName(tb_biooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) + "_float_npp" + System.IO.Path.GetExtension(tb_biooutput.Text);
                tofloat.in_raster_or_constant = tb_nppinput.Text;
                tofloat.out_raster = floatfilepath_npp;
                gp.Execute(tofloat, null);

                //pre输入数据转化为浮点型
                string floatfilepath_pre = System.IO.Path.GetDirectoryName(tb_biooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) + "_float_pre" + System.IO.Path.GetExtension(tb_biooutput.Text);
                tofloat.in_raster_or_constant = tb_preinput.Text;
                tofloat.out_raster = floatfilepath_pre;
                gp.Execute(tofloat, null);

                //tm输入数据转化为浮点型
                string floatfilepath_tm = System.IO.Path.GetDirectoryName(tb_biooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) + "_float_tm" + System.IO.Path.GetExtension(tb_biooutput.Text);
                tofloat.in_raster_or_constant = tb_tminput.Text;
                tofloat.out_raster = floatfilepath_tm;
                gp.Execute(tofloat, null);

                //alt输入数据转化为浮点型
                string floatfilepath_alt = System.IO.Path.GetDirectoryName(tb_biooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) + "_float_alt" + System.IO.Path.GetExtension(tb_biooutput.Text);
                tofloat.in_raster_or_constant = tb_altinput.Text;
                tofloat.out_raster = floatfilepath_alt;
                gp.Execute(tofloat, null);
                #endregion


                //输入数据进行归一化处理
                #region
                //npp数据归一化处理
                string npp;
                npp = System.IO.Path.GetDirectoryName(tb_biooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) + "_npp" + System.IO.Path.GetExtension(tb_biooutput.Text);
                rc.expression = "(\"" + floatfilepath_npp + "\" - " + GetMinPixelValue(floatfilepath_npp).ToString() + ") / (" + (GetMaxPixelValue(floatfilepath_npp) - GetMinPixelValue(floatfilepath_npp)).ToString() + ")";
                rc.output_raster = npp;
                tb_state.Text = "正在对生态系统净初级生产力平均值进行归一化……";
                gp.Execute(rc, null);
                tb_state.Text = "生态系统净初级生产力平均值归一化处理完成！";

                //pre数据归一化处理
                string pre;
                pre = System.IO.Path.GetDirectoryName(tb_biooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) + "_pre" + System.IO.Path.GetExtension(tb_biooutput.Text);
                rc.expression = "(\"" + floatfilepath_pre + "\" - " + GetMinPixelValue(floatfilepath_pre).ToString() + ") / (" + (GetMaxPixelValue(floatfilepath_pre) - GetMinPixelValue(floatfilepath_pre)).ToString() + ")";
                rc.output_raster = pre;
                tb_state.Text = "正在对平均年降水量数据进行归一化……";
                gp.Execute(rc, null);
                tb_state.Text = "平均年降水量数据归一化处理完成！";

                //tm数据归一化处理
                string tm;
                tm = System.IO.Path.GetDirectoryName(tb_biooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) + "_tm" + System.IO.Path.GetExtension(tb_biooutput.Text);
                rc.expression = "(\"" + floatfilepath_tm + "\" - " + GetMinPixelValue(floatfilepath_tm).ToString() + ") / (" + (GetMaxPixelValue(floatfilepath_tm) - GetMinPixelValue(floatfilepath_tm)).ToString() + ")";
                rc.output_raster = tm;
                tb_state.Text = "正在对平均温度进行归一化……";
                gp.Execute(rc, null);
                tb_state.Text = "平均温度归一化处理完成！";

                //alt数据归一化处理
                string alt;
                alt = System.IO.Path.GetDirectoryName(tb_biooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) + "_alt" + System.IO.Path.GetExtension(tb_biooutput.Text);
                rc.expression = "(\"" + floatfilepath_alt + "\" - " + GetMinPixelValue(floatfilepath_alt).ToString() + ") / (" + (GetMaxPixelValue(floatfilepath_alt) - GetMinPixelValue(floatfilepath_alt)).ToString() + ")";
                rc.output_raster = alt;
                tb_state.Text = "正在对海拔参数数据进行归一化……";
                gp.Execute(rc, null);
                tb_state.Text = "海拔参数数据归一化处理完成！";
                #endregion


                //计算生物多样性保护服务能力指数
                rc.expression = "\"" + npp + "\" * \"" + pre + "\" * \"" + tm + "\" * ( 1 - \"" + alt + "\" )";
                rc.output_raster = tb_biooutput.Text;
                tb_state.Text = "正在计算计算生物多样性保护服务能力指数……";
                gp.Execute(rc, null);
                tb_state.Text = "计算生物多样性保护服务能力指数计算完成！";


                //删除临时文件
                if (tb_state.Text == "计算生物多样性保护服务能力指数计算完成！")
                {
                    string[] files = Directory.GetFiles(System.IO.Path.GetDirectoryName(tb_biooutput.Text), System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) + "*");
                    foreach (string file in files)
                    {
                        if (System.IO.Path.GetFileNameWithoutExtension(tb_biooutput.Text) != System.IO.Path.GetFileNameWithoutExtension(file))
                            File.Delete(file);
                    }
                }



                //将结果加载显示
                #region
                string mxfile = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\生物多样性生态红线划分.mxd";
                IMapDocument pMapDocument = new MapDocumentClass();
                pMapDocument.Open(mxfile); //打开本地的地图文档，用来操作改mxd文件
                IMap pMap = pMapDocument.get_Map(0);
                IMapLayers pMapLayer = pMap as IMapLayers;
                IRasterLayer pRasterLayer = new RasterLayerClass();
                IWorkspaceFactory rasterWorkspaceFactory = new RasterWorkspaceFactoryClass();
                IRasterWorkspace rasterWorkspace = (IRasterWorkspace)rasterWorkspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(tb_biooutput.Text), 0);
                IRasterDataset pRasterDataset1 = rasterWorkspace.OpenRasterDataset("Biodiversity.tif");  //打开栅格图的文件名
                pRasterLayer.CreateFromDataset(pRasterDataset1);    //创建    
                pRasterLayer = pMapLayer.get_Layer(0) as IRasterLayer;
                pRasterLayer.CreateFromDataset(pRasterDataset1);
                pMapDocument.Save(true, true);//保存更改完路径后的mxd文件

                _PageLayoutControl.LoadMxFile(mxfile);
                _PageLayoutControl.Extent = _PageLayoutControl.FullExtent;
                _PageLayoutControl.ZoomToWholePage();


                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(gp.GetMessages(ref sev), "提示", MessageBoxButtons.OK);
            }


        }

        //获取栅格最大值
        public double GetMaxPixelValue(string fullfilepath)
        {
            double max = 0;
            IGeoProcessor2 gp = new GeoProcessorClass();
            gp.OverwriteOutput = true;
            IGeoProcessorResult result = new GeoProcessorResultClass();
            IVariantArray parameters = new VarArrayClass();
            parameters.Add(fullfilepath);
            parameters.Add("MAXIMUM");
            result = gp.Execute("GetRasterProperties_management", parameters, null);
            max = Convert.ToDouble(result.ReturnValue);
            return max;
        }

        //获取栅格最小值
        public double GetMinPixelValue(string fullfilepath)
        {
            double min = 0;
            IGeoProcessor2 gp = new GeoProcessorClass();
            gp.OverwriteOutput = true;
            IGeoProcessorResult result = new GeoProcessorResultClass();
            IVariantArray parameters = new VarArrayClass();
            parameters.Add(fullfilepath);
            parameters.Add("MINIMUM");
            result = gp.Execute("GetRasterProperties_management", parameters, null);
            min = Convert.ToDouble(result.ReturnValue);
            return min;
        }

    }
}
