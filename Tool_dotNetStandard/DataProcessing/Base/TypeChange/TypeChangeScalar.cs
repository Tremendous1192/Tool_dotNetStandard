using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class TypeChange
    {
        /// <summary>
        /// Change string to int
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int StringToInt(string input)
        {
            int parsed;
            if (int.TryParse(input, out parsed)) { return parsed; }
            return 0;
        }

        /// <summary>
        /// Change string to double
        /// </summary>random
        /// <param name="input"></param>
        /// <returns></returns>
        public static double StringToDouble(string input)
        {
            double parsed;
            if (double.TryParse(input, out parsed)) { return parsed; }
            return 0.0;
        }

        /// <summary>
        /// Change string to byte
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte StringToByte(string input)
        {
            byte parsed;
            if (byte.TryParse(input, out parsed)) { return parsed; }
            return 0;
        }

        /// <summary>
        /// Change int to string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string NumberToString(int input)
        {
            return input.ToString();
        }

        /// <summary>
        /// Change double to string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string NumberToString(double input)
        {
            return input.ToString("G12");
        }

        /// <summary>
        /// Change byte to string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string NumberToString(byte input)
        {
            return input.ToString();
        }

    }

}
