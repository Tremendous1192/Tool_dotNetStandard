using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class TypeChange
    {

        /// <summary>
        /// Change string[,] to int[,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[,] StringToInt(string[,] input)
        {
            int[,] result = new int[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    result[i, j] = StringToInt(input[i, j]);
                }

            }
            return result;
        }

        /// <summary>
        /// Change string[,] to double[,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[,] StringToDouble(string[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    result[i,j] = StringToDouble(input[i,j]);
                }

            }
            return result;
        }

        /// <summary>
        /// Change string[,] to byte[,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[,] StringToByte(string[,] input)
        {
            byte[,] result = new byte[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    result[i, j] = StringToByte(input[i, j]);
                }

            }
            return result;
        }

        /// <summary>
        /// Change int[,] to string[,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[,] NumberToString(int[,] input)
        {
            string[,] result = new string[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    result[i, j] = input[i, j].ToString();
                }

            }
            return result;
        }

        /// <summary>
        /// Change double[,] to string[,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[,] NumberToString(double[,] input)
        {

            string[,] result = new string[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    result[i, j] = Change_String(input[i, j]);
                }

            }
            return result;
        }

        /// <summary>
        /// Change byte[,] to string[,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[,] NumberToString(byte[,] input)
        {
            string[,] result = new string[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    result[i, j] = input[i, j].ToString();

                }

            }
            return result;
        }

    }

}
