using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class DesignMatrix
    {

        /// <summary>
        /// 各要素の標準偏差を計算する
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] StandardDeviation(double[,] designMatrix)
        {
            double[,] average = DesignMatrix.Average(designMatrix);
            double[,] average_square = new double[1, designMatrix.GetLength(1)];

            for (int k = 0; k < designMatrix.GetLength(1); k++)
            {
                for (int j = 0; j < designMatrix.GetLength(0); j++)
                {
                    average_square[0, k] += designMatrix[j, k] * designMatrix[j, k];
                }
                average_square[0, k] /= designMatrix.GetLength(0);
            }

            double[,] result = new double[1, designMatrix.GetLength(1)];

            for (int k = 0; k < designMatrix.GetLength(1); k++)
            {
                result[0, k] = Math.Sqrt(average_square[0, k] - average[0, k] * average[0, k]);
            }
            return result;
        }

    }


}
