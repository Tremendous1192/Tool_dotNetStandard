using System;
using System.Collections.Generic;
using System.Text;

//DataTableを扱うために必要
using System.Data;
//Fileを用いるために必要。
using System.IO;

namespace Tool_dotNetStandard.DataProcessing.IO
{
    public partial class CSVUser
    {

        public static void Write_csv_ReWrite(string csvFileName, DataTable data, bool header = true, string separator = ",")
        {
            //パスを作成する。
            string fullPath = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.Directory.GetCurrentDirectory(), csvFileName + ".csv");

            List<string> lines = new List<string>();
            if (header)
            {
                List<string> columnNameList = new List<string>();
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    columnNameList.Add(data.Columns[j].ColumnName);
                }
                lines.Add(string.Join(separator, columnNameList));
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                List<string> values = new List<string>();
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    values.Add(data.Rows[i][j].ToString());
                }
                lines.Add(string.Join(separator, values));
            }

            File.WriteAllLines(fullPath, lines.ToArray());
        }


    }
}
