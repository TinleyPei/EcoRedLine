using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessor;

namespace EcoRedLine
{
    public partial class frmTerrain : DevComponents.DotNetBar.OfficeForm
    {
        private IPageLayoutControl _PageLayoutControl = null;
        public frmTerrain()
        {
            InitializeComponent();
           
        }

        public frmTerrain(IPageLayoutControl pPageLayoutControl)
        {
            InitializeComponent();
            this._PageLayoutControl = pPageLayoutControl;
            
        }
        double sfactor = 1;
        string smeasurement = "DEGREE";
        string sslope = "/Slope.tif";
        string sOrder1 = null;
        string sOrder2 = null;
        string sOrder3 = null;
        string sOrder4 = null;
        string sSlope08 = "/优化建设区.tif";
        string sSlope815 = "/允许建设区.tif";
        string sSlope1525 = "/有条件建设区.tif";
        string sSlope25 = "/禁止建设区.tif";
        private void frmTerrain_Load(object sender, EventArgs e)
        {
            
        }

        private void btInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp,其中：*.*代表全部文件，如果多个扩展名并列，用“|”隔开
            dlg.Filter = "tiff(*.tif)|*.tif";


            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //this.txt_Input.Text = dlg.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtInput.Text = dlg.FileName;
            }
        }
        string filePath_temp;//路径存储中间量
        private void btSave_Click(object sender, EventArgs e)
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
            txtOutput.Text = filePath_temp;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
             this.rtxtState.AppendText("正在执行，请您耐心等待...\n");
            this.rtxtState.ScrollToCaret();
            #region 步骤一：接收输入数据的路径
            string sInputFile = this.txtInput.Text;
            if (sInputFile.Equals(""))
            {
                MessageBox.Show("请选择输入DEM数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.rtxtState.AppendText("读取DEM数据...\n");
            this.rtxtState.ScrollToCaret();

            string sOutputFile = this.txtOutput.Text;
            if (sOutputFile.Equals(""))
            {
                MessageBox.Show("请选择输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.rtxtState.AppendText("读取输出路径...\n");
            this.rtxtState.ScrollToCaret();

            #endregion

            //string fileName = "地形地貌.mxd";
            //axMapControl1.LoadMxFile(fileName);
            ////将地图全屏最大化
            //axMapControl1.Extent = axMapControl1.FullExtent;



            IVariantArray parameters = new VarArrayClass();
            Geoprocessor GP = new Geoprocessor();
            object sev = null;
            this.rtxtState.AppendText("调用GP工具箱功能...\n");
            this.rtxtState.ScrollToCaret();

            ESRI.ArcGIS.SpatialAnalystTools.Slope slo = new ESRI.ArcGIS.SpatialAnalystTools.Slope();//计算坡度

            slo.in_raster = sInputFile;
            slo.output_measurement = smeasurement;
            slo.z_factor = sfactor;
            string sRoad1 = sOutputFile + sslope;
            slo.out_raster = sRoad1;
            this.rtxtState.AppendText("利用DEM数据计算坡度信息...\n");
            this.rtxtState.ScrollToCaret();

            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCal1 = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCal2 = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCal3 = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
            ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator sCal4 = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();

            //try
            //{
            GP.Execute(slo, null);//坡度计算
            this.rtxtState.AppendText("计算坡度完成...\n");
            this.rtxtState.ScrollToCaret();
            //坡度<=8°&高程<=2500m
            sOrder1 = "(\"" + sOutputFile + "/slope.tif" + "\"" + "<=8" + ")" + "&" + "(\"" + sInputFile + "\"" + "<=2500" + ")";
            sCal1.expression = sOrder1;
            sCal1.output_raster = sOutputFile + sSlope08;
            this.rtxtState.AppendText("开始进行建设区分级计算...\n");
            this.rtxtState.ScrollToCaret();
            GP.Execute(sCal1, null);
            this.rtxtState.AppendText("计算出“优化建设区”...\n");
            this.rtxtState.ScrollToCaret();
            //8°<坡度<=15°& 高程<=2500m
            sOrder2 = "(" + "8<" + "\"" + sOutputFile + "/slope.tif" + "\")" + "&" + "(\"" + sOutputFile + "/slope.tif" + "\"" + "<=15" + ")" + "&" + "(\"" + sInputFile + "\"" + "<=2500" + ")";
            sCal2.expression = sOrder2;
            sCal2.output_raster = sOutputFile + sSlope815;
            GP.Execute(sCal2, null);
            this.rtxtState.AppendText("计算出“允许建设区”...\n");
            this.rtxtState.ScrollToCaret();
            //15°<坡度<=25°&高程<=2500m
            sOrder3 = "(" + "15<" + "\"" + sOutputFile + "/slope.tif" + "\")" + "&" + "(\"" + sOutputFile + "/slope.tif" + "\"" + "<=25" + ")" + "&" + "(\"" + sInputFile + "\"" + "<=2500" + ")";
            sCal3.expression = sOrder3;
            sCal3.output_raster = sOutputFile + sSlope1525;
            GP.Execute(sCal3, null);
            this.rtxtState.AppendText("计算出“有条件建设区”...\n");
            this.rtxtState.ScrollToCaret();
            //25°<坡度 | 高程<=2500m
            sOrder4 = "(\"" + sOutputFile + "/slope.tif" + "\"" + ">25" + ")" + "|" + "(\"" + sInputFile + "\"" + ">2500" + ")";
            sCal4.expression = sOrder4;
            sCal4.output_raster = sOutputFile + sSlope25;
            GP.Execute(sCal4, null);
            this.rtxtState.AppendText("计算出禁止建设区...\n");
            this.rtxtState.ScrollToCaret();

            this.rtxtState.AppendText("结果计算完成...\n");
            this.rtxtState.ScrollToCaret();
            //MessageBox.Show(GP.GetMessages(ref sev));


            //修改mxd数据源路径
            this.rtxtState.AppendText("开始将结果用地图输出展示，请稍等...\n");
            this.rtxtState.ScrollToCaret();
            IMapDocument pMapDocument = new MapDocumentClass();
            pMapDocument.Open("模板地形地貌.mxd"); //打开本地的“模板地形地貌.mxd”地图文档，用来操作改mxd文件
            IMap pMap = pMapDocument.get_Map(0);
            IMapLayers pMapLayer = pMap as IMapLayers;
            IRasterLayer pRasterLayer = new RasterLayerClass();
            IWorkspaceFactory rasterWorkspaceFactory = new RasterWorkspaceFactoryClass();
            IRasterWorkspace rasterWorkspace = (IRasterWorkspace)rasterWorkspaceFactory.OpenFromFile(txtOutput.Text, 0);



            IRasterDataset pRasterDataset1 = rasterWorkspace.OpenRasterDataset("优化建设区.tif");  //打开"优化建设区.tif"为栅格图的文件名
            pRasterLayer.CreateFromDataset(pRasterDataset1);    //创建    
            pRasterLayer = pMapLayer.get_Layer(1) as IRasterLayer;
            pRasterLayer.CreateFromDataset(pRasterDataset1);

            //更改“允许建设区.tif”数据源路径
            IRasterLayer pRasterLayer2 = new RasterLayerClass();
            IRasterDataset pRasterDataset2 = rasterWorkspace.OpenRasterDataset("允许建设区.tif");  //打开"允许建设区.tif"为栅格图的文件名
            pRasterLayer2.CreateFromDataset(pRasterDataset2);    //创建    
            pRasterLayer2 = pMapLayer.get_Layer(2) as IRasterLayer;
            pRasterLayer2.CreateFromDataset(pRasterDataset2);

            //更改"有条件建设区.tif"数据源路径
            IRasterLayer pRasterLayer3 = new RasterLayerClass();
            IRasterDataset pRasterDataset3 = rasterWorkspace.OpenRasterDataset("有条件建设区.tif");  //打开"有条件建设区.tif"为栅格图的文件名
            pRasterLayer3.CreateFromDataset(pRasterDataset3);    //创建    
            pRasterLayer3 = pMapLayer.get_Layer(3) as IRasterLayer;
            pRasterLayer3.CreateFromDataset(pRasterDataset3);

            //更改"禁止建设区.tif"数据源路径
            IRasterLayer pRasterLayer4 = new RasterLayerClass();
            IRasterDataset pRasterDataset4 = rasterWorkspace.OpenRasterDataset("禁止建设区.tif");  //打开"禁止建设区.tif"为栅格图的文件名
            pRasterLayer4.CreateFromDataset(pRasterDataset4);    //创建    
            pRasterLayer4 = pMapLayer.get_Layer(4) as IRasterLayer;
            pRasterLayer4.CreateFromDataset(pRasterDataset4);


            pMapDocument.Save(true, true);//保存更改完路径后的mxd文件模板地形地貌2

            //string fileName = "南湖村.mxd";// @"C:\Users\tangmeng\Desktop\农用地籍数据库\实验四\南湖数据\南湖村.mxd";
            //pMap.LoadMxFile(fileName);
            ////将地图全屏最大化
            //pMap.Extent = pMap.FullExtent;



            string MdbFile = "模板地形地貌.mxd";
            _PageLayoutControl.LoadMxFile(MdbFile);
            //将mxd全屏最大化
            _PageLayoutControl.Extent = _PageLayoutControl.FullExtent;


            // tabControl1.SelectedTab = tabPage1;

            this.rtxtState.AppendText("地图输出完成...\n");
            this.rtxtState.ScrollToCaret();
        
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       
       
    }
}
