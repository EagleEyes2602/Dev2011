using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Helpers
{
    public static class DataTableHelper
    {
        public static List<T> ConvertDataTableToGenericList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                   .Select(c => c.ColumnName)
                   .ToList();

            var properties = typeof(T).GetProperties();
            DataRow[] rows = dt.Select();
            return rows.Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        object val = row[pro.Name];
                        if (row[pro.Name] == DBNull.Value)
                        {
                            val = null;
                        }
                        pro.SetValue(objT, val);
                    }
                }
                return objT;
            }).ToList();
        }
    }
}
