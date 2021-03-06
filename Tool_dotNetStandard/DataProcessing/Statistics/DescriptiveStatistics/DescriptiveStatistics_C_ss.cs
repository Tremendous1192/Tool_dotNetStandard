﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Statistics
{
    public partial class DescriptiveStatistics
    {
        /// <summary>
        /// 分割表を作成する。
        /// </summary>
        /// <param name="labels_A"></param>
        /// <param name="data_A"></param>
        /// <param name="labels_B"></param>
        /// <param name="data_B"></param>
        /// <returns></returns>
        public static uint[,] Enumerate_ContingencyTable
            (ref string[] labels_A, string[] data_A,
            ref string[] labels_B, string[] data_B)
        {
            //データ数が等しくないと例外を返す。
            if (data_A.GetLength(0) != data_B.GetLength(0))
            {
                throw new FormatException("Align length of " + nameof(data_A) + "(" + data_A.GetLength(0) + ")" + " with that of " + nameof(data_B) + "(" + data_B.GetLength(0) + ")");
            }

            //水準名の被りを取り除く。
            DescriptiveStatistics.TrimOverlap(ref labels_A);
            DescriptiveStatistics.TrimOverlap(ref labels_B);


            //ダミー変数に変換する。
            uint[] dummyDataA = DescriptiveStatistics.Set_Dummy_Variable(labels_A, data_A);
            uint[] dummyDataB = DescriptiveStatistics.Set_Dummy_Variable(labels_B, data_B);


            //計数する。
            uint[,] contingencyTable = new uint[labels_A.Length + 1, labels_B.Length + 1];
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
