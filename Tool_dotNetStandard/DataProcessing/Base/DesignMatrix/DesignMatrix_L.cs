using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class DesignMatrix
    {

        /// <summary>
        /// leave-one-out 交差検証
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <param name="ordinalNumber"></param>
        /// <param name="test_data_row_vector"></param>
        /// <param name="training_data_design_matrix"></param>
        public static void Prepare_Leave_one_out_cross_validation
            (double[,] designMatrix, int ordinalNumber, ref double[,] test_data_row_vector, ref double[,] training_data_design_matrix)
        {


            training_data_design_matrix = new double[designMatrix.GetLength(0) - 1, designMatrix.GetLength(1)];
            test_data_row_vector = new double[1, designMatrix.GetLength(1)];


            int ordinal_number_modified = Math.Min(Math.Max(0, ordinalNumber), designMatrix.GetLength(0) - 1);

            for (int j = 0; j < designMatrix.GetLength(0); j++)
            {
                if (j == ordinal_number_modified)
                {
                }
                else if (j < ordinalNumber)
                {
                    for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                    {
                        training_data_design_matrix[j, k] = designMatrix[j, k];
                    }
                }
                else
                {
                    for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                    {
                        training_data_design_matrix[j - 1, k] = designMatrix[j, k];
                    }
                }
            }
            for (int k = 0; k < designMatrix.GetLength(1); k++)
            {
                test_data_row_vector[0, k] = designMatrix[ordinal_number_modified, k];
            }
        }

    }

}
