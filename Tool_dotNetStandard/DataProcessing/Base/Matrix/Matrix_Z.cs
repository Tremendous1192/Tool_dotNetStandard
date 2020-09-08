using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {

        /// <summary>
        /// 零行列 .
        /// Zero_Matrix .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Zero_Matrix(double[,] matrix)
        {
            return new double[matrix.GetLength(0), matrix.GetLength(1)];
        }

        /// <summary>
        /// 零行列 .
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static double[,] Zero_Matrix(uint row, uint column)
        {
            return new double[row, column];
        }

    }

}
