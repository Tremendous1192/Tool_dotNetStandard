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
            for (int k = 0; k < designMatrix.GetLength(1); k++)
            {
                for (int j = 0; j < designMatrix.GetLength(0); j++)
                {
                    average[0, k] += designMatrix[j, k];
                }
                average[0, k] /= designMatrix.GetLength(0);
            }

            return average;
        }




    }


}
