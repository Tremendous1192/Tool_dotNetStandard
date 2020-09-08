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
        double resultDouble;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public double ResultDouble()
        {
            UpdateSeed();
            return resultDouble;
        }

        /// <summary>
        /// 一様分布
        /// </summary>
        UniformDistribution ud1, ud2;

        /// <summary>
        /// 種
        /// </summary>
        uint seed_1, seed_2;
        public uint GetSeed1() { return seed_1; }
        public uint GetSeed2() { return seed_2; }
        private void UpdateSeed()
        {
            seed_1 = ud1.Get_Seed();
            seed_2 = ud2.Get_Seed();
        }

        /// <summary>
        /// constructor
        /// </summary>
        public CauchyDistributionPorlar()
        {
            seed_1 = (uint)Math.Abs(DateTime.Now.Millisecond);
            seed_2 = seed_1 + 1;
            ud1 = new UniformDistribution(seed_1);
            ud2 = new UniformDistribution(seed_2);

        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="the_seed_1"></param>
        public CauchyDistributionPorlar(uint the_seed_1, uint the_seed_2)
        {
            seed_1 = the_seed_1;
            if (the_seed_1 == the_seed_2 && the_seed_1 == uint.MaxValue)
            { seed_2 = 0; }
            else if (the_seed_1 == the_seed_2)
            { seed_2 = the_seed_1 + 1; }
            else { seed_2 = the_seed_2; }

            ud1 = new UniformDistribution(seed_1);
            ud2 = new UniformDistribution(seed_2);
        }

        /// <summary>
        /// 種を設定する
        /// </summary>
        /// <param name="the_seed_1"></param>
        public void SetSeed(uint the_seed_1, uint the_seed_2)
        {
            seed_1 = the_seed_1;
            if (the_seed_1 == the_seed_2 && the_seed_1 == uint.MaxValue)
            { seed_2 = 0; }
            else if (the_seed_1 == the_seed_2)
            { seed_2 = the_seed_1 + 1; }
            else { seed_2 = the_seed_2; }

            ud1 = new UniformDistribution(seed_1);
            ud2 = new UniformDistribution(seed_2);
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

            resultDouble = y;

            return resultDouble;
        }

        /// <summary>
        /// 乱数を生成する
        /// 位置母数(location parameter) location
        /// 尺度母数(scale parameter) scale
        /// </summary>
        /// <returns></returns>
        public double NextDouble(double location, double scale)
        {
            resultDouble = location + Math.Abs(scale) * NextDouble();
            return resultDouble;
        }

    }

}
