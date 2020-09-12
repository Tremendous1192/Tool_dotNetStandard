using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class DescriptiveStatistics
    {

        /// <summary>
        /// 分割表を作成する。
        /// </summary>
        /// <param name="data_A"></param>
        /// <param name="data_B"></param>
        /// <returns></returns>
        public static uint[,] Enumerate_ContingencyTable
            (bool[] data_A,
            bool[] data_B)
        {
            //データ数が等しくないと例外を返す。
            if (data_A.GetLength(0) != data_B.GetLength(0))
            {
                throw new FormatException("Align length of " + nameof(data_A) + "(" + data_A.GetLength(0) + ")" + " with that of " + nameof(data_B) + "(" + data_B.GetLength(0) + ")");
            }

            //ダミー変数に変換する。
            uint[] dummyDataA = DescriptiveStatistics.Set_Dummy_Variable(data_A);
            uint[] dummyDataB = DescriptiveStatistics.Set_Dummy_Variable(data_B);


            //計数する。
            uint[,] contingencyTable = new uint[2 + 1, 2 + 1];
            for (int i = 0; i > data_A.Length; i++)
            {
                contingencyTable[dummyDataA[i], dummyDataB[i]]++;
            }

            //小計を計算する。
            DescriptiveStatistics.CalculateSubTotal(ref contingencyTable);

            //合計はデータ数に等しい。
            contingencyTable[contingencyTable.GetLength(0) - 1, contingencyTable.GetLength(1) - 1] = (uint)data_A.Length;

            return contingencyTable;
        }

    }
}
