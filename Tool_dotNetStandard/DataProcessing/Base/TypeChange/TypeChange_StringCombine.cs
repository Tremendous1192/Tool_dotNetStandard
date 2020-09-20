﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class TypeChange
    {

        /// <summary>
        /// ex) Change  {"a","b","c"} to "a,b,c"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Combine_Array_to_string_by_comma(string[] input)
        {
            string result = "";

            for (int i = 0; i < input.GetLength(0) - 1; i++)
            {
                result += input[i] + ",";
            }
            result += input[input.GetLength(0) - 1];
            return result;
        }

        /// <summary>
        /// ex) Change { {"a","b"} ,{"c","d"} } to {"a,b","c,d"} 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] Combine_Array_to_string_by_comma(string[,] input)
        {
            int L0 = input.GetLength(0);
            int L1 = input.GetLength(1);

            string[] result = new string[L0];
            string L = "";

            for (int i = 0; i < L0; i++)
            {
                L = "";
                for (int j = 0; j < L1 - 1; j++)
                {
                    L += input[i, j] + ",";
                }
                L += input[i, L1 - 1];

                result[i] = L;
            }
            return result;
        }

        /// <summary>
        /// ex) Change  {10,20,30} to "10,20,30"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Combine_Array_to_string_by_comma(int[] input)
        {
            string result = "";

            for (int i = 0; i < input.GetLength(0) - 1; i++)
            {
                result += input[i].ToString() + ",";
            }
            result += input[input.GetLength(0) - 1].ToString();
            return result;
        }

        /// <summary>
        /// ex) Change { {10,20} ,{30,40} } to {"10,20","30,40"} 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] Combine_Array_to_string_by_comma(int[,] input)
        {
            int L0 = input.GetLength(0);
            int L1 = input.GetLength(1);

            string[] result = new string[L0];
            string L = "";

            for (int i = 0; i < L0; i++)
            {
                L = "";
                for (int j = 0; j < L1 - 1; j++)
                {
                    L += input[i, j].ToString() + ",";
                }
                L += input[i, L1 - 1].ToString();

                result[i] = L;
            }
            return result;
        }


        /// <summary>
        /// ex) Change  {0.1234567,0.1234564,0.1234} to "0.123457,0.123456,0.1234"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Combine_Array_to_string_by_comma(double[] input)
        {
            string result = "";

            for (int i = 0; i < input.GetLength(0) - 1; i++)
            {
                result += input[i].ToString() + ",";
            }
            result += input[input.Length-1].ToString();
            return result;
        }

        /// <summary>
        /// ex) Change { {0.1234567,0.1234564} ,{0.1234,40} } to {"0.123457,0.123456","0.1234,40"} 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] Combine_Array_to_string_by_comma(double[,] input)
        {
            int L0 = input.GetLength(0);
            int L1 = input.GetLength(1);

            string[] result = new string[L0];
            string L = "";

            for (int i = 0; i < L0; i++)
            {
                L = "";
                for (int j = 0; j < L1 - 1; j++)
                {
                    L += input[i, j].ToString() + ",";
                }
                L += input[i, input.GetLength(1)-1].ToString();

                result[i] = L;
            }
            return result;
        }

    }

}
