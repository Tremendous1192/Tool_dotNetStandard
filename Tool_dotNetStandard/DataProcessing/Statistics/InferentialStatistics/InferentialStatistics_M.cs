using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {



        /// <summary>
        /// 標本平均を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Mean(double[,] designMatrix)
        {
            double[,] mean = new double[1, designMatrix.GetLength(1)];
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                for (int i = 0; i < designMatrix.GetLength(0); i++)
                {
                    mean[0, j] += designMatrix[i, j];
                }
                mean[0, j] /= designMatrix.GetLength(0);
            }

            return mean;
        }


        /// <summary>
        /// 中央値を計算する
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Median(double[,] designMatrix)
        {

            //配列を昇順に並べ替える。
            double[,] sorted = InferentialStatistics.Sorted_in_Ascending_Order(designMatrix);


            double[,] median = new double[1, sorted.GetLength(1)];

            //中央値は、要素数を2で割ったときのあまりで計算が異なる。
            int median_point = sorted.GetLength(0) / 2;
            if (sorted.GetLength(0) % 2 == 0)
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    median[0, j] = (sorted[median_point, j] + sorted[Math.Max(median_point - 1, 0), j]) / 2;
                }
            }
            else
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    median[0, j] = sorted[median_point, j];
                }
            }

            return median;
        }


    }
}
