using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.IO
{
    class Directory
    {


        /// <summary>
        /// Directoryを変更する。
        /// デスクトップはEnvironment.GetFolderPath(Environment.SpecialFolder.Desktop)
        /// </summary>
        /// <param name="newDirectory"></param>
        public static void ChangeDirectory(string newDirectory)
        {
            System.IO.Directory.SetCurrentDirectory(newDirectory);
        }

        /// <summary>
        /// Directoryを変更する。
        /// デスクトップはEnvironment.GetFolderPath(Environment.SpecialFolder.Desktop)
        /// </summary>
        /// <param name="New_Directory"></param>
        public static void ChangeDirectoryToDeskTop()
        {
            System.IO.Directory.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }


        /// <summary>
        /// 現在のdirectoryを取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }



    }
}
