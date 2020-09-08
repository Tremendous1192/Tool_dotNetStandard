using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public class GaussianIVector : IVectorFunction
    {


        public double[,] Calculate_f_u(double[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            double in_exp = 1.0;
            double divider = Math.Sqrt(2 * Math.PI);

            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    in_exp = -input[j, k] * input[j, k] / 2;
                    result[j, k] = Math.Exp(in_exp) / divider;
                }
            }

            return result;
        }

        public double[,] Calculate_f_u_dash(double[,] input)
        {
            double[,] result = new double[input.GetLength(0), input.GetLength(1)];

            double in_exp = 1.0;
            double divider = Math.Sqrt(2 * Math.PI);

            for (int j = 0; j < input.GetLength(0); j++)
            {
                for (int k = 0; k < input.GetLength(1); k++)
                {
                    in_exp = -input[j, k] * input[j, k] / 2;
                    result[j, k] = -input[j, k] * Math.Exp(in_exp) / divider;
                }
            }

            return result;
        }



    }
}
