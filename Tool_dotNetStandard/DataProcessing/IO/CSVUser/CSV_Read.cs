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


        /// <summary>
        /// 現在のフォルダにあるCSVデータから、DataTableを取り出す。
        /// </summary>
        /// <param name="csvFileName"></param>
        /// <param name="header"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static DataTable Read_csv(string csvFileName, bool header = true, char separator = ',')
        {
            //パスを作成する。
            string fullPath = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.Directory.GetCurrentDirectory(), csvFileName + ".csv");

            //戻り値
            DataTable data = new DataTable();

            //データ量が増えると読み込めないので、1行ずつ読み込む。
            List<string> temp = new List<string>();
            System.IO.StreamReader file;
            try
            {
                //file = new System.IO.StreamReader(stream, sjisEnc);
                file = File.OpenText(fullPath);

                string line = "";
                // test.txtを1行ずつ読み込んでいき、末端(何もない行)までtempに格納する
                while ((line = file.ReadLine()) != null)
                {
                    temp.Add(line);
                }
                if (temp[temp.Count - 1] == "") { temp.RemoveAt(temp.Count - 1); }
                file.Dispose();
            }
            catch
            {
                throw new FormatException("何かしらの理由でデータが読み込めませんでした。");
            }

            //foreach (string s in temp) { Console.WriteLine(s); }
            // Console.WriteLine("");

            //ヘッダーの有無
            string[] column_names = new string[temp[0].Split(separator).Length];
            if (header)
            {
                for (int i = 0; i < temp[0].Split(separator).Length; i++)
                {
                    column_names[i] = temp[0].Split(separator)[i];
                }
                temp.RemoveAt(0);
            }
            else
            {
                for (int i = 0; i < temp[0].Split(separator).Length; i++)
                {
                    column_names[i] = "Label " + i;
                }
            }

            //型の判定のためにstring[,]に収める
            string[,] table = new string[temp.Count, column_names.Length];
            for (int i = 0; i < temp.Count; i++)
            {
                string[] line = temp[i].Split(separator);
                for (int j = 0; j < line.Length; j++)
                {
                    table[i, j] = line[j];
                }
            }

            //型の判定を行う
            List<object> types = new List<object>();
            for (int j = 0; j < table.GetLength(1); j++)
            {
                //bool
                bool type_bool = false;
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    if (table[i, j] == "T" ||
                        table[i, j] == "F" ||
                        table[i, j] == "t" ||
                        table[i, j] == "f" ||
                        table[i, j] == "True" ||
                        table[i, j] == "False" ||
                        table[i, j] == "true" ||
                        table[i, j] == "false" ||
                        table[i, j] == "TRUE" ||
                        table[i, j] == "FALSE" ||
                        table[i, j] == "真" ||
                        table[i, j] == "偽")
                    { type_bool = true; }
                    else { type_bool = false; }
                }
                if (type_bool)
                {
                    types.Add(true);
                    continue;
                }

                //int
                try
                {
                    int type_int = 0;
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        type_int = int.Parse(table[i, j]);
                    }
                    types.Add(1);
                    continue;
                }
                catch { }

                //double
                try
                {
                    double type_double = 0;
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        type_double = double.Parse(table[i, j]);
                    }
                    types.Add(1.5);
                    continue;
                }
                catch { }

                //残りはstring
                types.Add("string");
            }


            //列を追加する。
            //Console.WriteLine("");
            for (int j = 0; j < table.GetLength(1); j++)
            {
                data.Columns.Add(column_names[j], types[j].GetType());
                //Console.Write(column_names[j] + "\t");
            }
            //Console.WriteLine("");

            //データを格納する。
            for (int i = 0; i < table.GetLength(0); i++)
            {
                //Console.WriteLine("");
                //1行ごとに格納する必要あり。
                DataRow data_row = data.NewRow();
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    //Console.Write(table[i, j] + "\t");
                    //bool
                    if (types[j].GetType() == true.GetType())
                    {
                        data_row[column_names[j]] =
                            table[i, j] == "T" ||
                            table[i, j] == "t" ||
                            table[i, j] == "True" ||
                            table[i, j] == "true" ||
                            table[i, j] == "TRUE" ||
                            table[i, j] == "真";
                        continue;
                    }
                    //int
                    if (types[j].GetType() == 1.GetType())
                    {
                        data_row[column_names[j]] = int.Parse(table[i, j]);
                        continue;
                    }
                    //double
                    if (types[j].GetType() == (1.5).GetType())
                    {
                        data_row[column_names[j]] = double.Parse(table[i, j]);
                        continue;
                    }
                    //string
                    data_row[column_names[j]] = table[i, j];
                }
                data.Rows.Add(data_row);
            }
            return data;
        }



    }
}
