using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class UniformDistribution : IRandomNumber
    {

        /// <summary>
        /// 計算結果
        /// </summary>
        double result_double;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public double ResultDouble()
        { return result_double; }


        /// <summary>
        /// 種
        /// </summary>
        uint seed, X, Y, Z, W, T;
        public uint Get_Seed() { return seed; }

        /// <summary>
        /// 計算回数
        /// </summary>
        bool[] counter_array;
        const uint counter_dimension_max = 19937;


        const double denominator_double = uint.MaxValue;

        /// <summary>
        /// constructor
        /// </summary>
        public UniformDistribution()
        {
            seed = 100 * (uint)Math.Abs(DateTime.Now.Millisecond);
            X = 123456789;
            Y = (UInt32)(seed >> 32) & 0xFFFFFFFF;
            Z = (UInt32)(seed & 0xFFFFFFFF);
            W = X ^ Z;

            counter_array = new bool[counter_dimension_max];

        }

        /// <summary>
        /// constructor
        /// </summary>
        public UniformDistribution(uint the_seed)
        {
            seed = the_seed;
            X = 123456789;
            Y = (UInt32)(seed >> 32) & 0xFFFFFFFF;
            Z = (UInt32)(seed & 0xFFFFFFFF);
            W = X ^ Z;

            counter_array = new bool[counter_dimension_max];

        }

        /// <summary>
        /// 種を設定する
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        public void SetSeed(uint the_seed)
        {
            seed = (uint)Math.Abs(the_seed);
            X = 123456789;
            Y = (UInt32)(seed >> 32) & 0xFFFFFFFF;
            Z = (UInt32)(seed & 0xFFFFFFFF);
            W = X ^ Z;

            counter_array = new bool[counter_dimension_max];
        }

        /// <summary>
        /// 乱数を生成する
        /// 値域  :[ 0 , 1 ]
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
            T = (X ^ (X << 11));
            X = Y;
            Y = Z;
            Z = W;
            W = (W = (W ^ (W >> 19)) ^ (T ^ (T >> 8)));

            double numerator = W;

            result_double = numerator / denominator_double;
            //result /= uint.MaxValue;

            CountUp();

            return result_double;
        }

        /// <summary>
        /// 乱数を生成する
        /// 値域  :[ min , max ]
        /// </summary>
        /// <returns></returns>
        public double NextDouble(double max, double min)
        {
            result_double = min + (max - min) * NextDouble();
            return result_double;
        }


        /// <summary>
        /// メルセンヌツイスターの周期2^19937-1 回毎に種をリセットする
        void CountUp()
        {

            uint back = 0;
            for (uint j = 0; j < counter_dimension_max; j++)
            {
                if (!counter_array[counter_dimension_max - 1 - j])
                {
                    back = j;
                    break;
                }
            }

            for (int j = 0; j < counter_dimension_max - back; j++)
            {
                if (!counter_array[j])
                {
                    counter_array[j] = true;
                    return;
                }
                else
                {
                    counter_array[j] = false;
                    continue;
                }
            }


            bool finish = counter_array[0];
            foreach (bool b in counter_array)
            {
                finish = finish == true && b == true;
            }
            if (finish)
            {
                counter_array = new bool[counter_dimension_max];

                if (seed == uint.MaxValue) { seed = 0; }
                else { seed++; }
                SetSeed(seed);
            }
        }

    }

}
