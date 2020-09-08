using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public class GaussianIScalar : IScalarFunction
    {
        public double Calculate_f_u(double[] input)
        {
            double index = 0.0;

            for (int j = 0; j < input.Length; j++)
            {
                index += input[j] * input[j];
            }

            return Math.Exp(-index / 2.0);
        }
    }
}
