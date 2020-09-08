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
            string path = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.Directory.GetCurrentDirectory(), textFileName + ".txt");

            //NugetでSystem.Text.Encoding.CodePagesをダウンロードしておく.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(textFileName);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            System.IO.StreamWriter sw;
            try
            {
                //sw = new System.IO.StreamWriter(stream, sjisEnc,512,false);
                try { File.Delete(path); } catch { }
                sw = File.CreateText(path);
                sw.AutoFlush = true;

                sw.WriteLine(writtenText);
                //閉じる
                sw.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
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
            string path = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.Directory.GetCurrentDirectory(), textFileName + ".txt");

            //NugetでSystem.Text.Encoding.CodePagesをダウンロードしておく.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(textFileName);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            System.IO.StreamWriter sw;
            try
            {
                //sw = new System.IO.StreamWriter(stream, sjisEnc,512,false);
                try { File.Delete(path); } catch { }
                sw = File.CreateText(path);
                sw.AutoFlush = true;

                for (int i = 0; i < writtenText.GetLength(0); i++)
                {
                    sw.WriteLine(writtenText[i]);
                }
                //閉じる
                sw.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
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
            string path = System.IO.Path.Combine(Tool_dotNetStandard.DataProcessing.IO.Directory.GetCurrentDirectory(), textFileName + ".txt");

            //NugetでSystem.Text.Encoding.CodePagesをダウンロードしておく.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(textFileName);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            System.IO.StreamWriter sw;
            try
            {
                //sw = new System.IO.StreamWriter(stream, sjisEnc,512,false);
                try { File.Delete(path); } catch { }
                sw = File.CreateText(path);
                sw.AutoFlush = true;

                for (int i = 0; i < writtenText.GetLength(0); i++)
                {
                    for (int j = 0; j < writtenText.GetLength(1) - 1; j++)
                    {
                        sw.Write(writtenText[i, j] + ",");
                    }
                    sw.WriteLine(writtenText[i, writtenText.GetLength(1) - 1]);
                }
                //閉じる
                sw.Dispose();
            }
            catch
            {
                Console.WriteLine("Exception !!");
            }

        }

    }

}
