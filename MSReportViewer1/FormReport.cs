using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace MSReportViewer1
{
    public partial class FormReport : Form
    {
        private ReportData _reportData;

        public FormReport()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.bindReportData();

            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
        }

        private void bindReportData()
        {
            this._reportData = new ReportData
            {
                Supplier = "XXXXXXXXXXXXXXXX有限公司",
                CarNumber = "京A00000",
                Number = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Date = $"{DateTime.Now:f}",
                Items = new List<ReportData.Item>()
            };
            for (var i = 0; i < 10; i++)
                this._reportData.Items.Add(new ReportData.Item
                {
                    Name = $"材料{i}",
                    Genre = $"型号{i}",
                    Unit = "立方米",
                    GrossWeight = $"123",
                    TareWeight = $"123",
                    NetWeight = $"123",
                    Weight = $"123",
                    Remark = $"备注{i}"
                });

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Supplier", this._reportData.Supplier));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("CarNumber", this._reportData.CarNumber));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Number", this._reportData.Number));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Date", this._reportData.Date));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TableDataSource", this._reportData.GetTableDataSource()));
        }
    }
}
