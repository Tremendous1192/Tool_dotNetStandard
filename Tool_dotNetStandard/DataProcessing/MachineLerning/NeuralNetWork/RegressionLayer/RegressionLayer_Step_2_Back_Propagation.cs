using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public partial class RegressionLayer : BaseLayer
    {

        /// <summary>
        /// 損失関数の計算とパラメータ更新のためのdeltaを計算する。
        /// </summary>
        /// <param name="correctData"></param>
        public void Step_2_3rd_Back_Propagation(double[,] correctData)
        {
            //損失関数の計算
            this.CorrectData = correctData;

            this.Error = Matrix.Subtraction(this.fWXplusB, correctData);
            this.ObjectiveFunction = this.Error[0, 0] * this.Error[0, 0] / 2;

            //誤差逆伝搬法のδの計算
            this.Delta = Matrix.Hadamard_product(this.Error, this.fWXplusB);
            this.DifferentialWithW = Matrix.Multiplication(this.Delta, InputTranspose);
        }

    }
}
