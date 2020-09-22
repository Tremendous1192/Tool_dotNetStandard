using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {


        /// <summary>
        /// アダマール積 .
        /// Hadamard product .
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static double[,] HadamardMultiply(double[,] m1, double[,] m2)
        {
            Matrix.SameSize(m1, m2);

            double[,] result = new double[m1.GetLength(0), m1.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    result[i, j] = m1[i, j] * m2[i, j];
                }
            }
            return result;
        }


        /// <summary>
        /// アダマール積 の割り算バージョン
        /// Division version of Hadamard product .
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static double[,] HadamardDivide(double[,] m1, double[,] m2)
        {
            Matrix.SameSize(m1, m2);

            double[,] offset = Matrix.OffsetAll(m2);

            double[,] result = new double[m1.GetLength(0), m1.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    result[i, j] = m1[i, j] / offset[i, j];
                }
            }
            return result;
        }

    }

}
