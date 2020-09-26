using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class NormalDistributionPolar : IRandomNumber
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
        {
            UpdateSeed();
            return result;
        }

        /// <summary>
        /// 一様分布
        /// </summary>
        UniformDistribution ud1, ud2;

        /// <summary>
        /// 種
        /// </summary>
        uint seed1, seed2;
        public uint GetSeed1()
        {
            seed1 = ud1.GetSeed();
            return seed1;
        }
        public uint GetSeed2()
        {
            seed2 = ud2.GetSeed();
            return seed2;
        }
        private void UpdateSeed()
        {
            seed1 = ud1.GetSeed();
            seed2 = ud2.GetSeed();
        }

        /// <summary>
        /// 計算回数
        /// </summary>
        bool even;

        /// <summary>
        /// constructor
        /// </summary>
        public NormalDistributionPolar()
        {
            seed1 = (uint)Math.Abs(DateTime.Now.Millisecond);
            seed2 = seed1 + 1;
            ud1 = new UniformDistribution(seed1);
            ud2 = new UniformDistribution(seed2);

            even = true;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="the_seed_1"></param>
        public NormalDistributionPolar(uint the_seed_1, uint the_seed_2)
        {
            seed1 = the_seed_1;
            if (the_seed_1 == the_seed_2 && the_seed_1 == uint.MaxValue)
            { seed2 = 0; }
            else if (the_seed_1 == the_seed_2)
            { seed2 = the_seed_1 + 1; }
            else { seed2 = the_seed_2; }

            ud1 = new UniformDistribution(seed1);
            ud2 = new UniformDistribution(seed2);

            even = true;
        }

        /// <summary>
        /// 種を設定する
        /// </summary>
        /// <param name="the_seed_1"></param>
        public void SetSeed(uint the_seed_1, uint the_seed_2)
        {
            seed1 = the_seed_1;
            if (the_seed_1 == the_seed_2 && the_seed_1 == uint.MaxValue)
            { seed2 = 0; }
            else if (the_seed_1 == the_seed_2)
            { seed2 = the_seed_1 + 1; }
            else { seed2 = the_seed_2; }

            ud1 = new UniformDistribution(seed1);
            ud2 = new UniformDistribution(seed2);
        }

        /// <summary>
        /// 乱数を生成する
        /// 平均値 0
        /// 標準偏差 1
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
        retry_point:

            double u1 = ud1.NextDouble();
            double u2 = ud2.NextDouble();

            double v1 = 2 * u1 - 1;
            double v2 = 2 * u2 - 1;
            double v = v1 * v1 + v2 * v2;

            if (v <= 0 || 1 <= v)
            {
                goto retry_point;
            }

            double w = Math.Sqrt(-2 * Math.Log(v) / v);

            double y1 = v1 * w;
            double y2 = v2 * w;

            if (even)
            {
                result = y1;
                even = false;
            }
            else
            {
                result = y2;
                even = true;
            }
            return result;
        }

        /// <summary>
        /// 乱数を生成する
        /// 平均値 average
        /// 標準偏差 std
        /// </summary>
        /// <param name="average"></param>
        /// <param name="std"></param>
        /// <returns></returns>
        public double NextDouble(double average, double std)
        {
            result = NextDouble() * Math.Abs(std) + average;
            return result;
        }

    }


}
