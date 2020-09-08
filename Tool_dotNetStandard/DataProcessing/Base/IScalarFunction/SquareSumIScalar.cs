using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public class SquareSumIScalar : IScalarFunction
    {

        public double Calculate_f_u(double[] input)
        {
            double result = 0.0;

            for (int j = 0; j < input.Length; j++)
            {
                result += input[j] * input[j];
            }

            return result;
        }
    }
}
