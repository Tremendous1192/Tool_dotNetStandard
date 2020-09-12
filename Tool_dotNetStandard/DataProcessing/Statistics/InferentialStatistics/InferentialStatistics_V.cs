using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {


        /// <summary>
        /// 標本分散・標本共分散行列を計算する
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Variance_Covariance_Matrix_Nonbias(double[,] designMatrix)
        {
            //ベクトルの総和を計算する。
            double[] sum = new double[designMatrix.GetLength(1)];
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < designMatrix.GetLength(1); j++)
                {
                    sum[j] += designMatrix[i, j];
                }
            }


            double[,] variance_Covariance_Matrix
                     = new double[designMatrix.GetLength(1), designMatrix.GetLength(1)];

            //標本分散・共分散行列の要素[j,k]を計算する。
            for (int i = 0; i < designMatrix.GetLength(1); i++)
            {
                for (int j = i; j < designMatrix.GetLength(1); j++)
                {

                    //j次元目とk次元目の積の和を計算する。 Σxy
                    for (int i2 = 0; i2 < designMatrix.GetLength(0); i2++)
                    {
                        variance_Covariance_Matrix[i, j] += designMatrix[i2, i] * designMatrix[i2, j];
                    }

                    //要素の積の和から、要素の和の積を引く
                    variance_Covariance_Matrix[i, j] -= sum[i] * sum[j];

                    //( 要素数 - 1 )で割る
                    variance_Covariance_Matrix[i, j] /= designMatrix.GetLength(0) - 1;

                    //j , kを入れ替えても値は同じ
                    variance_Covariance_Matrix[j, i] = variance_Covariance_Matrix[i, j];
                }
            }

            return variance_Covariance_Matrix;
        }


    }

}
