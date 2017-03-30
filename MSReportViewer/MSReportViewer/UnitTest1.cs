﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace MSReportViewer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // 1.列组报表
            this.getColsGroupReport();
        }

        #region ColsGroup Reports
        private void getColsGroupReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Path.Combine(Environment.CurrentDirectory, "colsgroup.rdlc");
            localReport.DataSources.Add(new ReportDataSource("Columns", getColsGroupDatas(new string[] { "姓名", "手机", "实发工资金额", "自定义列1", "自定义列2" })));

            string mimeType = "Application/octet-stream";
            string encoding = "UTF-8";
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;

            string deviceInfo = "<DeviceInfo><OutputFormat>EXCEL</OutputFormat><PageWidth>21cm</PageWidth><PageHeight>29.7cm</PageHeight><MarginTop>0.5in</MarginTop><MarginLeft>1in</MarginLeft><MarginRight>1in</MarginRight><MarginBottom>0.5in</MarginBottom></DeviceInfo>";
            byte[] renderedBytes = localReport.Render("EXCEL", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, "p.xls"), renderedBytes);
        }
        private DataTable getColsGroupDatas(string[] cols)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));

            foreach (var item in cols) dt.Rows.Add(item);

            return dt;
        }
        #endregion
    }
}
