using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class TypeChange
    {

        /// <summary>
        ///  Chnage double[] to double[,]
        /// </summary>
        /// <param name="input"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static double[,] Change_Array_1_to_2(double[] input, int column)
        {
            if (input.GetLength(0) % column > 0 || input.GetLength(0) < column)
            {
                throw new FormatException
                    ("Length of " + nameof(input) + " must be natural integer multiple of " +
                    nameof(column));
            }

            int row = input.GetLength(0) / column;

            double[,] result = new double[row, column];

            int i = 0;
            int j = 0;
            for (int k = 0; k < input.Length; k++)
            {
                i = k / column;
                j = k % column;
                result[i, j] = input[k];
            }
            return result;
        }

        /// <summary>
        /// Chnage double[] to double[,,]
        /// </summary>
        /// <param name="input"></param>
        /// <param name="column"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static double[,,] Change_Array_1_to_3(double[] input, int column, int depth)
        {
            if (input.GetLength(0) % (column * depth) > 0 || input.GetLength(0) < (column * depth))
            {
                throw new FormatException
                    ("Length of " + nameof(input) + " must be natural integer multiple of " +
                    nameof(column) + " x " + nameof(depth));
            }

            int row = input.GetLength(0) / (column * depth);

            double[,,] result = new double[row, column, depth];

            int i = 0;
            int j = 0;
            int k = 0;
            for (int L = 0; L < input.Length; L++)
            {
                i = L / (column * depth);
                j = (L % (column * depth)) / depth;
                k = (L % (column * depth)) % depth;

                result[i, j, k] = input[L];
            }
            return result;
        }

    }

}
