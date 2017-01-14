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
        private IMap pMap;
        private IMapAlgebraOp pMapAlgebraOp = null;
        private List<IGeoDataset> listRasterDataset = new List<IGeoDataset>();

        public frmWaterConervation()
        {
            InitializeComponent();
            //禁用最大化
            this.MaximizeBox = false;
            //禁用最小化
            this.MinimizeBox = false;

            tb_raininput.Text = "C:\\Users\\41866\\Desktop\\云南系统\\test\\rain.tif";
            tb_suninput.Text = "C:\\Users\\41866\\Desktop\\云南系统\\test\\sun.tif";
            tb_tminput.Text = "C:\\Users\\41866\\Desktop\\云南系统\\test\\ta_Resample.tif";
            tb_luinput.Text = "C:\\Users\\41866\\Desktop\\云南系统\\test\\LandUse.tif";
            tb_wcoutput.Text = "C:\\Users\\41866\\Desktop\\云南系统\\test\\waterConervations.tif";

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
                rc.expression = "\"" + et2_t + "\"" + " != 0";
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


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }


        }

        private void frmWaterConervation_Load(object sender, EventArgs e)
        {

        }



        //GP工具箱另一种调用方式
        //string expression="\" C:\\Users\\41866\\Desktop\\云南系统\\test\\sun.tif\" / 20";
        //pVarArray.Add(expression);
        //pVarArray.Add(tb_wcoutput.Text);
        //gp.Execute("RasterCalculator", pVarArray,null);
        //MessageBox.Show("请先添加数据！", "提示", MessageBoxButtons.OK);



        //获取栅格最大值
        //public void  GetMaxPixelValue(string fullfilepath)
        //{
        //    IRasterLayer rasterLayer = new RasterLayerClass();
        //    rasterLayer.CreateFromFilePath(fullfilepath); // fullfilepath指存在本地的栅格文件路径
        //    IRaster pRaster = rasterLayer.Raster;
        //    IRaster2 pRaster2 = pRaster as IRaster2;
        //    IRasterProps pRasterProps = pRaster as IRasterProps;
   
        //     //获取图层的行列值   
        //     int Height = pRasterProps.Height;
        //     int Width = pRasterProps.Width;
   
        //     //定义并初始化数组，用于存储栅格内所有像员像素值
        //     double[ ,] PixelValue = new double[Height, Width];
        //     thisRasterLayer = rasterLayer;
   
        //     System.Array pixels;
   
        //     //定义RasterCursor初始化，参数设为null，内部自动设置PixelBlock大小
        //     IRasterCursor pRasterCursor = pRaster2.CreateCursorEx(null);
   
        //     //用于存储PixelBlock的长宽
        //     long blockwidth = 0;
        //     long blockheight = 0;
   
        //     IPixelBlock3 pPixelBlock3;
   
        //     try
        //     {
        //         do
        //         {
        //             //获取Cursor的左上角坐标
        //             int left = (int)pRasterCursor.TopLeft.X;
        //             int top = (int)pRasterCursor.TopLeft.Y;
   
        //             pPixelBlock3 = pRasterCursor.PixelBlock as IPixelBlock3;
   
        //             blockheight = pPixelBlock3.Height;
        //             blockwidth = pPixelBlock3.Width;
        //             //pPixelBlock3.Mask(255);
   
        //                    pixels = (System.Array)pPixelBlock3.get_PixelData(0);
   
        //                    //获取该Cursor的PixelBlock中像素的值
        //                    for (int i = 0; i < blockheight; i++)
        //                    {
        //                        for (int j = 0; j < blockwidth; j++)
        //                        {
        //                            //一定要注意，pixels中的数组排序为[Width,Height]
        //                            PixelValue[top + i, left + j] = Convert.ToDouble(pixels.GetValue(j, i));
        //                        }
        //                    }
        //                }
        //                while (pRasterCursor.Next() == true);
   
        //                MessageBox.Show("完成遍历！");
        //            }
        //            catch(Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }            
        //        }

    }
}



            
    
    
    
    
    
