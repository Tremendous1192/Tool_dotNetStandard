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
        public static double[,] ReciprocalNumber(double[,] matrix)
        {
            //オフセット済み
            double[,] result = Matrix.OffsetAll(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = 1.0 / result[i, j];
                }
            }
            return result;
        }


        /// <summary>
        /// 行ベクトルを取り出す.
        /// Get row vector
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row_index"></param>
        /// <returns></returns>
        public static double[,] Row(double[,] matrix, uint row_index)
        {
            if (row_index >= matrix.GetLength(0))
            {
                throw new FormatException("row " + row_index + " must be less than matrix row " + matrix.GetLength(0));
            }

            double[,] result = new double[1, matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[0, j] = matrix[row_index, j];
            }
            return result;
        }


    }

}
