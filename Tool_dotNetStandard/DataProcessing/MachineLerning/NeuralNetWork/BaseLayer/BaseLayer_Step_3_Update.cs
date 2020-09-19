using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;


namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public partial class BaseLayer
    {


        /// <summary>
        /// パラメータを更新する
        /// </summary>
        public void Step_3_3rd_Update()
        {
            //wの更新
            double[,] w_d_gamma = Matrix.ScalarMultiplication(change_w, gamma);

            double[,] w_change = w_d_gamma;
            if (L_1 > 0)
            {
                double[,] w_sign = Matrix.Sign_Element(change_w);
                double[,] w_d_L_1 = Matrix.ScalarMultiplication(w_sign, L_1);
                w_change = Matrix.Addition(w_change, w_d_L_1);
            }
            if (L_2 > 0)
            {
                double[,] w_d_L_2 = Matrix.ScalarMultiplication(w, L_2);
                w_change = Matrix.Addition(w_change, w_d_L_2);
            }
            if (drop_out > 0 && drop_out < 1)
            {
                for (int j = 0; j < w_change.GetLength(0); j++)
                {
                    for (int k = 0; k < w_change.GetLength(1); k++)
                    {
                        if (ud.NextDouble() < drop_out)
                        {
                            w_change[j, k] = 0;
                        }
                    }
                }
            }

            w = Matrix.Subtraction(w, w_change);

            //bの更新
            double[,] b_d_gamma = Matrix.ScalarMultiplication(delta, gamma);

            double[,] b_change = b_d_gamma;
            if (L_1 > 0)
            {
                double[,] b_sign = Matrix.Sign_Element(delta);
                double[,] b_d_L_1 = Matrix.ScalarMultiplication(b_sign, L_1);
                b_change = Matrix.Addition(b_change, b_d_L_1);
            }
            if (L_2 > 0)
            {
                double[,] b_d_L_2 = Matrix.ScalarMultiplication(b, L_2);
                b_change = Matrix.Addition(b_change, b_d_L_2);
            }
            if (drop_out > 0 && drop_out < 1)
            {
                for (int j = 0; j < b_change.GetLength(0); j++)
                {
                    if (ud.NextDouble() < drop_out)
                    {
                        b_change[j, 0] = 0;
                    }
                }
            }

            b = Matrix.Subtraction(b, b_change);

        }




    }
}
