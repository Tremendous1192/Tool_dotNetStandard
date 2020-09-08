using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class DesignMatrix
    {

        /// <summary>
        /// 共分散行列を計算する。
        /// Calculate the covariance matrix.
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Variance_Covariance_Matrix(double[,] designMatrix)
        {

            double[,] average = DesignMatrix.Average(designMatrix);

            double[,] variance_Covariance_Matrix
                     = new double[designMatrix.GetLength(1), designMatrix.GetLength(1)];

            //分散・共分散行列の要素[j,k]を計算する。
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                for (int k = j; k < designMatrix.GetLength(1); k++)
                {

                    //j次元目とk次元目の積の平均値を計算する。 E[XY]
                    for (int n = 0; n < designMatrix.GetLength(0); n++)
                    {
                        variance_Covariance_Matrix[j, k] += designMatrix[n, j] * designMatrix[n, k];
                    }
                    variance_Covariance_Matrix[j, k] /= designMatrix.GetLength(0);

                    //j次元目の平均値とk次元目の平均値の積を引く。-E[X]E[Y]
                    variance_Covariance_Matrix[j, k] -= average[0, j] * average[0, k];

                    //j , kを入れ替えても値は同じ
                    variance_Covariance_Matrix[k, j] = variance_Covariance_Matrix[j, k];
                }
            }
            return variance_Covariance_Matrix;
        }

    }

}
