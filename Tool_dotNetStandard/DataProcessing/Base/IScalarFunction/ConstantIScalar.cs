using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public class ConstantIScalar : IScalarFunction
    {
        public double Calculate_f_u(double[] input)
        {
            return 1.0;
        }
    }
}
