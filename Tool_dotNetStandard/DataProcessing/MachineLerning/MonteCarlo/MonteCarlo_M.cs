using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;


namespace Tool_dotNetStandard.DataProcessing.MachineLerning
{
    public partial class MonteCarlo
    {


        public static void MetropolisHastings
 (ref double result, ref double numerator, ref double denominator
      , ref double partition_function
      , uint calculation_count_epoch
      , double[] initial_x, ref double[] final_x
      , IAction iaction, double[] step_half_width, uint[] seeds_for_step
      , uint seed_for_judge
      , IScalarFunction iscalar
    )
        {
            //ジャンプの幅の乱数の種の次元をそろえる
            if (step_half_width.Length != seeds_for_step.Length)
            {
                throw new FormatException("Length of " + nameof(step_half_width) + "(" + step_half_width.Length + ")"
                    + " with that of " + nameof(seeds_for_step) + "(" + seeds_for_step.Length + ")");
            }
            //初期位置と乱数の種の次元をそろえる
            if (initial_x.Length != seeds_for_step.Length)
            {
                throw new FormatException("Length of " + nameof(initial_x) + "(" + initial_x.Length + ")"
                    + " with that of " + nameof(seeds_for_step) + "(" + seeds_for_step.Length + ")");
            }

            //ジャンプの幅を正の数にしておく
            double[] abs_step_half_width = new double[step_half_width.Length];
            for (int j = 0; j < step_half_width.Length; j++)
            {
                abs_step_half_width[j] = Math.Abs(step_half_width[j]);
            }

            //一様乱数のclassを生成する
            List<UniformDistribution> list_ud = new List<UniformDistribution>();
            for (int j = 0; j < step_half_width.Length; j++)
            {
                list_ud.Add(new UniformDistribution(seeds_for_step[j]));
            }
            UniformDistribution judge = new UniformDistribution(seed_for_judge);


            //初期設定を行う
            double[] xs = new double[step_half_width.Length];
            double[] xs_candidate = new double[step_half_width.Length];
            for (int k = 0; k < step_half_width.Length; k++)
            {
                xs[k] = initial_x[k];
                xs_candidate[k] = xs[k];
            }

            double action = 0;
            double action_candidate = 0;
            action = iaction.Calculate_f_u(xs);
            action_candidate = action;


            //計算を行う
            for (int j = 0; j < calculation_count_epoch; j++)
            {
                //新しいxの候補を計算する。
                for (int k = 0; k < step_half_width.Length; k++)
                {
                    //xの値を1次元だけ動かす
                    xs_candidate[k] = xs[k] + list_ud[k].NextDouble(abs_step_half_width[k], -abs_step_half_width[k]);
                }
                action_candidate = iaction.Calculate_f_u(xs_candidate);


                //更新できる場合
                if (judge.NextDouble() < Math.Exp(action - action_candidate))
                {
                    //被積分関数の値を足す
                    numerator += iscalar.Calculate_f_u(xs_candidate);

                    //分配関数に確率値を加える。
                    partition_function += Math.Exp(-action_candidate);

                    for (int k = 0; k < step_half_width.Length; k++)
                    {
                        //xの値を更新する。
                        xs[k] = xs_candidate[k];
                    }

                    //作用を更新する。
                    action = action_candidate;
                }
                else
                {
                }

                denominator++;

            }

            result = numerator / denominator;

            for (int j = 0; j < initial_x.Length; j++)
            {
                final_x[j] = xs[j];
            }

        }




    }
}
