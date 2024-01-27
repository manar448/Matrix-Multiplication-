Description
  Given TWO square matrices of size N×N, implement an efficient algorithm based on Strassen’s
  method to multiply them?
  
NOTE:
  • N is power of 2 (i.e. 2, 4, 8, 16, 32… 2i)
  
Complexity
  The complexity of your algorithm should be less than O(N3)

Function: Implement it!
  static public int[,] MatrixMultiply(int[,] M1, int[,] M2, int N)
  MatrixMultiplication.cs includes this method.

Examples
EX#1 
M1:  1 1
     1 0
M2:  1 1
     1 0
Res: 2 1
     1 1

EX#2
M1:  1 -1 1 -1
     1 -1 1 -1
     1 -1 1 -1
     1 -1 1 -1
M2:  -1 1 -1 1
     -1 1 -1 1
     -1 1 -1 1
     -1 1 -1 1
Res: 0 0 0 0
     0 0 0 0
     0 0 0 0
     0 0 0 0
