using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {
        /// <summary>
        /// 行列の足し算.
        /// Addition of 2 matrixes.
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static double[,] Add(double[,] m1, double[,] m2)
        {
            Matrix.SameSize(m1, m2);

            double[,] result = new double[m1.GetLength(0), m1.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return result;
        }



    }

}
