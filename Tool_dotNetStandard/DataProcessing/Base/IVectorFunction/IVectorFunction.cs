using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    /// <summary>
    /// 主にニューラルネットワークで使用するベクトル値関数を返すインターフェース。
    /// </summary>
    public interface IVectorFunction
    {
        double[,] Calculate_f_u(double[,] input);

        double[,] Calculate_f_u_dash(double[,] input);
    }
}
