using System;
using System.Collections.Generic;
using System.Text;

using Tool_dotNetStandard.DataProcessing.Base;

namespace Tool_dotNetStandard.DataProcessing.MachineLerning.SupportVector
{
    public partial class SupportVectorMachine
    {


        /// <summary>
        /// 計画行列の識別を行う
        /// </summary>
        /// <param name="labelY"></param>
        /// <param name="design_Matrix_without_Constant"></param>
        /// <param name="iKernel"></param>
        /// <param name="variance_Covariance_Matrix"></param>
        /// <param name="CoefficientA"></param>
        /// <param name="design_Matrix_for_Classification"></param>
        /// <returns></returns>
        public static double[,] Classify_Design_Matrix(double[,] labelY, double[,] design_Matrix_without_Constant, IKernel iKernel, double[,] CoefficientA, double[,] design_Matrix_for_Classification)
        {
            double[,] classified = new double[design_Matrix_for_Classification.GetLength(0), 1];

            //カーネルのセット
            iKernel.SetDesignMatrix(design_Matrix_without_Constant);
            //iKernel.Set_Variance_Covariance_Matrix(DesignMatrix.Variance_Covariance_Matrix(design_Matrix_without_Constant));


            //カーネル用の行列
            double[,] kernelMatrix = new double[design_Matrix_without_Constant.GetLength(0), 1];

            //識別したい計画行列を1行ずつ計算する
            double[,] rowVector;
            for (uint n = 0; n < classified.GetLength(0); n++)
            {
                rowVector = Matrix.Row(design_Matrix_for_Classification, n);
                //カーネルを計算する
                double[,] r_j = new double[1, 1];
                for (uint j = 0; j < design_Matrix_without_Constant.GetLength(0); j++)
                {
                    r_j = Matrix.Row(design_Matrix_without_Constant, j);
                    kernelMatrix[j, 0] = iKernel.Calculate(rowVector, r_j);
                }

                //予測値の計算
                //予測値の符号 = Σ( for j ) 教師ラベル[Y]j * 係数[A]j * カーネル K( x , [X]j )
                double[,] hadamard = Matrix.HadamardMultiply(labelY, CoefficientA);
                hadamard = Matrix.HadamardMultiply(hadamard, kernelMatrix);


                //Σ( for j )
                double sum = 0;
                foreach (double h in hadamard)
                {
                    sum += h;
                }

                classified[n, 0] = sum;
            }

            return classified;
        }

    }



}
