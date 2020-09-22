using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {

        /// <summary>
        /// 四分位数を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] LowerQuartile(double[,] designMatrix)
        {

            //配列を昇順に並べ替える。
            double[,] sorted = InferentialStatistics.AscendingSort(designMatrix);


            double[,] lowerQuartile = new double[1, sorted.GetLength(1)];

            //四分位数は、要素数を4で割ったときのあまりで計算が異なる。
            int lower_quartile_point = sorted.GetLength(0) / 4;
            if (sorted.GetLength(0) % 4 < 2)
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    lowerQuartile[0, j] = (sorted[lower_quartile_point, j] + sorted[Math.Max(lower_quartile_point - 1, 0), j]) / 2;
                }
            }
            else
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    lowerQuartile[0, j] = sorted[lower_quartile_point, j];
                }
            }

            return lowerQuartile;
        }



    }

}
