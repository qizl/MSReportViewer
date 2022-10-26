using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MSReportViewer1
{
    public class ReportData
    {
        public string Supplier { get; set; }
        public string CarNumber { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }

        public List<Item> Items { get; set; }

        public DataTable GetTableDataSource()
        {
            var table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Genre", typeof(string));
            table.Columns.Add("Unit", typeof(string));
            table.Columns.Add("GrossWeight", typeof(string));
            table.Columns.Add("TareWeight", typeof(string));
            table.Columns.Add("NetWeight", typeof(string));
            table.Columns.Add("Weight", typeof(string));
            table.Columns.Add("Remark", typeof(string));
            if (this.Items != null)
                foreach (var item in this.Items)
                    table.Rows.Add(item.Name, item.Genre, item.Unit, item.GrossWeight, item.TareWeight, item.NetWeight, item.Weight, item.Remark);
            return table;
        }

        public class Item
        {
            public string Name { get; set; }
            public string Genre { get; set; }
            public string Unit { get; set; }
            /// <summary>
            /// 毛重
            /// </summary>
            public string GrossWeight { get; set; }
            /// <summary>
            /// 皮重
            /// </summary>
            public string TareWeight { get; set; }
            /// <summary>
            /// 净重
            /// </summary>
            public string NetWeight { get; set; }
            /// <summary>
            /// 实际重量
            /// </summary>
            public string Weight { get; set; }
            public string Remark { get; set; }
        }
    }
}
