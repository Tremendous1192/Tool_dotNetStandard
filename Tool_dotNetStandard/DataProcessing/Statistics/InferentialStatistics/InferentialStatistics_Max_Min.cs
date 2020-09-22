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
            double[,] sorted = InferentialStatistics.AscendingSort(designMatrix);
            double[,] max = new double[1, designMatrix.GetLength(1)];
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                max[0, j] = sorted[sorted.GetLength(0) - 1, j];
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
            double[,] sorted = InferentialStatistics.AscendingSort(designMatrix);
            double[,] min = new double[1, designMatrix.GetLength(1)];
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                min[0, j] = sorted[0, j];
            }
            return min;
        }

    }

}
