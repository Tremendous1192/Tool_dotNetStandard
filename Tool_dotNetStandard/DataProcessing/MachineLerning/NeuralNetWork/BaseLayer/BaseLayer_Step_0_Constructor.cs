using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public partial class BaseLayer
    {

        public BaseLayer()
        {
            ud = new UniformDistribution();
            gamma = 1.0 / 1000;
            L_1 = 0;
            L_2 = 0;
            drop_out = 0;

            activation_Function = new SwishIvector();
        }


        public void Preset_w_b(double[,] W, double[,] B)
        {
            w = W;
            b = B;
        }
        public void Preset_w_b(uint input_dimension, uint output_dimension)
        {
            w = new double[output_dimension, input_dimension];
            for (int j = 0; j < w.GetLength(0); j++)
            {
                for (int k = 0; k < w.GetLength(1); k++)
                {
                    w[j, k] = (ud.NextDouble() - 0.5) * 2.0;
                }
            }

            b = new double[output_dimension, 1];
            for (int j = 0; j < b.GetLength(0); j++)
            {
                b[j, 0] = (ud.NextDouble() - 0.5) * 2.0;
            }
        }

        public void Preset_Hyper_Parameter(double Gamma, double L1, double L2, double Drop_out, uint seed)
        {
            ud = new UniformDistribution(seed);

            gamma = Math.Max(Gamma, 1.0 / 1000 / 1000 / 1000);
            L_1 = Math.Max(L1, 0);
            L_2 = Math.Max(L2, 0);
            drop_out = Math.Min(Math.Max(Drop_out, 0), 1);
        }

        public void Preset_Activation_Function(IVectorFunction Activation_Function)
        {
            activation_Function = Activation_Function;
        }




    }
}
