using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.IO
{
    public partial class TextUser
    {
        /// <summary>
        /// 絶対パスを作成する
        /// </summary>
        /// <param name="pathOrFileName"></param>
        /// <returns></returns>
        public static string MakeFullPath(string pathOrFileName)
        {
            string result = pathOrFileName;
            if (System.IO.Path.GetExtension(pathOrFileName) == ".txt")
            { }
            else
            {
                result += ".txt";
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
