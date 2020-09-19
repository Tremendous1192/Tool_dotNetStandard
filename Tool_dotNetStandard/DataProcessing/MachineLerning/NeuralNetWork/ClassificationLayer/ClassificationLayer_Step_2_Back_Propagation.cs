﻿using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public partial class ClassificationLayer : BaseLayer
    {

        /// <summary>
        /// 損失関数の計算とパラメータ更新のためのdeltaを計算する。
        /// </summary>
        /// <param name="Teach"></param>
        public void Step_2_3rd_Back_Propagation(double[,] Teach)
        {
            teach = Teach;

            //誤差逆伝搬法のδの計算
            //逆数はratioの計算で一括化できる
            //double[,] Reciprocal_Number_Output = Matrix.Reciprocal_Number_Matrix(f_wx_plus_b);

            //ratioの計算は省略可能
            //double[,] ratio = Matrix.Hadamard_product(teach, Reciprocal_Number_Output);
            //double[,] ratio = Matrix.Hadamard_division(teach, f_wx_plus_b);

            //errorの計算も省略可能
            //error = Matrix.Scalar_Multiplication(ratio, -1.0);

            //deltaの計算は、ratioとerrorの計算を省略した形で書ける
            //delta = Matrix.Hadamard_product(error, f_wx_plus_b);
            delta = Matrix.ScalarMultiplication(teach, -1);

            change_w = Matrix.Multiplication(delta, Get_input_Transpose());


            //損失関数の計算
            double[,] ln_output = Matrix.Logarithm_LN(f_wx_plus_b);
            double[,] product = Matrix.Hadamard_product(teach, ln_output);
            target_function = -Matrix.Summation_X(product);
        }


    }
}
