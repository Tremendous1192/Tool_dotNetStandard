using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class HalfNormalDistributionPolar : IRandomNumber
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
        /// 計算回数
        /// </summary>
        bool even;

        /// <summary>
        /// constructor
        /// </summary>
        public HalfNormalDistributionPolar()
        {
            seed_1 = (uint)Math.Abs(DateTime.Now.Millisecond);
            seed_2 = seed_1 + 1;
            ud1 = new UniformDistribution(seed_1);
            ud2 = new UniformDistribution(seed_2);

            even = true;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="the_seed"></param>
        public HalfNormalDistributionPolar(uint the_seed_1, uint the_seed_2)
        {
            seed_1 = the_seed_1;
            if (the_seed_1 == the_seed_2 && the_seed_1 == uint.MaxValue)
            { seed_2 = 0; }
            else if (the_seed_1 == the_seed_2)
            { seed_2 = the_seed_1 + 1; }
            else { seed_2 = the_seed_2; }

            ud1 = new UniformDistribution(seed_1);
            ud2 = new UniformDistribution(seed_2);

            even = true;
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
        /// 標準偏差 1
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
        retry_point:

            double u1 = ud1.NextDouble();
            double u2 = ud2.NextDouble();

            double v = u1 * u1 + u2 * u2;

            if (v <= 0 || 1 <= v)
            {
                goto retry_point;
            }

            double w = Math.Sqrt(-2 * Math.Log(v) / v);

            double y1 = u1 * w;
            double y2 = u2 * w;

            if (even)
            {
                resultDouble = y1;
                even = false;
            }
            else
            {
                resultDouble = y2;
                even = true;
            }
            return resultDouble;
        }

        /// <summary>
        /// 乱数を生成する
        /// 標準偏差 std
        /// </summary>
        /// <param name="std"></param>
        /// <returns></returns>
        public double NextDouble(double std)
        {
            return NextDouble() * Math.Abs(std);
        }

    }

}
