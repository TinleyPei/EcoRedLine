using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

using CommandLibrary;
using ESRI.ArcGIS.Geoprocessor;
using System.IO;

namespace EcoRedLine
{
    public partial class frmWaterConervation : DevComponents.DotNetBar.OfficeForm
    {
        private IPageLayoutControl _PageLayoutControl = null;

        public frmWaterConervation(IPageLayoutControl pPageLayoutControl)
        {
            InitializeComponent();
            this._PageLayoutControl = pPageLayoutControl;


            //禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //去除图标
            this.ShowIcon = false;

            tb_raininput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\rain.tif";
            tb_suninput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\sun.tif";
            tb_tminput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\ta_Resample.tif";
            tb_luinput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\LandUse.tif";
            tb_wcoutput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\waterConervations.tif";

        }



        private void bt_raininput_Click(object sender, EventArgs e)
        {
            //输入平均降水量文件
            tb_raininput.Text = null;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckPathExists = true;
            openfile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            openfile.Title = "打开";
            openfile.RestoreDirectory = true;
            DialogResult dr = openfile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_raininput.Text = openfile.FileName;
            }
        }

        private void bt_suninput_Click(object sender, EventArgs e)
        {
            //输入日照时长文件
            tb_suninput.Text = null;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckPathExists = true;
            openfile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            openfile.Title = "打开";
            openfile.RestoreDirectory = true;
            DialogResult dr = openfile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_suninput.Text = openfile.FileName;
            }
        }

        private void bt_tminput_Click(object sender, EventArgs e)
        {
            //输入平均温度文件
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

        private void bt_luinput_Click(object sender, EventArgs e)
        {
            //输入土地利用类型文件
            tb_luinput.Text = null;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckPathExists = true;
            openfile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            openfile.Title = "打开";
            openfile.RestoreDirectory = true;
            DialogResult dr = openfile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_luinput.Text = openfile.FileName;
            }
        }

        private void bt_wcoutput_Click(object sender, EventArgs e)
        {
            //输入水源涵养生态红线数据输出路径
            tb_wcoutput.Text = null;
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.CheckPathExists = true;
            savefile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            savefile.OverwritePrompt = true;
            savefile.Title = "保存";
            savefile.RestoreDirectory = true;
            savefile.FileName = "waterConervations";
            DialogResult dr = savefile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_wcoutput.Text = savefile.FileName+".tif";
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
                if (!File.Exists(tb_raininput.Text))
                {
                    MessageBox.Show("平均降水量数据输入路径不正确或文件被占用，请重新输入路径！", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (!File.Exists(tb_suninput.Text))
                {
                    MessageBox.Show("平均日照时长数据输入路径不正确或文件被占用，请重新输入路径！", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (!File.Exists(tb_tminput.Text))
                {
                    MessageBox.Show("平均温度数据输入路径不正确或文件被占用，请重新输入路径！", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (!File.Exists(tb_luinput.Text))
                {
                    MessageBox.Show("土地利用类型数据输入路径不正确或文件被占用，请重新输入路径！", "提示", MessageBoxButtons.OK);
                    return;
                }

            }
         catch (Exception ex)
            { 
                MessageBox.Show("设置路径不合法，请检查！");
                return;
            }            
            #endregion


            //水源涵养生态红线
            #region
            object sev = null;
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rc = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            try
            {

                //计算地表净辐射量（地表净辐射量=日照时长/20）
                string r;
                r= System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_r" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                rc.expression = "(\"" + tb_suninput.Text + "\")" + " / 20";
                rc.output_raster = r;
                tb_state.Text = "正在计算地表净辐射量……";
                gp.Execute(rc, null);
                tb_state.Text = "地表净辐射量计算完成！";



                //计算多年平均潜在蒸发量
                string pet, pet1, pet2, pet3, pet4, pet5;
                pet1 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_pet1" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                pet2 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_pet2" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                pet3 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_pet3" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                pet4 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_pet4" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                pet5 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_pet5" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                pet = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_pet" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                tb_state.Text = "正在计算多年平均潜在蒸发量……";
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 1";
                rc.output_raster = pet1;
                gp.Execute(rc, null);
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 2";
                rc.output_raster = pet2;
                gp.Execute(rc, null);
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 3";
                rc.output_raster = pet3;
                gp.Execute(rc, null);
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 4";
                rc.output_raster = pet4;
                gp.Execute(rc, null);
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 5";
                rc.output_raster = pet5;
                gp.Execute(rc, null);
                rc.expression = "(\"" + pet1 + "\"* 336.30)" + " + (\"" + pet2 + "\"* 314.70)" + " + (\"" + pet3 + "\"* 384.58)" + " + (\"" + pet4 + "\"* 182.81)" + " + (\"" + pet5 + "\"* 219.87)";
                rc.output_raster = pet;
                gp.Execute(rc, null);
                tb_state.Text = "多年平均潜在蒸发量计算完成！";


                //计算下垫面（土地覆盖）影响系数
                string w, w1, w2, w3, w4, w5;
                w1 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_w1" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                w2 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_w2" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                w3 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_w3" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                w4 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_w4" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                w5 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_w5" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                w = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_w" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                tb_state.Text = "正在计算下垫面（土地覆盖）影响系数……";
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 1";
                rc.output_raster = w1;
                gp.Execute(rc, null);
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 2";
                rc.output_raster = w2;
                gp.Execute(rc, null);
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 3";
                rc.output_raster = w3;
                gp.Execute(rc, null);
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 4";
                rc.output_raster = w4;
                gp.Execute(rc, null);
                rc.expression = "\"" + tb_luinput.Text + "\"" + " == 5";
                rc.output_raster = w5;
                gp.Execute(rc, null);
                rc.expression = "(\"" + pet1 + "\"* 0.5)" + " + (\"" + pet2 + "\"* 0.1)" + " + (\"" + pet3 + "\"* 1.5)" + " + (\"" + pet4 + "\"* 0.1)" + " + (\"" + pet5 + "\"* 0.5)";
                rc.output_raster = w;
                gp.Execute(rc, null);
                tb_state.Text = "下垫面（土地覆盖）影响系数计算完成！";



                //计算蒸散量（蒸散量=0.489+0.289*表净辐射量+0.023*平均温度）
                string et, et1, et2, et2_t;
                et1 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_et1" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                et2 = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_et2" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                et2_t = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_et2_t" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                et = System.IO.Path.GetDirectoryName(tb_wcoutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) + "_et" + System.IO.Path.GetExtension(tb_wcoutput.Text);
                tb_state.Text = "正在计算蒸散量……";
                rc.expression = "\"" + tb_raininput.Text + "\" + " + "\"" + w + "\" *  \"" + pet + "\"";
                rc.output_raster = et1;
                gp.Execute(rc, null);
                rc.expression = " 1 + " + "(\"" + w + "\" *  \"" + pet + "\" / (\"" + tb_raininput.Text + "\") + \"" + tb_raininput.Text + "\" / \"" + pet + "\")";
                rc.output_raster = et2_t;
                gp.Execute(rc, null);
                rc.expression = "Con(\"" + et2_t + "\"" + " != 0 ,\"" + et2_t + "\")";
                rc.output_raster = et2;
                gp.Execute(rc, null);
                rc.expression = "\"" + et1 + "\" / \"" + et2 + "\"";
                rc.output_raster = et;
                gp.Execute(rc, null);
                tb_state.Text = "蒸散量计算完成！";


                //计算水源涵养量(水源涵养量=多年平均降水量-蒸散量)
                rc.expression = "\"" + tb_raininput.Text + "\" - \"" + et + "\"";
                rc.output_raster = tb_wcoutput.Text;
                tb_state.Text = "正在计算水源涵养量……";
                gp.Execute(rc, null);
                tb_state.Text = "水源涵养量计算完成！";


                //删除临时文件
                if (tb_state.Text == "水源涵养量计算完成！")
                {
                    string[] files = Directory.GetFiles(System.IO.Path.GetDirectoryName(tb_wcoutput.Text), System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text)+"*");
                    foreach(string file in files)
                    {
                        if (System.IO.Path.GetFileNameWithoutExtension(tb_wcoutput.Text) != System.IO.Path.GetFileNameWithoutExtension(file))
                            File.Delete(file);
                    }

                }

                #endregion

            //将结果加载显示
            #region
                string mxfile=System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\水源涵养生态红线划分.mxd";
                IMapDocument pMapDocument = new MapDocumentClass();
                pMapDocument.Open(mxfile); //打开本地的地图文档，用来操作改mxd文件
                IMap pMap = pMapDocument.get_Map(0);
                IMapLayers pMapLayer = pMap as IMapLayers;
                IRasterLayer pRasterLayer = new RasterLayerClass();
                IWorkspaceFactory rasterWorkspaceFactory = new RasterWorkspaceFactoryClass();
                IRasterWorkspace rasterWorkspace = (IRasterWorkspace)rasterWorkspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(tb_wcoutput.Text), 0);
                IRasterDataset pRasterDataset1 = rasterWorkspace.OpenRasterDataset("waterConervations.tif");  //打开栅格图的文件名
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




    }
}



            
    
    
    
    
    
