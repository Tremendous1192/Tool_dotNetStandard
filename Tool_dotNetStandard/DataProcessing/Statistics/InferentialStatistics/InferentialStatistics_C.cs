using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {

        /// <summary>
        /// 相関係数を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Correlation(double[,] designMatrix)
        {

            //分散共分散行列
            double[,] variance_Covariance_Matrix = InferentialStatistics.VarianceCovarianceNonbias(designMatrix);

            //標準偏差を計算する
            double[] std = new double[designMatrix.GetLength(1)];
            for (int j = 0; j < variance_Covariance_Matrix.GetLength(0); j++)
            {
                std[j] = Math.Sqrt(variance_Covariance_Matrix[j, j]);
            }

            //相関係数行列
            double[,] CorrelationMatrix
                     = new double[designMatrix.GetLength(1), designMatrix.GetLength(1)];

            //相関係数を計算する。
            for (int i = 0; i < CorrelationMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < CorrelationMatrix.GetLength(1); j++)
                {
                    CorrelationMatrix[i, j] = variance_Covariance_Matrix[i, j] / std[i] / std[j];
                }
            }

            return CorrelationMatrix;
        }


    }


}
