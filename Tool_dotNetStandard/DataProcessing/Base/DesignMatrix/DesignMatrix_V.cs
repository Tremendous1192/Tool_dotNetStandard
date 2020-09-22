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
        public static double[,] VarianceCovariance(double[,] designMatrix)
        {

            double[,] average = DesignMatrix.Average(designMatrix);

            double[,] variance_Covariance_Matrix = new double[designMatrix.GetLength(1), designMatrix.GetLength(1)];

            //分散・共分散行列の要素[j,k]を計算する。
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j1 = 0; j1 < designMatrix.GetLength(1); j1++)
                {
                    for (int j2 = 0; j1 < designMatrix.GetLength(1); j2++)
                    {
                        //j次元目とk次元目の積の平均値を計算する。 E[XY]
                        variance_Covariance_Matrix[j1, j2] += designMatrix[i, j1] * designMatrix[i, j2];
                    }
                }
            }
            for (int j1 = 0; j1 < designMatrix.GetLength(1); j1++)
            {
                for (int j2 = j1; j1 < designMatrix.GetLength(1); j2++)
                {
                    //j次元目とk次元目の積の平均値を計算する。 E[XY]
                    variance_Covariance_Matrix[j1, j2] /= designMatrix.GetLength(0);


                    //j次元目の平均値とk次元目の平均値の積を引く。-E[X]E[Y]
                    variance_Covariance_Matrix[j1, j2] -= average[0, j1] * average[0, j2];

                    //j , kを入れ替えても値は同じ
                    variance_Covariance_Matrix[j2, j1] = variance_Covariance_Matrix[j1, j2];
                }
            }

            return variance_Covariance_Matrix;
        }

    }

}
