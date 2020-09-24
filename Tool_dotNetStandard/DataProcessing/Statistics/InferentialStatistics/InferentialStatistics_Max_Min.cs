using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

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
            double[] max = new double[designMatrix.GetLength(1)];
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                max[j] = sorted[sorted.GetLength(0) - 1, j];
            }
            return TypeChange.Change_Array_1_to_2(max, max.Length);
        }

        /// <summary>
        /// 最小値を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Minimum(double[,] designMatrix)
        {
            double[,] sorted = InferentialStatistics.AscendingSort(designMatrix);
            double[] min = new double[designMatrix.GetLength(1)];
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                min[j] = sorted[0, j];
            }
            return TypeChange.Change_Array_1_to_2(min, min.Length);
        }

    }

}
