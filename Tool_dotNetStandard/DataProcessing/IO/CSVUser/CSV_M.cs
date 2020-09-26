using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.IO
{
    public partial class CSVUser
    {
        /// <summary>
        /// 絶対パスを作成する
        /// </summary>
        /// <param name="pathOrFileName"></param>
        /// <returns></returns>
        public static string MakeFullPath(string pathOrFileName)
        {
            string result = pathOrFileName;
            if (System.IO.Path.GetExtension(pathOrFileName) == ".csv")
            { }
            else
            {
                result += ".csv";
            }
            if (pathOrFileName.Contains("\\"))
            { }
            else
            {
                result = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.DirectoryRider.GetCurrentDirectory(), result);
            }
            return result;
        }
    }
}
