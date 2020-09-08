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

            double[,] corelationMatrix
                     = new double[designMatrix.GetLength(1), designMatrix.GetLength(1)];

            //分散・共分散行列の要素[j,k]を計算する。
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                for (int k = j; k < designMatrix.GetLength(1); k++)
                {

                    //j次元目とk次元目の積の平均値を計算する。 E[XY]
                    for (int n = 0; n < designMatrix.GetLength(0); n++)
                    {
                        corelationMatrix[j, k] += designMatrix[n, j] * designMatrix[n, k];
                    }
                    corelationMatrix[j, k] /= designMatrix.GetLength(0);

                    //j次元目の平均値とk次元目の平均値の積を引く。-E[X]E[Y]
                    corelationMatrix[j, k] -= average[0, j] * average[0, k];

                    //j , kを入れ替えても値は同じ
                    corelationMatrix[k, j] = corelationMatrix[j, k];
                }
            }


            //対角成分は正の数
            bool minus = false;
            for (int j = 0; j < corelationMatrix.GetLength(0); j++)
            {
                if (corelationMatrix[j, j] < 0) { minus = true; break; }
            }
            if (minus)
            {
                for (int j = 0; j < corelationMatrix.GetLength(0); j++)
                {
                    for (int k = 0; k < corelationMatrix.GetLength(1); k++)
                    {
                        corelationMatrix[j, k] *= -1;
                    }
                }
            }

            double[] std = new double[corelationMatrix.GetLength(0)];
            for (int j = 0; j < corelationMatrix.GetLength(0); j++)
            {
                std[j] = Math.Sqrt(corelationMatrix[j, j]);
            }
            for (int j = 0; j < corelationMatrix.GetLength(0); j++)
            {
                for (int k = 0; k < corelationMatrix.GetLength(1); k++)
                {
                    corelationMatrix[j, k] /= std[j] * std[k];
                }
            }

            return corelationMatrix;
        }

    }


}
