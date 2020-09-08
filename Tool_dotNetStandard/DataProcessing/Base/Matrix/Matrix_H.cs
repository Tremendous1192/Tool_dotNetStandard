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
        public static double[,] Hadamard_product(double[,] m1, double[,] m2)
        {

            if (m1.GetLength(0) != m2.GetLength(0))
            {
                throw new FormatException("Align Row length of " + nameof(m1) + "(" + m1.GetLength(0) + ")" + " with that of " + nameof(m2) + "(" + m2.GetLength(0) + ")");
            }
            else if (m1.GetLength(1) != m2.GetLength(1))
            {
                throw new FormatException("Align column length of " + nameof(m1) + "(" + m1.GetLength(1) + ")" + " with that of " + nameof(m2) + "(" + m2.GetLength(1) + ")");
            }

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
        public static double[,] Hadamard_division(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(0) != m2.GetLength(0))
            {
                throw new FormatException("Align Row length of " + nameof(m1) + "(" + m1.GetLength(0) + ")" + " with that of " + nameof(m2) + "(" + m2.GetLength(0) + ")");
            }
            else if (m1.GetLength(1) != m2.GetLength(1))
            {
                throw new FormatException("Align column length of " + nameof(m1) + "(" + m1.GetLength(1) + ")" + " with that of " + nameof(m2) + "(" + m2.GetLength(1) + ")");
            }


            double shift = double.MaxValue;
            bool need_shift = false;
            foreach (double d in m2)
            {
                if (d.CompareTo(0) == 0)
                {
                    need_shift = true;
                }
                else
                {
                    shift = Math.Min(Math.Abs(d), shift);
                }
            }
            if (need_shift) { shift /= 1000 * 1000; }
            else { shift = 0; }

            double[,] result = new double[m1.GetLength(0), m1.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    result[i, j] = m1[i, j] / (m2[i, j] + shift);
                }
            }
            return result;
        }

    }

}
