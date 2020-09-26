using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class UniformDistribution : IRandomNumber
    {

        /// <summary>
        /// 計算結果
        /// </summary>
        double result;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public double Result()
        { return result; }


        /// <summary>
        /// 種
        /// </summary>
        uint seed, X, Y, Z, W, T;
        public uint GetSeed() { return seed; }

        /// <summary>
        /// 計算回数
        /// </summary>
        bool[] counterArray;
        const uint counterDimensions = 19937;

        const double divisor = uint.MaxValue;

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

            counterArray = new bool[counterDimensions];

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

            counterArray = new bool[counterDimensions];

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

            counterArray = new bool[counterDimensions];
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

            result = numerator / divisor;

            CountUp();

            return result;
        }

        /// <summary>
        /// 乱数を生成する
        /// 値域  :[ min , max ]
        /// </summary>
        /// <returns></returns>
        public double NextDouble(double max, double min)
        {
            result = min + (max - min) * NextDouble();
            return result;
        }



        /// <summary>
        /// メルセンヌツイスターの周期2^19937-1 回毎に種をリセットする
        /// </summary>
        void CountUp()
        {
            uint back = 0;
            for (uint i = 0; i < counterDimensions; i++)
            {
                if (!counterArray[counterDimensions - 1 - i])
                {
                    back = i;
                    break;
                }
            }

            for (int i = 0; i < counterDimensions - back; i++)
            {
                if (!counterArray[i])
                {
                    counterArray[i] = true;
                    return;
                }
                else
                {
                    counterArray[i] = false;
                    continue;
                }
            }

            if (counterArray[counterDimensions - 1])
            {
                if (counterArray.All(b => b == true))
                {
                    if (seed == uint.MaxValue) { seed = 0; }
                    else { seed++; }
                    SetSeed(seed);
                }
            }
        }

    }

}
