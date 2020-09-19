using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class DesignMatrix
    {

        /// <summary>
        /// 相関係数の行列を得る
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] CorelationMatrix(double[,] designMatrix)
        {
            double[,] average = DesignMatrix.Average(designMatrix);

            double[,] corelationMatrix = new double[designMatrix.GetLength(1), designMatrix.GetLength(1)];

            //分散・共分散行列の要素[j,k]を計算する。
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j1 = 0; j1 < designMatrix.GetLength(1); j1++)
                {
                    for (int j2 = 0; j1 < designMatrix.GetLength(1); j2++)
                    {
                        //j次元目とk次元目の積の平均値を計算する。 E[XY]
                        corelationMatrix[j1, j2] += designMatrix[i, j1] * designMatrix[i, j2];
                    }
                }
            }
            for (int j1 = 0; j1 < designMatrix.GetLength(1); j1++)
            {
                for (int j2 = j1; j1 < designMatrix.GetLength(1); j2++)
                {
                    //j次元目とk次元目の積の平均値を計算する。 E[XY]
                    corelationMatrix[j1, j2] /= designMatrix.GetLength(0);


                    //j次元目の平均値とk次元目の平均値の積を引く。-E[X]E[Y]
                    corelationMatrix[j1, j2] -= average[0, j1] * average[0, j2];

                    //j , kを入れ替えても値は同じ
                    corelationMatrix[j2, j1] = corelationMatrix[j1, j2];
                }
            }


            double[] std = new double[corelationMatrix.GetLength(0)];
            for (int j = 0; j < corelationMatrix.GetLength(0); j++)
            {
                std[j] = Math.Sqrt(corelationMatrix[j, j]);
            }
            for (int j1 = 0; j1 < corelationMatrix.GetLength(0); j1++)
            {
                for (int j2 = 0; j2 < corelationMatrix.GetLength(1); j2++)
                {
                    corelationMatrix[j1, j2] /= std[j1] * std[j2];
                }
            }

            return corelationMatrix;
        }

    }


}
