using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class DesignMatrix
    {

        /// <summary>
        /// 共分散行列の逆行列
        /// Calculate Inverse of the covariance matrix.
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Inverse_Variance_Covariance_Matrix(double[,] designMatrix)
        {
            return Matrix.Inverse(DesignMatrix.VarianceCovariance(designMatrix));
        }

    }

}
