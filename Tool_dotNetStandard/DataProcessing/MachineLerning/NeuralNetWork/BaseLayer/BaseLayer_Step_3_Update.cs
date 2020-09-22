using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;


namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public abstract partial class BaseLayer
    {


        /// <summary>
        /// パラメータを更新する
        /// </summary>
        public void Step_3_3rd_Update()
        {
            //wの更新
            double[,] w_d_gamma = Matrix.Multiply(this.DifferentialWithW, this.Gamma);

            double[,] w_change = w_d_gamma;
            if (l1 > 0)
            {
                double[,] w_sign = Matrix.Sign(differentialWithW);
                double[,] w_d_L_1 = Matrix.Multiply(w_sign, l1);
                w_change = Matrix.Add(w_change, w_d_L_1);
            }
            if (l2 > 0)
            {
                double[,] w_d_L_2 = Matrix.Multiply(w, l2);
                w_change = Matrix.Add(w_change, w_d_L_2);
            }
            if (dropoutRate > 0 && dropoutRate < 1)
            {
                for (int j = 0; j < w_change.GetLength(0); j++)
                {
                    for (int k = 0; k < w_change.GetLength(1); k++)
                    {
                        if (ud.NextDouble() < dropoutRate)
                        {
                            w_change[j, k] = 0;
                        }
                    }
                }
            }

            this.W = Matrix.Subtract(this.W, w_change);

            //bの更新
            double[,] b_d_gamma = Matrix.Multiply(this.Delta, this.Gamma);

            double[,] b_change = b_d_gamma;
            if (l1 > 0)
            {
                double[,] b_sign = Matrix.Sign(delta);
                double[,] b_d_L_1 = Matrix.Multiply(b_sign, l1);
                b_change = Matrix.Add(b_change, b_d_L_1);
            }
            if (l2 > 0)
            {
                double[,] b_d_L_2 = Matrix.Multiply(b, l2);
                b_change = Matrix.Add(b_change, b_d_L_2);
            }
            if (dropoutRate > 0 && dropoutRate < 1)
            {
                for (int j = 0; j < b_change.GetLength(0); j++)
                {
                    if (ud.NextDouble() < dropoutRate)
                    {
                        b_change[j, 0] = 0;
                    }
                }
            }

           this.B = Matrix.Subtract(this.B, b_change);

        }




    }
}
