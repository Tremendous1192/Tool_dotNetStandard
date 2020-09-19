using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    public abstract partial class BaseLayer
    {
        //誤差逆伝搬法は、
        //1.最終層か、中間層か
        //2.最終層が回帰分析か分類問題か
        //で計算内容が異なるので、各クラスで実装した.
    }
}
