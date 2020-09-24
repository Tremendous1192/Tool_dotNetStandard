using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {

        /// <summary>
        /// 第3四分位数を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] UpperQuartile(double[,] designMatrix)
        {

            //配列を昇順に並べ替える。
            double[,] sorted = InferentialStatistics.AscendingSort(designMatrix);

            double[] upperQuartile = new double[ sorted.GetLength(1)];

            //第3四分位数は、要素数を4で割ったときのあまりで計算が異なる。
            int upper_quartile_point = Math.Max(sorted.GetLength(0) - sorted.GetLength(0) / 4, 0);
            if (sorted.GetLength(0) % 4 < 2)
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    upperQuartile[ j] = (sorted[upper_quartile_point, j] + sorted[Math.Max(upper_quartile_point - 1, 0), j]) / 2;
                }
            }
            else
            {
                upper_quartile_point = Math.Max(upper_quartile_point - 1, 0);
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    upperQuartile[ j] = sorted[upper_quartile_point, j];
                }
            }

            return TypeChange.Change_Array_1_to_2(upperQuartile, upperQuartile.Length);
        }




    }

}
