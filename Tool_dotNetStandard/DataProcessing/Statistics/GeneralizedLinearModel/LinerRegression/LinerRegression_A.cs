using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics.GeneralizedLinearModel
{
    public partial class LinerRegression
    {

        /// <summary>
        /// 計画行列に、定数項 1 を加える。
        /// </summary>
        /// <param name="design_matrix_without_constant"></param>
        /// <returns></returns>
        public static double[,] AddConstant1(double[,] design_matrix_without_constant)
        {
            double[,] design_matrix_with_constant_1 = new double[design_matrix_without_constant.GetLength(0)
                , design_matrix_without_constant.GetLength(1) + 1];

            for (int i = 0; i < design_matrix_without_constant.GetLength(0); i++)
            {
                design_matrix_with_constant_1[i, 0] = 1.0;
                for (int j = 0; j < design_matrix_without_constant.GetLength(1); j++)
                {
                    design_matrix_with_constant_1[i, j + 1] = design_matrix_without_constant[i, j];
                }
            }

            return design_matrix_with_constant_1;

        }


    }

}
