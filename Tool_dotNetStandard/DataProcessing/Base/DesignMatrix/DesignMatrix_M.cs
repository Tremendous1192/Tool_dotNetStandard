using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class DesignMatrix
    {


        /// <summary>
        /// ユークリッドノルムL2の最大値.
        /// Maximum vector magnitude .
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double Maximum_Norm_L2(double[,] design_matrix)
        {
            double norm = 0;
            double norm_max = -1;

            for (int i = 0; i < design_matrix.GetLength(0); i++)
            {
                norm = 0;
                for (int j = 0; j < design_matrix.GetLength(1); j++)
                {
                    norm += design_matrix[i, j] * design_matrix[i, j];
                }
                norm = Math.Sqrt(norm / design_matrix.GetLength(1));

                norm_max = norm_max < norm ? norm : norm_max;
            }
            return norm_max;
        }

        /// <summary>
        /// ユークリッドノルムL2の最大値の要素番号 .
        /// Element number of maximum vector size .
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static int Maximum_Norm_L2_Index(double[,] design_matrix)
        {
            double norm = 0;
            double norm_max = -1;
            int index = 0;

            for (int i = 0; i < design_matrix.GetLength(0); i++)
            {
                norm = 0;
                for (int j = 0; j < design_matrix.GetLength(1); j++)
                {
                    norm += design_matrix[i, j] * design_matrix[i, j];
                }
                norm = Math.Sqrt(norm / design_matrix.GetLength(1));

                if (norm_max < norm )
                {
                    norm_max = norm;
                    index = i;
                }
            }
            return index;
        }


        /// <summary>
        /// ユークリッドノルムL2の最小値 .
        /// Minimum vector magnitude .
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static double Minimum_Norm_L2(double[,] design_matrix)
        {
            double norm = 0;
            double norm_min = double.MaxValue;

            for (int i = 0; i < design_matrix.GetLength(0); i++)
            {
                norm = 0;
                for (int j = 0; j < design_matrix.GetLength(1); j++)
                {
                    norm += design_matrix[i, j] * design_matrix[i, j];
                }
                norm = Math.Sqrt(norm / design_matrix.GetLength(1));

                norm_min = norm_min > norm ? norm : norm_min;
            }
            return norm_min;
        }


        /// <summary>
        /// ユークリッドノルムL2の最小値の要素番号 .
        /// lement number of the minimum vector size
        /// </summary>
        /// <param name="design_matrix"></param>
        /// <returns></returns>
        public static int Minimum_Norm_L2_Index(double[,] design_matrix)
        {
            double norm = 0;
            double norm_min = double.MaxValue;
            int index = 0;

            for (int i = 0; i < design_matrix.GetLength(0); i++)
            {
                norm = 0;
                for (int j = 0; j < design_matrix.GetLength(1); j++)
                {
                    norm += design_matrix[i, j] * design_matrix[i, j];
                }
                norm = Math.Sqrt(norm / design_matrix.GetLength(1));

                if (norm_min > norm )
                {
                    norm_min = norm;
                    index = i;
                }
            }
            return index;
        }

    }

}
