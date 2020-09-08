using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {

        /// <summary>
        /// 各要素を逆数に変換した行列 .
        /// Matrix with each element converted to reciprocal .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Reciprocal_Number_Matrix(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = 1.0 / matrix[i, j];
                }
            }

            return result;
        }

    }

}
