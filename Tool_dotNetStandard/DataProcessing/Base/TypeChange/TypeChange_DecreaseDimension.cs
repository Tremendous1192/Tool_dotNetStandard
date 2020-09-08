using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class TypeChange
    {

        /// <summary>
        /// Chnage double[,] to double[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[] Change_Array_2_to_1(double[,] input)
        {
            int row = input.GetLength(0);
            int colmun = input.GetLength(1);

            double[] result = new double[row * colmun];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < colmun; j++)
                {
                    result[i * colmun + j] = input[i, j];
                }
            }
            return result;
        }
        /// <summary>
        /// Chnage double[,,] to double[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[] Change_Array_3_to_1(double[,,] input)
        {
            int row = input.GetLength(0);
            int colmun = input.GetLength(1);
            int depth = input.GetLength(2);

            double[] result = new double[row * colmun];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < colmun; j++)
                {
                    for (int k = 0; k < depth; k++)
                    {
                        result[i * colmun * depth + j * depth + k] = input[i, j, k];
                    }
                }
            }
            return result;
        }

    }

}
