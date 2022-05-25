using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class CloneMatrix:SquareMatrix,ICloneable
    {
        Random rnd = new Random();
        public CloneMatrix() 
        { 
            Size = rnd.Next(2, 4);
            Matrix = new int[Size, Size];
            Create(); 
        } //че сделал не уверен если ч.

        public CloneMatrix(int n)
        {
            Size = n;
            Matrix = new int[Size, Size];
            Create();
        }

        public CloneMatrix(int n, int[,] matrix)
        {
            Size = n;
            Matrix = new int[Size, Size];
            Matrix = matrix;
        }
        public object Clone()
        {
            var clone = new SquareMatrix(Size);
            clone.Matrix = this.Matrix;

            return clone;
        }
    }
}
