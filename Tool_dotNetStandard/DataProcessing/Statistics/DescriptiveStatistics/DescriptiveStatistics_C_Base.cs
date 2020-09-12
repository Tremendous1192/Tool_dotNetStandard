using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class DescriptiveStatistics
    {


        /// <summary>
        /// 水準名の被りを取り除く。
        /// </summary>
        /// <param name="labels"></param>
        /// <returns></returns>
        protected static void TrimOverlap(ref string[] labels)
        {
            bool[] check = new bool[labels.Length];
            for (int i = 0; i < check.Length; i++)
            {
                check[i] = true;
            }

            for (int i = 0; i < labels.Length; i++)
            {
                if (!check[i]) { continue; }
                for (int j = i + 1; j < labels.Length; j++)
                {
                    if (labels[i] == labels[j]) { check[j] = false; }
                }
            }

            List<string> result = new List<string>();
            for (int i = 0; i < labels.Length; i++)
            {
                if (check[i]) { result.Add(labels[i]); }
            }

            labels = result.ToArray();
        }


        /// <summary>
        /// 質的変数をダミー変数に変更する。
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected static uint[] Set_Dummy_Variable(string[] labels, string[] data)
        {
            uint[] dummyVariable = new uint[data.Length];
            for (uint i = 0; i < data.Length; i++)
            {
                int row = -1;
                for (int j = 0; j < labels.Length; j++)
                {
                    row = j;
                }
                if (row < 0)
                {
                    throw new FormatException(nameof(labels) + "の水準にないデータが含まれています。");
                }
                dummyVariable[i] = (uint)row;
            }
            return dummyVariable;
        }


        /// <summary>
        /// 質的変数をダミー変数に変更する。
        /// True = 0 .
        /// False = 1 .
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected static uint[] Set_Dummy_Variable(bool[] data)
        {
            uint[] dummyVariable = new uint[data.Length];
            for (uint i = 0; i < data.Length; i++)
            {
                if (!data[i]) { dummyVariable[i] = 1; }
            }
            return dummyVariable;
        }


        /// <summary>
        /// 小計を計算する。
        /// </summary>
        /// <param name="contingencyTable"></param>
        protected static void CalculateSubTotal(ref uint[,] contingencyTable)
        {
            for (int i = 0; i < contingencyTable.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < contingencyTable.GetLength(1) - 1; j++)
                {
                    contingencyTable[i, contingencyTable.GetLength(1) - 1] += contingencyTable[i, j];
                    contingencyTable[contingencyTable.GetLength(0) - 1, j] += contingencyTable[i, j];
                }
            }
        }



    }
}
