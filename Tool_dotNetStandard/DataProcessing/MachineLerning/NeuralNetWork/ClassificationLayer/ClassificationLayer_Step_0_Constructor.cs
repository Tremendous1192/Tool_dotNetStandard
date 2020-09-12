﻿using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public partial class ClassificationLayer : BaseLayer
    {


        public ClassificationLayer()
        {
            activation_Function = new SoftMaxIVector();
        }


        public void Preset_Activation_Function(IVectorFunction Activation_Function)
        {
        }

    }
}
