using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork
{
    /// <summary>
    /// Neural Networkの基底クラス。
    /// 抽象クラスのため、インスタンス生成はできない.
    /// </summary>
    public abstract partial class BaseLayer
    {


        /// <summary>
        /// 入力ベクトル
        /// </summary>
        private double[,] input;
        /// <summary>
        /// 入力ベクトル
        /// </summary>
        /// <returns></returns>
        public double[,] Input
        {
            protected set { input = value; }
            get { return input; }
        }
        /// <summary>
        /// 入力ベクトルの転置行列
        /// </summary>
        /// <returns></returns>
        public double[,] InputTranspose
        {
            get { return Matrix.Transpose(input); }
        }

        /// <summary>
        /// 行列 W
        /// </summary>
        private double[,] w;
        /// <summary>
        /// 行列 W
        /// </summary>
        /// <returns></returns>
        public double[,] W
        {
            protected set { w = value; }
            get { return w; }
        }
        /// <summary>
        /// 行列 Wの転置行列
        /// </summary>
        /// <returns></returns>
        public double[,] WTranspose
        {
            get { return Matrix.Transpose(w); }
        }


        /// <summary>
        /// バイアスベクトル
        /// </summary>
        private double[,] b;
        /// <summary>
        /// バイアスベクトル
        /// </summary>
        /// <returns></returns>
        public double[,] B
        {
            protected set { b = value; }
            get { return b; }
        }

        /// <summary>
        /// 途中計算
        /// </summary>
        private double[,] wx;
        /// <summary>
        /// 途中計算
        /// </summary>
        public double[,] WX
        {
            protected set { wx = value; }
            get { return wx; }
        }

        /// <summary>
        /// 途中計算
        /// </summary>
        private double[,] wx_plus_b;
        /// <summary>
        /// 途中計算
        /// </summary>
        public double[,] WXplusB
        {
            protected set { wx_plus_b = value; }
            get { return wx_plus_b; }
        }

        /// <summary>
        /// 計算結果
        /// </summary>
        private double[,] f_wx_plus_b;
        /// <summary>
        /// 計算結果
        /// </summary>
        public double[,] fWXplusB
        {
            protected set { f_wx_plus_b = value; }
            get { return f_wx_plus_b; }
        }
        /// <summary>
        /// 計算結果の転置行列
        /// </summary>
        public double[,] fWXplusBTranspose
        {
            get { return Matrix.Transpose(f_wx_plus_b); }
        }


        /// <summary>
        /// 計算結果の導関数
        /// </summary>
        private double[,] f_dash_wx_plus_b;
        /// <summary>
        /// 計算結果の導関数
        /// </summary>
        public double[,] fDashWXplusB
        {
            protected set { f_dash_wx_plus_b = value; }
            get { return f_dash_wx_plus_b; }
        }

        /// <summary>
        /// 誤差逆伝播法の δ。
        /// Bを更新するベクトルでもある。
        /// </summary>
        private double[,] delta;
        /// <summary>
        /// 誤差逆伝播法の δ。
        /// Bを更新するベクトルでもある。
        /// </summary>
        public double[,] Delta
        {
            protected set { delta = value; }
            get { return delta; }
        }

        /// <summary>
        /// Wで微分した目的関数の導関数
        /// </summary>
        private double[,] differentialWithW;
        /// <summary>
        /// Wで微分した目的関数の導関数
        /// </summary>
        public double[,] DifferentialWithW
        {
            protected set { differentialWithW = value; }
            get { return differentialWithW; }
        }

        /// <summary>
        /// 正解データ
        /// </summary>
        private double[,] correctData;
        /// <summary>
        /// 正解データ
        /// </summary>
        public double[,] CorrectData
        {
            protected set { correctData = value; }
            get { return correctData; }
        }

        /// <summary>
        /// ハイパーパラメーター
        /// </summary>
        private double gamma, l1, l2, dropoutRate;
        public double Gamma
        {
            protected set { gamma = value; }
            get { return gamma; }
        }
        public double L1
        {
            protected set { l1 = value; }
            get { return l1; }
        }
        public double L2
        {
            protected set { l2 = value; }
            get { return l2; }
        }
        public double DropoutRate
        {
            protected set { dropoutRate = value; }
            get { return dropoutRate; }
        }


        /// <summary>
        /// 誤差
        /// </summary>
        private double[,] error;
        /// <summary>
        /// 誤差
        /// </summary>
        public double[,] Error
        {
            protected set { this.error = value; }
            get { return error; }
        }

        /// <summary>
        /// 目的関数
        /// </summary>
        private double objectiveFunction;
        /// <summary>
        /// 目的関数
        /// </summary>
        public double ObjectiveFunction
        {
            protected set { this.objectiveFunction = value; }
            get { return objectiveFunction; }
        }


        /// <summary>
        /// 活性化関数
        /// </summary>
        protected IVectorFunction activationFunction;


        /// <summary>
        /// ドロップアウトの確率計算用
        /// </summary>
        protected UniformDistribution ud;
        public uint Seed
        {
            get { return ud.Get_Seed(); }
        }

    }
}
