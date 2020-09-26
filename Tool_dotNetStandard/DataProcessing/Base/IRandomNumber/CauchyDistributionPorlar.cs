using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class CauchyDistributionPorlar : IRandomNumber
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
        public uint GetSeed1() { return seed1; }
        public uint GetSeed2() { return seed2; }
        private void UpdateSeed()
        {
            seed1 = ud1.GetSeed();
            seed2 = ud2.GetSeed();
        }

        /// <summary>
        /// constructor
        /// </summary>
        public CauchyDistributionPorlar()
        {
            seed1 = (uint)Math.Abs(DateTime.Now.Millisecond);
            seed2 = seed1 + 1;
            ud1 = new UniformDistribution(seed1);
            ud2 = new UniformDistribution(seed2);

        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="the_seed_1"></param>
        public CauchyDistributionPorlar(uint the_seed_1, uint the_seed_2)
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
        /// 位置母数(location parameter) 0
        /// 尺度母数(scale parameter) 1
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
        retry_point:

            double u1 = ud1.NextDouble();
            double u2 = ud2.NextDouble();
            if (u2 == 0.5) { goto retry_point; }

            double v1 = 2 * u1 - 1;
            double v2 = 2 * u2 - 1;
            double w = v1 * v1 + v2 * v2;

            if (1 <= w) { goto retry_point; }

            double y = v1 / v2;

            result = y;

            return result;
        }

        /// <summary>
        /// 乱数を生成する
        /// 位置母数(location parameter) location
        /// 尺度母数(scale parameter) scale
        /// </summary>
        /// <returns></returns>
        public double NextDouble(double location, double scale)
        {
            result = location + Math.Abs(scale) * NextDouble();
            return result;
        }

    }

}
