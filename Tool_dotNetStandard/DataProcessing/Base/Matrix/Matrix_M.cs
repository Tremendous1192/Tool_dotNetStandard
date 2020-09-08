using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {

        /// <summary>
        /// 行列の掛け算.
        /// Matrix multiplication .
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static double[,] Multiplication(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(1) != m2.GetLength(0))
            {
                throw new FormatException("Align columns of " + nameof(m1) + " (" + m1.GetLength(1) + ")" + " with row of " + nameof(m2) + " (" + m2.GetLength(0) + ")");
            }

            double[,] result = new double[m1.GetLength(0), m2.GetLength(1)];
            double h = 0.0;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    h = 0.0;
                    for (int k = 0; k < m1.GetLength(1); k++)
                    {
                        h += m1[i, k] * m2[k, j];
                    }
                    result[i, j] = h;
                }
            }
            return result;
        }


    }

}
