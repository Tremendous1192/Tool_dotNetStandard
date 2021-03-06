﻿using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {



        /// <summary>
        /// 不偏平均を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Mean(double[,] designMatrix)
        {
            double[] mean = new double[designMatrix.GetLength(1)];
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < designMatrix.GetLength(1); j++)
                {
                    mean[j] += designMatrix[i, j];

                }
            }
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                mean[j] /= designMatrix.GetLength(0);
            }

            return TypeChange.Change_Array_1_to_2(mean, mean.Length);
        }


        /// <summary>
        /// 中央値を計算する
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Median(double[,] designMatrix)
        {

            //配列を昇順に並べ替える。
            double[,] sorted = InferentialStatistics.AscendingSort(designMatrix);


            double[] median = new double[sorted.GetLength(1)];

            //中央値は、要素数を2で割ったときのあまりで計算が異なる。
            int median_point = sorted.GetLength(0) / 2;
            if (sorted.GetLength(0) % 2 == 0)
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    median[j] = (sorted[median_point, j] + sorted[Math.Max(median_point - 1, 0), j]) / 2;
                }
            }
            else
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    median[j] = sorted[median_point, j];
                }
            }

            return TypeChange.Change_Array_1_to_2(median, median.Length);
        }


    }
}
