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
        /// <param name="correctData"></param>
        public void Step_2_3rd_Back_Propagation(double[,] correctData)
        {
            this.CorrectData = correctData;

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
            this.Delta = Matrix.Multiply(this.CorrectData, -1);

            this.DifferentialWithW = Matrix.Multiply(this.Delta, this.InputTranspose);


            //損失関数の計算
            double[,] ln_output = Matrix.NaturalLogarithm(this.fWXplusB);
            double[,] product = Matrix.HadamardMultiply(this.CorrectData, ln_output);
            this.ObjectiveFunction = -Matrix.Sums(product);
        }


    }
}
