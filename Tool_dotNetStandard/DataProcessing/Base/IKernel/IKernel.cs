using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public interface IKernel
    {

        void SetDesignMatrix(double[,] designMatrix);

        double Calculate(double[,] row_Vector_1, double[,] row_Vector_2);
    }
}
