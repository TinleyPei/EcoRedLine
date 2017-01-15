﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPluginEngine;
using ESRI.ArcGIS.Controls;

namespace EcoRedLine
{
    class frmTerrainCmd : MyPluginEngine.ICommand
    {
        private MyPluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;
        private IPageLayoutControl _PageLayoutControl = null;//定义IPageLayoutControl，为空值
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;
        frmTerrain pfrmTerrain;

        public frmTerrainCmd()
        {
            string str = @"..\Data\Image\EcoRedLine\Terrain.png";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;

        }
        #region ICommand 成员
        public System.Drawing.Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "地形地貌"; }
        }

        public string Category
        {
            get { return "EcoRedLineMenu"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public int HelpContextId
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }

        public string Message
        {
            get { return "地形地貌"; }
        }

        public string Name
        {
            get { return "frmTerrain"; }
        }

        public void OnClick()
        {
            //System.Windows.Forms.MessageBox.Show("正在开发中！");
            pfrmTerrain = new frmTerrain(_PageLayoutControl);
            pfrmTerrain.ShowDialog();
        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                this._PageLayoutControl = hk.PageLayoutControl as IPageLayoutControl;
                pfrmTerrain = new frmTerrain(_PageLayoutControl);
                pfrmTerrain.Visible = false;
            }
        }

        public string Tooltip
        {
            get { return "地形地貌"; }
        }
        #endregion
    }
}
