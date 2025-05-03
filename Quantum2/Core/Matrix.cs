using System;
using System.Numerics;

namespace Quantum2.Core
{
    public class Matrix
    {
        private int _m;
        private int _n;

        private Complex[,] _matrix;

        public int M
        {
            get
            {
                return _m;
            }
        }

        public int N
        {
            get
            {
                return _n;
            }
        }

        public Matrix(int m, int n)
        {
            _m = m;
            _n = n;

            _matrix = new Complex[m, n];

            for(int y = 0; y < m; y++)
            {
                for(int x = 0; x < n; x++)
                {
                    _matrix[y, x] = Complex.Zero;
                }
            }
        }

        public Matrix(Matrix matrix)
        {
            _m = matrix._m;
            _n = matrix._n;

            _matrix = new Complex[_m, _n];

            for(int y = 0; y < _m;y++)
            {
                for(int x = 0; x < _n; x++)
                {
                    _matrix[y, x] = matrix._matrix[y, x];
                }
            }
        }

        public Matrix(Complex[,] mass)
        {
            _m = mass.GetLength(0);
            _n = mass.GetLength(1);

            _matrix = mass;
        }

        public Complex[] GetCM(int n)
        {
            Complex[] mass = new Complex[_m];

            for(int i = 0; i < _m;i++)
            {
                mass[i] = _matrix[i, n];
            }

            return mass;
        }

        public void Replace(Matrix matrix)
        {
            _m = matrix._m;
            _n = matrix._n;

            _matrix = new Complex[matrix.M, matrix.N];

            for(int i = 0; i < _m;i++)
            {
                for(int j = 0; j < _n;j++)
                {
                    _matrix[i, j] = matrix._matrix[i, j];
                }
            }
        }

        public Complex Get(int y, int x)
        {
            return _matrix[y, x];
        }

        public static Matrix GetI(int N)
        {
            if (N == 0)
                N = 1;

            Matrix matrix = new Matrix(N, N);

            for(int i = 0; i < matrix._m; i++)
            {
                matrix._matrix[i, i] = 1;
            }

            return matrix;
        }

        public void Set(int y, int x, Complex value)
        {
            _matrix[y, x] = value;
        }

        public static Matrix operator+(Matrix matrix0, Matrix matrix1)
        {
            Matrix resultMatrix = new Matrix(matrix0._m, matrix0._n);

            for(int y = 0; y < resultMatrix._m; y++)
            {
                for(int x = 0; x < resultMatrix._n;x++)
                {
                    resultMatrix._matrix[y, x] = matrix0._matrix[y, x] + matrix1._matrix[y, x];
                }
            }

            return resultMatrix;
        }

        public static Matrix operator -(Matrix matrix0, Matrix matrix1)
        {
            Matrix resultMatrix = new Matrix(matrix0._m, matrix0._n);

            for (int y = 0; y < resultMatrix._m; y++)
            {
                for (int x = 0; x < resultMatrix._n; x++)
                {
                    resultMatrix._matrix[y, x] = matrix0._matrix[y, x] - matrix1._matrix[y, x];
                }
            }

            return resultMatrix;
        }

        public static Matrix operator*(Matrix matrix0, Matrix matrix1)
        {

            if (matrix1._n == 1)
            {
               // Console.WriteLine(matrix0._n);
                Matrix matrixResult1 = new Matrix(matrix0._m, 1);

                for (int i = 0; i < matrixResult1._m; i++)
                {
                    Complex value = Complex.Zero;

                  //  Console.WriteLine("GHJ");

                    for (int j = 0; j < matrix0._n; j++)
                    {
                        value += matrix0.Get(i, j) * matrix1.Get(j, 0);
                        //Console.WriteLine(matrix0.Get(i, j));
                    }

                    

                    matrixResult1.Set(i, 0, value);

                }

                return matrixResult1;
            }

            if (matrix0._m != matrix1._n)
            {
                throw new Exception("The matrix multiplication operation is defined only for such matrices when m of the first matrix is equal to n of the second matrix.");
            }
            

            Matrix matrixResult = new Matrix(matrix0._m, matrix1._n);

            for(int y = 0; y < matrixResult._m; y++)
            {
                for(int x = 0; x < matrixResult._n; x++)
                {
                    for(int k = 0; k < matrixResult._m;k++)
                    {
                        matrixResult._matrix[y, x] += matrix0._matrix[y, k] * matrix1._matrix[k, x];
                    }
                    
                }
            }

            return matrixResult;
        }

        public static Matrix TensorMul(Matrix matrix0, Matrix matrix1)
        {
            Matrix matrixResult = new Matrix(matrix0._m * matrix1._m, matrix0._n * matrix1._n);

            for(int y = 0; y < matrixResult._m;y++)
            {
                for(int x = 0; x < matrixResult._n;x++)
                {
                    matrixResult._matrix[y, x] = matrix0._matrix[y / matrix1._m, x / matrix1._n] * matrix1._matrix[y % matrix1._m, x % matrix1._n] ;
                }
            }

            return matrixResult;
        }

        public override string ToString()
        {
            string result = "";

            for(int y = 0; y < _m; y++)
            {
                for(int x = 0; x < _n; x++)
                {
                    result += _matrix[y, x].ToString();

                    if(x != (_n - 1))
                    {
                        result += ",";
                    }
                    else
                    {
                        result += Environment.NewLine;
                    }
                }
            }

            return result;
        }
    }
}
