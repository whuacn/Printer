﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Windy.Printer.DockForms;
using Windy.Printer.Utility;

namespace Windy.Printer.Control
{
    internal partial class WinWordDocForm : DockContentBase,IDocument
    {

        public WinWordDocForm()
        {
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.winWordCtrl1.ShowInternalMenuStrip = false;
        }

        /// <summary>
        /// 打开指定的Word文档
        /// </summary>
        /// <param name="szFilePath">文件路径</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenDocument(string szFilePath)
        {
            this.winWordCtrl1.OpenDocument(szFilePath);
            this.m_szFilePath = szFilePath;
            return SystemConst.ReturnValue.OK;

        }
        private string m_szFilePath = string.Empty;
        /// <summary>
        /// 关闭当前文档
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short CloseDocument()
        {
            this.winWordCtrl1.CloseDocument();
            this.winWordCtrl1.CloseWordApplication();
            return SystemConst.ReturnValue.OK;
        }

        private void WinWordDocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseDocument();
        }

        public string GetFileFullPath()
        {
            return this.m_szFilePath;
        }
    }
}