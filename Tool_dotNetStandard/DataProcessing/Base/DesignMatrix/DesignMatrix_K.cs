using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_dotNetStandard.DataProcessing.Base
{
    public partial class DesignMatrix
    {

        /// <summary>
        /// k-分割交差検証
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <param name="kFold"></param>
        /// <param name="ordinalNumber"></param>
        /// <param name="test_data_design_matrix"></param>
        /// <param name="training_data_design_matrix"></param>
        public static void Prepare_k_Fold_Cross_Validation
            (double[,] designMatrix, int kFold, int ordinalNumber, ref double[,] test_data_design_matrix, ref double[,] training_data_design_matrix)
        {

            int k_fold_modified = Math.Min(Math.Max(kFold, 2), designMatrix.GetLength(0));
            int ordinal_number_modified = Math.Min(Math.Max(ordinalNumber, 0), k_fold_modified - 1);
            int groupQuantity = designMatrix.GetLength(0) / k_fold_modified;


            int initial_group_k = ordinal_number_modified * groupQuantity;
            int end_gropu_k = Math.Min((ordinal_number_modified + 1) * groupQuantity - 1, designMatrix.GetLength(0) - 1);
            groupQuantity = end_gropu_k - initial_group_k + 1;


            training_data_design_matrix = new double[designMatrix.GetLength(0) - groupQuantity, designMatrix.GetLength(1)];
            test_data_design_matrix = new double[groupQuantity, designMatrix.GetLength(1)];


            for (int j = 0; j < initial_group_k; j++)
            {
                for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                {
                    training_data_design_matrix[j, k] = designMatrix[j, k];
                }
            }
            for (int j = 0; j < test_data_design_matrix.GetLength(0); j++)
            {
                for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                {
                    test_data_design_matrix[j, k] = designMatrix[j + initial_group_k, k];
                }
            }
            for (int j = end_gropu_k + 1; j < designMatrix.GetLength(0); j++)
            {
                for (int k = 0; k < training_data_design_matrix.GetLength(1); k++)
                {
                    training_data_design_matrix[j - groupQuantity, k] = designMatrix[j, k];
                }
            }
        }

    }

}
