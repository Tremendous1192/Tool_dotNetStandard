using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public class HyperbolicTangentIVector : IVectorFunction
    {
        public double[,] Calculate_f_u(double[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    result[j, k] = Math.Tanh(input[j, k]);
                }
            }
            return result;
        }

        public double[,] Calculate_f_u_dash(double[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];
            double cosh_square = 1.0;

            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    //result[j, k] = 1.0 / Math.Cosh(input[j, k]) / Math.Cosh(input[j, k]);
                    cosh_square = Math.Cosh(input[j, k]) * Math.Cosh(input[j, k]);
                    result[j, k] = 1.0 / cosh_square;
                }
            }
            return result;
        }

    }

}
