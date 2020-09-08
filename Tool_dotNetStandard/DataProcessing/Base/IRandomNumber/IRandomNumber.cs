using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    /// <summary>
    /// 乱数を生成するインターフェース。
    /// 乱数はメルセンヌ・ツイスタに従って生成される。
    /// </summary>
    public interface IRandomNumber
    {
        double NextDouble();
    }
}
