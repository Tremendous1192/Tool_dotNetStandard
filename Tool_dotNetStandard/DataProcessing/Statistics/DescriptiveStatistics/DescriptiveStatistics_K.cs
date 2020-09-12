using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class DescriptiveStatistics
    {
        /// <summary>
        /// ケンドールの順位相関係数を計算する。
        /// </summary>
        /// <param name="data_A"></param>
        /// <param name="data_B"></param>
        /// <returns></returns>
        public static double Kendall_Rank_Correlation_Coefficient(double[] data_A, double[] data_B)
        {
            //データ数が等しくないと例外を返す。
            if (data_A.GetLength(0) != data_B.GetLength(0))
            {
                throw new FormatException("Align length of " + nameof(data_A) + "(" + data_A.GetLength(0) + ")" + " with that of " + nameof(data_B) + "(" + data_B.GetLength(0) + ")");
            }

            double result = 0;
            for (int i = 0; i < data_A.Length - 1; i++)
            {
                for (int j = i + 1; j < data_A.Length; j++)
                {
                    result += (data_A[i] - data_B[j]).CompareTo(0) * (data_B[i] - data_B[j]).CompareTo(0);
                }
            }

            return result * 2 / data_A.Length / (data_A.Length - 1);
        }


    }
}
