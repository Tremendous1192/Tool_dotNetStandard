using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {

        /// <summary>
        /// 行列の行と列が等しいことを確認する.
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        private static void SameSize(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(0) != m2.GetLength(0))
            {
                throw new FormatException("Align Row length of " + nameof(m1) + "(" + m1.GetLength(0) + ")" + " with that of " + nameof(m2) + "(" + m2.GetLength(0) + ")");
            }
            else if (m1.GetLength(1) != m2.GetLength(1))
            {
                throw new FormatException("Align column length of " + nameof(m1) + "(" + m1.GetLength(1) + ")" + " with that of " + nameof(m2) + "(" + m2.GetLength(1) + ")");
            }
        }


        /// <summary>
        /// 正方行列であることを確認する.
        /// </summary>
        /// <param name="matrix"></param>
        private static void SquareMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new FormatException("Align the number of " + nameof(matrix) + " row (" + matrix.GetLength(0) + ") with the number of colmun of matrix (" + matrix.GetLength(1) + ")");
            }
        }


        /// <summary>
        /// 区分行列を取り出す。
        /// Extract a sub-matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="rowIndex"></param>
        /// <param name="rowCount"></param>
        /// <param name="columnIndex"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static double[,] SubMatrix(double[,] matrix, uint rowIndex, uint rowCount, uint columnIndex, uint columnCount)
        {
            if (columnIndex >= matrix.GetLength(1))
            {
                throw new FormatException("column " + columnIndex + " must be less than matrix colmun " + matrix.GetLength(1));
            }
            if (columnCount < 1)
            {
                throw new FormatException("sub-Matrix column " + columnCount + " must be equal or higer than 1 ");
            }
            else if (columnIndex + columnCount - 1 >= matrix.GetLength(1))
            {
                throw new FormatException("sumation of base and sub column " + columnIndex + " + " + columnCount + " must be less than matrix colmun " + matrix.GetLength(1));
            }

            if (rowIndex >= matrix.GetLength(0))
            {
                throw new FormatException("row " + rowIndex + " must be less than matrix row " + matrix.GetLength(0));
            }
            if (rowCount < 1)
            {
                throw new FormatException("sub-Matrix row " + rowCount + " must be equal or higer than 1 ");
            }
            else if (rowIndex + rowCount - 1 >= matrix.GetLength(0))
            {
                throw new FormatException("sumation of base and sub row " + rowIndex + " + " + rowCount + " must be less than matrix row " + matrix.GetLength(0));
            }

            double[,] result = new double[rowCount, columnCount];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matrix[rowIndex + i, columnIndex + j];
                }
            }
            return result;
        }


        /// <summary>
        /// 行列の引き算 .
        /// Matrix subtraction
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static double[,] Subtract(double[,] m1, double[,] m2)
        {
            Matrix.SameSize(m1, m2);

            double[,] result = new double[m1.GetLength(0), m1.GetLength(1)];
            for (int j = 0; j < m1.GetLength(0); j++)
            {
                for (int k = 0; k < m1.GetLength(1); k++)
                {
                    result[j, k] = m1[j, k] - m2[j, k];
                }
            }
            return result;
        }


        /// <summary>
        /// 行列の各要素の符号に応じた値を得る
        /// </summary>
        /// <param name="m1"></param>
        /// <returns></returns>
        public static double[,] Sign(double[,] m1)
        {
            double[,] result = new double[m1.GetLength(0), m1.GetLength(1)];
            for (int j = 0; j < m1.GetLength(0); j++)
            {
                for (int k = 0; k < m1.GetLength(1); k++)
                {
                    result[j, k] = m1[j, k].CompareTo(0);
                }
            }
            return result;
        }


        /// <summary>
        /// 行列の各要素の和
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double Sums(double[,] matrix)
        {
            double result = 0.0;
            foreach (double m in matrix) { result += m; }

            return result;
        }


    }

}
