using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {
        /// <summary>
        /// すべての要素にオフセット項を加える.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static double[,] OffsetAll(double[,] matrix)
        {
            double offset = double.MaxValue;
            foreach (double m in matrix)
            {
                offset = offset > m ? m : offset;
            }
            offset /= 1000 * 1000;

            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = matrix[i, j] + offset;
                }
            }
            return result;
        }

        /// <summary>
        /// 正方行列の対角成分にオフセット項を加える.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static double[,] OffsetDiagonal(double[,] matrix)
        {
            double offset = double.MaxValue;
            foreach (double m in matrix)
            {
                offset = offset > m ? m : offset;
            }
            offset /= 1000 * 1000;

            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result[i, i] = matrix[i, i] + offset;
            }
            return result;
        }


    }
}
