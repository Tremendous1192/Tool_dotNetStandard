using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public interface IScalarFunction
    {
        double Calculate_f_u(double[] input);
    }
}
