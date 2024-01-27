using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class MatrixMultiplication
    {
        #region YOUR CODE IS HERE
        
        //Your Code is Here:
        //==================
        /// <summary>
        /// Multiply 2 square matrices in an efficient way [Strassen's Method]
        /// </summary>
        /// <param name="M1">First square matrix</param>
        /// <param name="M2">Second square matrix</param>
        /// <param name="N">Dimension (power of 2)</param>
        /// <returns>Resulting square matrix</returns>
        static public int[,] MatrixMultiply(int[,] M1, int[,] M2, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            int[,] C =new int[N,N];
            
            if (N <= 32)
            {
                return Naive(M1, M2);
            }
            else
            {
                int Half_Size = N / 2;

                int[,] a00 = new int[Half_Size, Half_Size];
                int[,] a01 = new int[Half_Size, Half_Size];
                int[,] a10 = new int[Half_Size, Half_Size];
                int[,] a11 = new int[Half_Size, Half_Size];
                int[,] b00 = new int[Half_Size, Half_Size];
                int[,] b01 = new int[Half_Size, Half_Size];
                int[,] b10 = new int[Half_Size, Half_Size];
                int[,] b11 = new int[Half_Size, Half_Size];

                for (int i = 0; i < Half_Size; i++)
                {
                    for (int j = 0; j < Half_Size; j++)
                    {
                        a00[i,j] = M1[i,j];
                        a01[i,j] = M1[i,j + Half_Size];
                        a10[i,j] = M1[Half_Size + i,j];
                        a11[i,j] = M1[i + Half_Size,j + Half_Size];
                        b00[i,j] = M2[i,j];
                        b01[i,j] = M2[i,j + Half_Size];
                        b10[i,j] = M2[Half_Size + i,j];
                        b11[i,j] = M2[i + Half_Size,j + Half_Size];
                    }
                }

                int[,] p = MatrixMultiply(a00, MatrixADD(b01, b11, Half_Size, -1),N/2);
                int[,] q = MatrixMultiply(MatrixADD(a00, a01, Half_Size), b11,N/2);
                int[,] r = MatrixMultiply(MatrixADD(a10, a11, Half_Size), b00,N/2);
                int[,] s = MatrixMultiply(a11, MatrixADD(b10, b00, Half_Size, -1),N/2);
                int[,] t = MatrixMultiply(MatrixADD(a00, a11, Half_Size), MatrixADD(b00, b11, Half_Size),N/2);
                int[,] u = MatrixMultiply(MatrixADD(a01, a11, Half_Size, -1), MatrixADD(b10, b11, Half_Size),N/2);
                int[,] v = MatrixMultiply(MatrixADD(a00, a10, Half_Size, -1), MatrixADD(b00, b01, Half_Size),N/2);

                int[,] result_matrix_00 = MatrixADD(MatrixADD(MatrixADD(t, s, Half_Size), u, Half_Size), q, Half_Size, -1);
                int[,] result_matrix_01 = MatrixADD(p, q, Half_Size);
                int[,] result_matrix_10 = MatrixADD(r, s, Half_Size);
                int[,] result_matrix_11 = MatrixADD(MatrixADD(MatrixADD(t, p, Half_Size), r, Half_Size, -1), v, Half_Size, -1);

                for (int i = 0; i < Half_Size; i++)
                {
                    for (int j = 0; j < Half_Size; j++)
                    {
                        C[i,j] = result_matrix_00[i,j];
                        C[i,j + Half_Size] = result_matrix_01[i,j];
                        C[Half_Size + i,j] = result_matrix_10[i,j];
                        C[i + Half_Size,j + Half_Size] = result_matrix_11[i,j];
                    }
                }
            }
            return C;
        }
        static public int[,] MatrixADD(int[,] first, int[,] second, int N, int sign = 1)
        {
            int[,] result = new int[N,N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    result[i,j] = first[i,j] + (sign * second[i,j]);
            return result;
        }

        static int[,] Naive(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int m = B.GetLength(1);
            int[,] C = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return C;
        }
        #endregion
    }
}
