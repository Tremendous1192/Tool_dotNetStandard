using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public partial class BaseLayer
    {

        /// <summary>
        /// 損失関数の計算とパラメータ更新のためのdeltaを計算する。
        /// </summary>
        /// <param name="Teach"></param>
        public void Step_2_3rd_Back_Propagation(double[,] Teach)
        {
            //損失関数の計算
            teach = Teach;

            error = Matrix.Subtraction(f_wx_plus_b, teach);
            target_function = error[0, 0] * error[0, 0] / 2;

            //誤差逆伝搬法のδの計算
            delta = Matrix.Hadamard_product(error, f_wx_plus_b);
            change_w = Matrix.Multiplication(delta, Get_input_Transpose());
        }


        /// <summary>
        /// 隠れ層クラス以外でこのメソッドを使用すると、例外を返します。
        /// </summary>
        /// <param name="w_next"></param>
        /// <param name="delta_next"></param>
        public void Step_2_3rd_Back_Propagation(double[,] w_next, double[,] delta_next)
        {
            throw new FormatException("隠れ層クラス以外では、このオーバーロードを使用できません。");
            double[,] w_T = Matrix.TransposeMatrix(w_next);
            double[,] w_T_x_delta = Matrix.Multiplication(w_T, delta_next);

            delta = Matrix.Hadamard_product(w_T_x_delta, f_dash_wx_plus_b);
            change_w = Matrix.Multiplication(delta, Get_input_Transpose());
        }



    }
}
