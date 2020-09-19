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

            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < designMatrix.GetLength(1); j++)
                {
                    average_square[0, j] += designMatrix[i, j] * designMatrix[i, j];
                }
            }

            double[,] result = new double[1, designMatrix.GetLength(1)];

            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                result[0, j] = Math.Sqrt(average_square[0, j] / designMatrix.GetLength(0) - average[0, j] * average[0, j]);
            }
            return result;
        }

    }


}
