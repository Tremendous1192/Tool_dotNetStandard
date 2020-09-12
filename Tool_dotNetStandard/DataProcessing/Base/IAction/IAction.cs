using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public interface IAction
    {
        /// <summary>
        /// モンテカルロ法で使用する作用関数のインターフェース。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        double Calculate_f_u(double[] input);

    }
}
