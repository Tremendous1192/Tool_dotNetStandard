using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class DescriptiveStatistics
    {
        /// <summary>
        /// Spearmanの順位相関係数
        /// </summary>
        /// <param name="data_A"></param>
        /// <param name="data_B"></param>
        /// <returns></returns>
        public static double Spearmans_Rank_Correlation_Coefficient
            (uint[] data_A, uint[] data_B)
        {
            //データ数が等しくないと例外を返す。
            if (data_A.GetLength(0) != data_B.GetLength(0))
            {
                throw new FormatException("Align length of " + nameof(data_A) + "(" + data_A.GetLength(0) + ")" + " with that of " + nameof(data_B) + "(" + data_B.GetLength(0) + ")");
            }

            //計算用の平均値・和を算出する。
            double average_A = 0, average_B = 0;
            double squareSum_A = 0, squareSum_B = 0;
            double multiplicationSum = 0;
            for (int i = 0; i < data_A.Length; i++)
            {
                average_A += data_A[i];
                squareSum_A += data_A[i] * data_A[i];

                average_B += data_B[i];
                squareSum_B += data_B[i] * data_B[i];

                multiplicationSum += data_A[i] * data_B[i];
            }
            average_A /= data_A.Length;
            average_B /= data_B.Length;

            return (multiplicationSum - data_A.Length * average_A * average_B)
                / Math.Sqrt((squareSum_A - data_A.Length * average_A * average_A) 
                * (squareSum_B - data_B.Length * average_B * average_B));
        }


    }
}
