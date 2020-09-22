using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public class PowerOf10IKernel : IKernel
    {


        bool set;
        double[,] inverse_Variance_Covariance_Matrix;
        double coefficient;


        public void SetDesignMatrix(double[,] designMatrix)
        {
            set = true;
            double[,] varianceCovariance = DesignMatrix.Variance_Covariance_Matrix(designMatrix);
            inverse_Variance_Covariance_Matrix = Matrix.Inverse(varianceCovariance);

            double determinant = Math.Sqrt(Math.Abs(Matrix.Determinant(varianceCovariance)));
            coefficient = Math.Pow(2 * Math.PI, varianceCovariance.GetLength(1) / 2.0) * determinant;
        }


        public double Calculate(double[,] row_Vector_1, double[,] row_Vector_2)
        {
            double[,] delta_row = Matrix.Subtract(row_Vector_1, row_Vector_2);

            if (set)
            {
                double[,] delta_column = Matrix.Transpose(delta_row);

                double[,] product = Matrix.Multiply(delta_row, inverse_Variance_Covariance_Matrix);
                product = Matrix.Multiply(product, delta_column);

                double norm = Math.Abs(product[0, 0]);

                if (norm <= 1) { return Math.Pow(1 - norm, 10.0); }
                else { return 0.0; }

            }
            else
            {
                double norm = Matrix.L2Norm(delta_row);

                if (norm <= 1) { return Math.Pow(1 - norm, 10.0); }
                else { return 0.0; }
            }
        }

    }

}
