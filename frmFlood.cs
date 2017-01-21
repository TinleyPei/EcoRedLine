using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
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
    public partial class frmFlood : DevComponents.DotNetBar.OfficeForm
    {
        private IPageLayoutControl _PageLayoutControl = null;

        public frmFlood(IPageLayoutControl pPageLayoutControl)
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
            tb_demnput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\dem.tif";
            tb_highinput.Text = "2000";
            tb_flooutput.Text = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\Flood.tif";

        }

        private void bt_deminput_Click(object sender, EventArgs e)
        {
            //输入地面高程数据文件
            tb_demnput.Text = null;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckPathExists = true;
            openfile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            openfile.Title = "打开";
            openfile.RestoreDirectory = true;
            DialogResult dr = openfile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_demnput.Text = openfile.FileName;
            }

        }


        private void bt_flooutput_Click(object sender, EventArgs e)
        {
            //输入洪水淹没数据输出路径
            tb_flooutput.Text = null;
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.CheckPathExists = true;
            savefile.Filter = "TIF文件(*.tif*)|*.tif*|所有文件(*.*)|*.*";
            savefile.OverwritePrompt = true;
            savefile.Title = "保存";
            savefile.RestoreDirectory = true;
            savefile.FileName = "Flood";
            DialogResult dr = savefile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tb_flooutput.Text = savefile.FileName + ".tif";
            }

        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {


            //判断输入路径是否正确
            #region
            try
            {
                if (!File.Exists(tb_demnput.Text))
                {
                    MessageBox.Show("平均降水量数据输入路径不正确或文件被占用，请重新输入路径！", "提示", MessageBoxButtons.OK);
                    return;
                }
                if (Convert.ToDouble(tb_highinput.Text)<0)
                {
                    MessageBox.Show("请输入正确的水位高程值！", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置路径或水位高程值不合法，请检查！");
                return;
            }
            #endregion






            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rc = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            object sev = null;
            try
            {
                tb_state.Text = "正在处理……";
                //判断输入水位数据的单位
                double waterunit = 0;
                if (cb_waterunits.Text == "米（m）")
                    waterunit = 1;
                else waterunit = 0.001;


                //判断输入缓冲距离及缓冲单位
                double bufferunit = 0;
                if (cb_bufferunits.Text == "米（m）")
                    bufferunit = 1;
                else bufferunit = 1000;
                double[] bufferdistance = { Convert.ToDouble(nud_one.Value) * bufferunit, Convert.ToDouble(nud_two.Value) * bufferunit, Convert.ToDouble(nud_three.Value) * bufferunit, Convert.ToDouble(nud_four.Value) * bufferunit };


                //提取高程高于水位的区域
                tb_state.Text = "正在提取未淹没区域……";
                string flood_high = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_high" + System.IO.Path.GetExtension(tb_flooutput.Text);
                rc.output_raster = flood_high;
                rc.expression = "Con(\"" + tb_demnput.Text + "\" >= (" + tb_highinput.Text + " * " + waterunit.ToString() + "),\"" + tb_demnput.Text + "\")";
                gp.Execute(rc, null);
                tb_state.Text = "未淹没区域提取完成！";


                //水文分析填洼
                tb_state.Text = "正在进行水文分析计算填洼……";
                ESRI.ArcGIS.SpatialAnalystTools.Fill fill = new ESRI.ArcGIS.SpatialAnalystTools.Fill();
                string fill_input, fill_output;
                fill_input = flood_high;
                fill_output = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_fill" + System.IO.Path.GetExtension(tb_flooutput.Text);
                fill.in_surface_raster = fill_input;
                fill.out_surface_raster = fill_output;
                gp.Execute(fill, null);
                tb_state.Text = "水文分析填洼计算完成！";

                //水文分析计算流向
                tb_state.Text = "正在进行水文分析计算流向……";
                ESRI.ArcGIS.SpatialAnalystTools.FlowDirection flowdirection = new ESRI.ArcGIS.SpatialAnalystTools.FlowDirection();
                string flowdirection_input, flowdirection_output;
                flowdirection_input = fill_output;
                flowdirection_output = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_FlowDir" + System.IO.Path.GetExtension(tb_flooutput.Text);
                flowdirection.in_surface_raster = flowdirection_input;
                flowdirection.out_flow_direction_raster = flowdirection_output;
                gp.Execute(flowdirection, null);
                tb_state.Text = "水文分析流向计算完成！";



                //水文分析计算流量
                tb_state.Text = "正在进行水文分析计算流量……";
                ESRI.ArcGIS.SpatialAnalystTools.FlowAccumulation flowaccumulation = new ESRI.ArcGIS.SpatialAnalystTools.FlowAccumulation();
                string flowaccumulation_input, flowaccumulation_output;
                flowaccumulation_input = flowdirection_output;
                flowaccumulation_output = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_FlowAcc" + System.IO.Path.GetExtension(tb_flooutput.Text);
                flowaccumulation.in_flow_direction_raster = flowaccumulation_input;
                flowaccumulation.out_accumulation_raster = flowaccumulation_output;
                gp.Execute(flowaccumulation, null);
                tb_state.Text = "水文分析流量计算完成！";

                //盆域分析
                tb_state.Text = "正在进行水文分析盆域分析……";
                ESRI.ArcGIS.SpatialAnalystTools.Basin basin = new ESRI.ArcGIS.SpatialAnalystTools.Basin();
                string basin_input, basin_output;
                basin_input = flowdirection_output;
                basin_output = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_Basin" + System.IO.Path.GetExtension(tb_flooutput.Text);
                basin.in_flow_direction_raster = basin_input;
                basin.out_raster = basin_output;
                gp.Execute(basin, null);
                tb_state.Text = "水文分析盆域分析计算完成！";


                //阈值提取河流
                tb_state.Text = "正在阈值提取河流……";
                string flood_rasterriver = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_river" + System.IO.Path.GetExtension(tb_flooutput.Text);
                rc.expression = "Con(\"" + flowaccumulation_output + "\" >= 800,1)";
                rc.output_raster = flood_rasterriver;
                gp.Execute(rc, null);
                tb_state.Text = "阈值提取河流计算完成！";

                //水文分析栅格河网矢量化
                tb_state.Text = "正在进行水文分析栅格河网矢量化……";
                ESRI.ArcGIS.SpatialAnalystTools.StreamToFeature streamtofeature = new ESRI.ArcGIS.SpatialAnalystTools.StreamToFeature();
                string streamtofeature_output;
                streamtofeature_output = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_river.shp";
                streamtofeature.in_flow_direction_raster = flowdirection_output;
                streamtofeature.in_stream_raster = flood_rasterriver;
                streamtofeature.out_polyline_features = streamtofeature_output;
                gp.Execute(streamtofeature, null);
                tb_state.Text = "水文分析栅格河网矢量化计算完成！";


                //多环缓冲区
                tb_state.Text = "正在计算多环缓冲区……";
                ESRI.ArcGIS.AnalysisTools.MultipleRingBuffer multipleringbuffer = new ESRI.ArcGIS.AnalysisTools.MultipleRingBuffer();
                string multipleringbuffer_output = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_multbuffer.shp";
                multipleringbuffer.Input_Features = streamtofeature_output;
                multipleringbuffer.Distances = bufferdistance[0].ToString() + ";" + bufferdistance[1].ToString() + ";" + bufferdistance[2].ToString() + ";" + bufferdistance[3].ToString() + ";";
                ;
                multipleringbuffer.Buffer_Unit = "meters";
                multipleringbuffer.Output_Feature_class = multipleringbuffer_output;
                gp.Execute(multipleringbuffer, null);
                tb_state.Text = "多环缓冲区计算完成！";


                //多环缓冲区矢量转栅格
                tb_state.Text = "正在进行多环缓冲区矢量转栅格……";
                ESRI.ArcGIS.ConversionTools.FeatureToRaster featuretoraster = new ESRI.ArcGIS.ConversionTools.FeatureToRaster();
                string featuretoraster_output = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_multbuffer" + System.IO.Path.GetExtension(tb_flooutput.Text);
                featuretoraster.in_features = System.IO.Path.GetDirectoryName(tb_flooutput.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "_multbuffer.shp";
                featuretoraster.field = "distance";
                featuretoraster.out_raster = featuretoraster_output;
                gp.Execute(featuretoraster, null);
                tb_state.Text = "多环缓冲区矢量转栅格计算完成！";


                //删除临时文件
                if (tb_state.Text == "多环缓冲区矢量转栅格计算完成！")
                {
                    string[] files = Directory.GetFiles(System.IO.Path.GetDirectoryName(tb_flooutput.Text), System.IO.Path.GetFileNameWithoutExtension(tb_flooutput.Text) + "*");
                    foreach (string file in files)
                    {
                        if (System.IO.Path.GetFileNameWithoutExtension(file) != System.IO.Path.GetFileNameWithoutExtension(basin_output) && System.IO.Path.GetFileNameWithoutExtension(file) != System.IO.Path.GetFileNameWithoutExtension(featuretoraster_output))
                            File.Delete(file);
                    }

                }


                //将结果加载显示
                #region
                string mxfile = System.Environment.CurrentDirectory + "\\Data\\EcoRedLine\\洪水淹没生态红线划分.mxd";
                IMapDocument pMapDocument = new MapDocumentClass();
                pMapDocument.Open(mxfile); //打开本地的地图文档，用来操作改mxd文件
                IMap pMap = pMapDocument.get_Map(0);
                IMapLayers pMapLayer = pMap as IMapLayers;
                IRasterLayer pRasterLayer = new RasterLayerClass();
                IWorkspaceFactory rasterWorkspaceFactory = new RasterWorkspaceFactoryClass();
                IRasterWorkspace rasterWorkspace = (IRasterWorkspace)rasterWorkspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(tb_flooutput.Text), 0);

                IRasterDataset pRasterDataset1 = rasterWorkspace.OpenRasterDataset("Flood_multbuffer.tif");  //打开栅格图的文件名
                pRasterLayer.CreateFromDataset(pRasterDataset1);    //创建    
                pRasterLayer = pMapLayer.get_Layer(0) as IRasterLayer;
                pRasterLayer.CreateFromDataset(pRasterDataset1);

                IRasterLayer pRasterLayer2 = new RasterLayerClass();
                IRasterDataset pRasterDataset2 = rasterWorkspace.OpenRasterDataset("Flood_Basin.tif");  //打开栅格图的文件名
                pRasterLayer2.CreateFromDataset(pRasterDataset2);    //创建    
                pRasterLayer2 = pMapLayer.get_Layer(1) as IRasterLayer;
                pRasterLayer2.CreateFromDataset(pRasterDataset2);


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

        private void tb_highinput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
