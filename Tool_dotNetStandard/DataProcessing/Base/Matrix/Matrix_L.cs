using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {

        /// <summary>
        /// 絶対値の和。Manhattan norm
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double L1Norm(double[,] matrix)
        {
            double norm = 0;
            foreach (double d in matrix)
            {
                norm += Math.Abs(d);
            }
            return norm;
        }

        /// <summary>
        /// 二乗和の平方根。Euclid norm
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double L2Norm(double[,] matrix)
        {
            double norm = 0;
            foreach (double d in matrix)
            {
                norm += d * d;
            }
            return Math.Sqrt(norm);
        }




    }

}
