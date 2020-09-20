using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public partial class HiddenLayer : BaseLayer
    {
        /// <summary>
        /// パラメータ更新のためのδを計算します。
        /// </summary>
        /// <param name="w_next"></param>
        /// <param name="delta_next"></param>
        public void Step_2_3rd_Back_Propagation(double[,] w_next, double[,] delta_next)
        {
            double[,] w_T = Matrix.TransposeMatrix(w_next);
            double[,] w_T_x_delta = Matrix.Multiplication(w_T, delta_next);

            this.Delta = Matrix.Hadamard_product(w_T_x_delta, this.fDashWXplusB);
            this.DifferentialWithW = Matrix.Multiplication(this.Delta, this.InputTranspose);
        }
    }
}
