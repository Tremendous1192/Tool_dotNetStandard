using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public abstract partial class BaseLayer
    {
        /// <summary>
        /// 予測値を計算する。
        /// </summary>
        /// <param name="Input"></param>
        public void Step_1_3rd_Forward_Propagation(double[,] input)
        {
            this.Input = input;

            this.WX = Matrix.Multiplication(this.W, this.Input);

            this.WXplusB = Matrix.Addition(this.WX, this.B);

            this.fWXplusB = activationFunction.Calculate_f_u(this.WXplusB);

            this.fDashWXplusB = activationFunction.Calculate_f_u_dash(this.fWXplusB);
        }


    }
}
