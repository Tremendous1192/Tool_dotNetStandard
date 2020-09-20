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
        /// txt に書き足す。stringを記録する
        /// </summary>
        /// <param name="textFileName"></param>
        /// <param name="writtenText"></param>
        /// <returns></returns>
        public static void Write_text_Add(string textFileName, string writtenText)
        {
            string path = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.Directory.GetCurrentDirectory(), textFileName + ".txt");

            //NugetでSystem.Text.Encoding.CodePagesをダウンロードしておく.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(writtenText);
            }

        }


        /// <summary>
        /// txt に書き足す。string[]を記録する
        /// </summary>
        /// <param name="textFileName"></param>
        /// <param name="writtenText"></param>
        /// <returns></returns>
        public static void Write_text_Add(string textFileName, string[] writtenText)
        {
            string path = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.Directory.GetCurrentDirectory(), textFileName + ".txt");

            //NugetでSystem.Text.Encoding.CodePagesをダウンロードしておく.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var writer = new StreamWriter(path, append: true))
            {
                foreach (string w in writtenText) { writer.WriteLine(w); }
            }

        }




        /// <summary>
        /// txt に書き足す。string[ , ]を記録する
        /// </summary>
        /// <param name="textFileName"></param>
        /// <param name="writtenText"></param>
        /// <returns></returns>
        public static void Write_text_Add(string textFileName, string[,] writtenText)
        {
            string[] combined = Tool_dotNetStandard.DataProcessing.Base.TypeChange.Combine_Array_to_string_by_comma(writtenText);

            Write_text_Add(textFileName, combined);

        }


    }

}
