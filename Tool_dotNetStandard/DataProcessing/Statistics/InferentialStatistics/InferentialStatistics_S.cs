using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {

        /// <summary>
        /// 計画行列を昇順に並べ替える。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] AscendingSort(double[,] designMatrix)
        {
            double[,] sorted = Matrix.Clone(designMatrix);
            for (int i1 = 0; i1 < designMatrix.GetLength(0) - 1; i1++)
            {
                for (int i2 = i1 + 1; i2 < designMatrix.GetLength(0); i2++)
                {
                    for (int j = 0; j < sorted.GetLength(1); j++)
                    {
                        if (sorted[i1, j] > sorted[i2, j])
                        {
                            (sorted[i1, j], sorted[i2, j]) = (sorted[i2, j], sorted[i1, j]);
                        }
                    }
                }
            }
            return sorted;
        }


        /// <summary>
        /// 不偏標準偏差を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] StandardDeviationNonbias(double[,] designMatrix)
        {
            //平均を計算する
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
                mean[j] += designMatrix.GetLength(0);
            }


            double[,] standardDeviation = new double[1, designMatrix.GetLength(1)];
            //平方和を計算する。 Σx^2
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < designMatrix.GetLength(1); j++)
                {
                    standardDeviation[0, j] += designMatrix[i, j] * designMatrix[i, j];
                }
            }

            //不偏標準偏差のj次元目の成分を計算する
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                standardDeviation[0, j] = Math.Sqrt(
                    (standardDeviation[0, j] - designMatrix.GetLength(0) * mean[j] * mean[j])
                    / (designMatrix.GetLength(0) - 1)
                    );
            }

            return standardDeviation;
        }


        /// <summary>
        /// [0,*] 最小値
        /// [1,*] 第一四分位数
        /// [2,*] 中央値
        /// [3,*] 平均値
        /// [4,*] 第三四分位数
        /// [5,*] 最大値
        /// [6,*] 偏差平方和
        /// [7,*] 不偏分散
        /// [8,*] 不偏標準偏差
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Summary(double[,] designMatrix)
        {

            //配列を昇順に並べ替える。
            double[,] sorted = InferentialStatistics.AscendingSort(designMatrix);


            double[,] summary = new double[9, sorted.GetLength(1)];


            //[0,*] 最小値 and [5,*] 最大値
            for (int j = 0; j < summary.GetLength(1); j++)
            {
                summary[0, j] = sorted[0, j];
                summary[5, j] = sorted[sorted.GetLength(0) - 1, j];
            }

            //[3,*] 平均値
            for (int j = 0; j < sorted.GetLength(1); j++)
            {
                for (int i = 0; i < sorted.GetLength(0); i++)
                {
                    summary[3, j] += sorted[i, j];
                }
                summary[3, j] /= sorted.GetLength(0);
            }

            //[2,*] 中央値
            int median_point = sorted.GetLength(0) / 2;
            if (sorted.GetLength(0) % 2 == 0)
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    summary[2, j] = (sorted[median_point, j] + sorted[Math.Max(median_point - 1, 0), j]) / 2;
                }
            }
            else
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    summary[2, j] = sorted[median_point, j];
                }
            }

            //[1,*] 第一四分位数
            //[4,*] 第三四分位数
            int lower_quartile_point = sorted.GetLength(0) / 4;
            int upper_quartile_point = Math.Max(sorted.GetLength(0) - sorted.GetLength(0) / 4, 0);
            if (sorted.GetLength(0) % 4 < 2)
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    summary[1, j] = (sorted[lower_quartile_point, j] + sorted[Math.Max(lower_quartile_point - 1, 0), j]) / 2;
                    summary[4, j] = (sorted[upper_quartile_point, j] + sorted[Math.Max(upper_quartile_point - 1, 0), j]) / 2;
                }
            }
            else
            {
                upper_quartile_point = Math.Max(upper_quartile_point - 1, 0);
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    summary[1, j] = sorted[lower_quartile_point, j];
                    summary[4, j] = sorted[upper_quartile_point, j];
                }
            }

            //[6,*] 偏差平方和
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < designMatrix.GetLength(1); j++)
                {
                    summary[6, j] += (designMatrix[i, j] - summary[3, j]) * (designMatrix[i, j] - summary[3, j]);
                }
            }

            //[7,*] 不偏分散
            //[8,*] 不偏標準偏差
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                summary[7, j] = summary[6, j] / (designMatrix.GetLength(0) - 1);
                summary[8, j] = Math.Sqrt(summary[7, j]);
            }


            return summary;
        }





    }

}
