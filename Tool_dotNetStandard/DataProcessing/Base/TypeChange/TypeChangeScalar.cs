﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class TypeChange
    {
        /// <summary>
        /// Change string to int
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int String_to_Int(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Change string to double
        /// </summary>random
        /// <param name="input"></param>
        /// <returns></returns>
        public static double String_to_Double(string input)
        {
            try
            {
                return double.Parse(input);
            }
            catch
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Change string to byte
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte String_to_Byte(string input)
        {
            try
            {
                return byte.Parse(input);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Change int to string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Number_to_String(int input)
        {
            return input.ToString();
        }

        /// <summary>
        /// Change double to string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Number_to_String(double input)
        {
            return input.ToString("G12");
        }

        /// <summary>
        /// Change byte to string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Number_to_String(byte input)
        {
            return input.ToString();
        }

    }

}
