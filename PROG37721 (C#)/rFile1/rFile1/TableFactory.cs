using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace rFile1
{
    class TableFactory
    {
        public static DataTable makeTable()
        {
            DataTable table = new DataTable();

            DataColumn col = new DataColumn();
            col.ColumnName = "Account";
            col.DataType = Type.GetType("System.Int32");
            table.Columns.Add(col);

            DataColumn col2 = new DataColumn();
            col2.ColumnName = "FirstName";
            col2.DataType = Type.GetType("System.String");
            table.Columns.Add(col2);

            DataColumn col3 = new DataColumn();
            col3.ColumnName = "LastName";
            col3.DataType = Type.GetType("System.String");
            table.Columns.Add(col3);

            DataColumn col4 = new DataColumn();
            col4.ColumnName = "Balance";
            col4.DataType = Type.GetType("System.String");
            table.Columns.Add(col4);
            return table;
        }
    }
}
