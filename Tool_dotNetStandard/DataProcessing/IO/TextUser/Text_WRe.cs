using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Reflection;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.IO
{
    public partial class TextUser
    {


        /// <summary>
        /// txt を上書きする。stringを記録する
        /// </summary>
        /// <param name="textFileName"></param>
        /// <param name="writtenText"></param>
        /// <returns></returns>
        public static void Write_text_ReWrite(string textFileName, string writtenText)
        {
            string path = TextUser.MakeFullPath(textFileName);

            //NugetでSystem.Text.Encoding.CodePagesをダウンロードしておく.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var writer = new StreamWriter(path, append: false))
            {
                writer.WriteLine(writtenText);
            }

        }




        /// <summary>
        /// txt を上書きする。string[]を記録する
        /// </summary>
        /// <param name="textFileName"></param>
        /// <param name="writtenText"></param>
        /// <returns></returns>
        public static void Write_text_ReWrite(string textFileName, string[] writtenText)
        {
            string path = TextUser.MakeFullPath(textFileName);

            //NugetでSystem.Text.Encoding.CodePagesをダウンロードしておく.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var writer = new StreamWriter(path, append: false))
            {
                foreach (string w in writtenText) { writer.WriteLine(w); }
            }

        }





        /// <summary>
        /// txt を上書きする。string[ , ]を記録する
        /// </summary>
        /// <param name="textFileName"></param>
        /// <param name="writtenText"></param>
        /// <returns></returns>
        public static void Write_text_ReWrite(string textFileName, string[,] writtenText)
        {
            string[] combined = Tool_dotNetStandard.DataProcessing.Base.TypeChange.Combine_Array_to_string_by_comma(writtenText);

            Write_text_ReWrite(textFileName, combined);

        }

    }

}
