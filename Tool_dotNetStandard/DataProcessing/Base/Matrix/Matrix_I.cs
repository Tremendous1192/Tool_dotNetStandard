using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class Matrix
    {


        /// <summary>
        /// 絶対値の最大値を返す.
        /// Returns the maximum absolute value .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double InfinityNorm(double[,] matrix)
        {
            double norm = 0.0;
            foreach (double d in matrix)
            {
                norm = norm < Math.Abs(d) ? Math.Abs(d) : norm;
            }
            return norm;
        }



        /// <summary>
        /// 逆行列.
        /// Inverse matrix .
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Inverse(double[,] matrix)
        {
            Matrix.SquareMatrix(matrix);

            //オフセット済み
            double[,] offset = Matrix.OffsetDiagonal(matrix);

            //掃き出し法で計算する行列の生成
            double[,] sweeped = new double[matrix.GetLength(0), matrix.GetLength(1) * 2];
            for (int i = 0; i < offset.GetLength(0); i++)
            {
                for (int j = 0; j < offset.GetLength(1); j++)
                {
                    sweeped[i, j] = offset[i, j];
                }
                sweeped[i, i + matrix.GetLength(1)] = 1.0;
            }

            //掃き出し法の計算
            // [i , i ]を基準とする。
            // [i2 , i ]を掛けて、i2 行を全て引き算する。
            for (int i = 0; i < sweeped.GetLength(0); i++)
            {
                //要素[ i , i ] の成分が 1 になるように、　i 行目の値を除算する
                var this_low = sweeped[i, i];
                for (int j = i; j < sweeped.GetLength(1); j++)
                {
                    sweeped[i, j] /= this_low;
                }

                // i2 行目の成分に関して、i列目の値が 0になるように、各列の値を減算する
                for (int i2 = 0; i2 < sweeped.GetLength(0); i2++)
                {
                    if (i == i2) { }
                    else
                    {
                        double this_subtracter = sweeped[i2, i];
                        for (int j = i; j < sweeped.GetLength(1); j++)
                        {
                            sweeped[i2, j] -= this_subtracter * sweeped[i, j];
                        }
                    }
                }
            }

            //戻り値は、matrix.GetLength(1)列目以降の行列
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = sweeped[i, j + matrix.GetLength(1)];
                }
            }
            return result;
        }

    }

}
