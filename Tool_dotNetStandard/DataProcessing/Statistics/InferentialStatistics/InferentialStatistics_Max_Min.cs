using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {



        /// <summary>
        /// 最大値を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Maximum(double[,] designMatrix)
        {
            double[,] max = new double[1, designMatrix.GetLength(1)];
            double compare = 0;
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                compare = designMatrix[0, j];
                for (int i = 1; i < designMatrix.GetLength(0); i++)
                {
                    compare = Math.Max(compare, designMatrix[i, j]);
                }
                max[0, j] = compare;
            }

            return max;
        }



        /// <summary>
        /// 最小値を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Minimum(double[,] designMatrix)
        {
            double[,] min = new double[1, designMatrix.GetLength(1)];
            double compare = 0;
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                compare = designMatrix[0, j];
                for (int i = 1; i < designMatrix.GetLength(0); i++)
                {
                    compare = Math.Min(compare, designMatrix[i, j]);
                }
                min[0, j] = compare;
            }

            return min;
        }





    }

}
