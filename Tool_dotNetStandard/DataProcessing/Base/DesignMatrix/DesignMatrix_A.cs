using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class DesignMatrix
    {

        /// <summary>k
        /// 行ベクトルの平均ベクトル .
        /// Mean vector of row vectors .
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Average(double[,] designMatrix)
        {
            double[,] average = new double[1, designMatrix.GetLength(1)];
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < designMatrix.GetLength(1); j++)
                {
                    average[0, j] += designMatrix[i, j];
                }
            }

            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                average[0, j] /= designMatrix.GetLength(0);
            }

            return average;
        }




    }


}
