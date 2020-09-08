using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public class UnitCircleIScalar : IScalarFunction
    {
        public double Calculate_f_u(double[] input)
        {
            double result = 0.0;

            for (int j = 0; j < input.Length; j++)
            {
                result += input[j] * input[j];
            }

            if (result > 1) { return 0.0; }
            return 1.0;
        }
    }
}
