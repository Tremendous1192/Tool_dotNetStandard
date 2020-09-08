using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {


        /// <summary>
        /// 同じ要素を持つインスタンスの生成.
        /// Creating instances with the same elements as input .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Clone(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }
            return result;
        }




    }

}
