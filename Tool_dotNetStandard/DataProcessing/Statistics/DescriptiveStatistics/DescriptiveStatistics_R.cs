using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class DescriptiveStatistics
    {

        /// <summary>
        /// データを降順で順位付けする。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static uint[] Rank(double[] data)
        {
            uint[] rank = new uint[data.Length];
            for (uint i = 0; i < data.Length; i++)
            {
                for (uint j = 0; j < data.Length; j++)
                {
                    if (i == j) { continue; }
                    else
                    {
                        if (data[i] < data[j]) { rank[i]++; }
                    }
                }
            }
            return rank;
        }

    }
}
