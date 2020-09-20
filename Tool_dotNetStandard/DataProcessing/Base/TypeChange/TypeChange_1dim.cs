using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class TypeChange
    {

        /// <summary>
        /// Change string[] to int[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] StringToInt(string[] input)
        {
            int[] result = new int[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                result[i] = StringToInt(input[i]);
            }
            return result;
        }

        /// <summary>
        /// Change string[] to double[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[] StringToDouble(string[] input)
        {
            double[] result = new double[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                result[i] = StringToDouble(input[i]);
            }
            return result;
        }

        /// <summary>
        /// Change string[] to byte[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] StringToByte(string[] input)
        {
            byte[] result = new byte[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                result[i] = StringToByte(input[i]);
            }
            return result;
        }

        /// <summary>
        /// Change int[] to string[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] NumberToString(int[] input)
        {
            string[] result = new string[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                result[i] = input[i].ToString();
            }
            return result;
        }

        /// <summary>
        /// Change double[] to string[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] NumberToString(double[] input)
        {

            string[] result = new string[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                result[i] = Change_String(input[i]);
            }
            return result;
        }

        /// <summary>
        /// Change byte[] to string[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] NumberToString(byte[] input)
        {
            string[] result = new string[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                result[i] = input[i].ToString();
            }
            return result;
        }

    }

}
