using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Matrix
    {
        Random rnd = new Random();
        private int n;
        private int[,] matrix;

        public Matrix(int n)
        {
            this.n = n;
            matrix = new int[this.n,this.n];
            for(int i = 0; i < this.n; i++)
            {
                for(int j = 0; j < this.n; j++)
                {
                    matrix[i,j] = rnd.Next(0,100);
                }
            }
        }


        public void PrintMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
