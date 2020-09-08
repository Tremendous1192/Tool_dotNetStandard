using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Reflection;



namespace Tool_dotNetStandard.DataProcessing.IO
{
    public partial class TextUser
    {

        /// <summary>
        /// txtデータを読み込む。string[]を読み込む。
        /// </summary>
        /// <param name="textFileName"></param>
        /// <returns></returns>
        public static string[] ReadText(string textFileName)
        {

            string path = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.Directory.GetCurrentDirectory(), textFileName + ".txt");

            //NugetでSystem.Text.Encoding.CodePagesをダウンロードしておく.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(textFileName);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            List<string> temp = new List<string>();

            System.IO.StreamReader file;
            try
            {
                //file = new System.IO.StreamReader(stream, sjisEnc);
                file = File.OpenText(path);

                string line = "";
                // test.txtを1行ずつ読み込んでいき、末端(何もない行)までtempに格納する
                while ((line = file.ReadLine()) != null)
                {
                    temp.Add(line);
                }
                file.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
                var a = new string[1];
                a[0] = "No data";
                return a;
            }


            if (temp[temp.Count - 1] == "")
            {
                temp.RemoveAt(temp.Count - 1);
            }
            return temp.ToArray();
        }


        /// <summary>
        /// txtデータを読み込む。string[,]を読み込む。
        /// カンマ , 区切りでデータを取り出す。
        /// </summary>
        /// <param name="textFileName"></param>
        /// <returns></returns>
        public static string[,] Read_text_2dim_Split_by_camma(string textFileName)
        {
            string path = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.Directory.GetCurrentDirectory(), textFileName + ".txt");

            //NugetでSystem.Text.Encoding.CodePagesをダウンロードしておく.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(textFileName);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            List<string> temp = new List<string>();

            System.IO.StreamReader file;
            try
            {
                //file = new System.IO.StreamReader(stream, sjisEnc);
                file = File.OpenText(path);

                string line = "";
                // test.txtを1行ずつ読み込んでいき、末端(何もない行)までtempに格納する
                while ((line = file.ReadLine()) != null)
                {
                    temp.Add(line);
                }
                file.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
                var a = new string[1, 1];
                a[0, 0] = "No data";
                return a;
            }


            if (temp[temp.Count - 1] == "")
            {
                temp.RemoveAt(temp.Count - 1);
            }

            int maxColumn = 1;
            for (int j = 0; j < temp.Count; j++)
            {
                maxColumn = Math.Max(maxColumn, temp[j].Split(',').Length);
            }

            string[,] result = new string[temp.Count, maxColumn];
            for (int j = 0; j < temp.Count; j++)
            {
                string[] row = temp[j].Split(',');
                for (int k = 0; k < row.Length; k++)
                {
                    result[j, k] = row[k];
                }
            }
            return result;
        }

    }

}
