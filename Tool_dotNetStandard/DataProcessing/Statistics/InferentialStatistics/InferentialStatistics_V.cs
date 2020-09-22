using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {


        /// <summary>
        /// 不偏分散・共分散行列を計算する
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] VarianceCovarianceNonbias(double[,] designMatrix)
        {
            //ベクトルの総和を計算する。
            double[] mean = new double[designMatrix.GetLength(1)];
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < designMatrix.GetLength(1); j++)
                {
                    mean[j] += designMatrix[i, j];
                }
            }
            for (int j = 0; j < mean.Length; j++) { mean[j] /= designMatrix.GetLength(0); }


            double[,] variance_Covariance_Matrix = new double[designMatrix.GetLength(1), designMatrix.GetLength(1)];

            //j1次元目とj2次元目の積の和を計算する。 Σxy
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j1 = 0; j1 < designMatrix.GetLength(1); j1++)
                {
                    for (int j2 = j1; j2 < designMatrix.GetLength(1); j2++)
                    {
                        variance_Covariance_Matrix[j1, j2] += designMatrix[i, j1] * designMatrix[i, j2];
                    }
                }
            }
            for (int j1 = 0; j1 < designMatrix.GetLength(1); j1++)
            {
                for (int j2 = j1; j2 < designMatrix.GetLength(1); j2++)
                {
                    variance_Covariance_Matrix[j1, j2] =
                        (variance_Covariance_Matrix[j1, j2] - designMatrix.GetLength(0) * mean[j1] * mean[j2])
                        / (designMatrix.GetLength(0) - 1);

                    //j1 , j2を入れ替えても値は同じ
                    variance_Covariance_Matrix[j2, j1] = variance_Covariance_Matrix[j1, j2];
                }
            }

            return variance_Covariance_Matrix;
        }


    }

}
