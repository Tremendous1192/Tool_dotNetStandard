using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public abstract partial class BaseLayer
    {

        public BaseLayer()
        {
            ud = new UniformDistribution();
            this.Gamma = 1.0 / 1000;
            this.L1 = 0;
            this.L2 = 0;
            this.DropoutRate = 0;

            this.activationFunction = new SwishIvector();
        }


        public void Preset_w_b(double[,] w, double[,] b)
        {
            this.W = w;
            this.B = b;
        }
        public void Preset_w_b(uint inputDimension, uint outputDimension)
        {
            this.W = new double[outputDimension, inputDimension];
            for (int j = 0; j < this.W.GetLength(0); j++)
            {
                for (int k = 0; k < this.W.GetLength(1); k++)
                {
                    this.W[j, k] = (ud.NextDouble() - 0.5) * 2.0;
                }
            }

            this.B = new double[outputDimension, 1];
            for (int j = 0; j < this.B.GetLength(0); j++)
            {
                this.B[j, 0] = (ud.NextDouble() - 0.5) * 2.0;
            }
        }

        public void Preset_Hyper_Parameter(double gamma, double l1, double l2, double dropoutRate, uint seed)
        {
            ud = new UniformDistribution(seed);

            this.Gamma = Math.Max(gamma, 1.0 / 1000 / 1000 / 1000);
            this.L1 = Math.Max(l1, 0);
            this.L2 = Math.Max(l2, 0);
            this.DropoutRate = Math.Min(Math.Max(dropoutRate, 0), 1);
        }

        public virtual void Preset_Activation_Function(IVectorFunction Activation_Function)
        {
            activationFunction = Activation_Function;
        }




    }
}
