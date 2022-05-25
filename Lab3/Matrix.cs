using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class SquareMatrix
    {
        Random rnd = new Random();
        public int[,] Matrix { get; set; }
        public int Size { get; set; }
        public SquareMatrix() 
        {
            Size = rnd.Next(2, 4);
            Matrix = new int[Size,Size];
            Create(); 
        } //че сделал не уверен если ч.

        public SquareMatrix(int n)
        {
            Size = n;
            Matrix = new int[Size,Size];
        }

        public SquareMatrix(int n, int[,] matrix)
        {
            Size = n;
            Matrix = new int[Size, Size];
            Matrix = matrix;
        }

        public int this[int iRaw, int iCol]
        {
            get
            {
                return Matrix[iRaw, iCol];
            }
            set
            {
                Matrix[iRaw, iCol] = value;
            }
        }

        public void Create()
        {
            for (int iRow = 0; iRow < Size; ++iRow)
            {
                for (int iCol = 0; iCol < Size; ++iCol)
                {
                    Matrix[iRow, iCol] = rnd.Next(0, 10);
                }
            }
        }


        public void PrintMatrix()
        {
            for (int iRow = 0; iRow < Size; ++iRow)
            {
                for (int iCol = 0; iCol < Size; ++iCol)
                {
                    Console.Write(Matrix[iRow, iCol] + " ");
                }
                Console.WriteLine();
            }
        }
        public void Info()
        {
            Console.WriteLine($"Определитель: {this.Determine()}");
            Console.WriteLine($"Сумма элементов: {this.SumOfElem()}");
            Console.WriteLine($"Хэш код: {this.GetHashCode()}");
            Console.WriteLine($"To string: {this.ToString()}");
        }

        public int SumOfElem()
        {
            int sum = 0;
            for (int iRow = 0; iRow < Size; ++iRow)
            {
                for (int iCol = 0;iCol < Size; ++iCol)
                {
                    sum+=Matrix[iRow, iCol];
                }
            }
            return sum;
        }
        public SquareMatrix Transpose()
        {
            var result = new SquareMatrix(this.Size);
            for (int iRow = 0; iRow < this.Size; ++iRow)
            {
                for(int iCol = 0;iCol < this.Size ; ++iCol)
                {
                    result.Matrix[iRow, iCol] = this.Matrix[iCol, iRow];
                }
            }
            return result;
        }
        //поищем определитель матрицы заданных размеров? засекаем строки кода.
        private SquareMatrix CreateMatrixForDetermine(int Row,int Col)
        {
            var result = new SquareMatrix(this.Size-1);
            for(int iRow = 0;iRow < this.Size-1; ++iRow)
            {
                for(int iCol = 0;iCol < this.Size-1; ++iCol)
                {
                    if(iRow < Row)
                    {
                        result.Matrix[iRow, iCol] = this.Matrix[iRow, iCol];
                    }
                    else
                    {
                        result.Matrix[iRow, iCol] = this.Matrix[iRow+1, iCol];
                    }
                    if(iCol < Col)
                    {
                        result.Matrix[iRow, iCol] = this.Matrix[iRow, iCol];
                    }
                    else
                    {
                        result.Matrix[iRow, iCol] = this.Matrix[iRow, iCol+1];
                    }
                }
            }
            return result;
        }
        public int Determine()
        {
            if (this.Size == 2)
            {
                return this.Matrix[0, 0] * this.Matrix[1, 1] - this.Matrix[0, 1] * this.Matrix[1, 0];
            }
            int result = 0;
            for (var iCol = 0; iCol < this.Size; ++iCol)
            {
                result += (iCol % 2 == 1 ? 1 : -1) * this[1, iCol] *
                    this.CreateMatrixForDetermine(1, iCol).Determine();
            }
            return result;
        }
        //Вау! Сделал вроде. Даже проверять не хочу.
        public override string ToString()
        {
            var result = "";
            for(var iRow = 0; iRow < this.Size; ++iRow)
            {
                result += "(";
                for (var iCol = 0;iCol < this.Size; ++iCol)
                {
                    result += $"{this.Matrix[iRow,iCol]}";
                    if (iCol < this.Size - 1)
                        result += ", ";
                }
                result += ")\n";
            }
            return result;
        }
        public int CompareTo(object o) {

            if (o is SquareMatrix check) {

                if (check.SumOfElem() > this.SumOfElem()) {

                    return -1;
                }

                if (check.SumOfElem() < this.SumOfElem()) {

                    return 1;
                }

                if (check.SumOfElem() == this.SumOfElem()) {

                    return 0;
                }
            }

            return -2;
        }
        public override bool Equals(object obj)
        {
            if(obj is SquareMatrix check)
            {
                if (this.Size != check.Size)
                    return false;

                for (int iRow = 0; iRow < this.Size; ++iRow)
                {
                    for (int iCol = 0; iCol < this.Size; ++iCol)
                    {
                        if (this.Matrix[iRow, iCol] != check.Matrix[iRow, iCol])
                            return false;
                    }
                }

                return true;

            }
            return false;
        }
        public override int GetHashCode()
        {
            return (Int32)this.SumOfElem();
        }
        public static SquareMatrix operator *(SquareMatrix a, SquareMatrix b)
        {
            if (a.Size != b.Size)
                throw new MatrixException("Разный размер.");

            var result = new SquareMatrix(a.Size);
            for (int iRow = 0; iRow < a.Size; ++iRow)
                for (int iCol = 0; iCol < b.Size; ++iCol)
                    for (int RowCol = 0; RowCol < b.Size; ++RowCol)
                        result[iRow, iCol] += a[iRow, RowCol] * b[RowCol, iCol];

            return result;
        }

        public static SquareMatrix operator *(SquareMatrix a, int b)
        {
            var result = new SquareMatrix(a.Size);
            for (int iRow = 0; iRow < a.Size; ++iRow)
            {
                for (int iCol = 0; iCol < a.Size; ++iCol)
                {
                    result[iRow, iCol] = a[iRow, iCol] * b;
                }
            }
            return result;
        }

        public static SquareMatrix operator +(SquareMatrix a, SquareMatrix b)
        {
            if (a.Size != b.Size)
                throw new MatrixException("Разный размер.");
            SquareMatrix result = new SquareMatrix(a.Size);
            for(int iRow = 0; iRow < a.Size; ++iRow)
            {
                for(int iCol = 0; iCol < a.Size; ++iCol)
                {
                    result.Matrix[iRow, iCol] = a[iRow, iCol] + b[iRow,iCol];
                }
            }

            return result;
        }
        public static SquareMatrix operator -(SquareMatrix a, SquareMatrix b)
        {
            if (a.Size != b.Size)
                throw new MatrixException("Разный размер.");
            SquareMatrix result = new SquareMatrix(a.Size);
            for (int iRow = 0; iRow < a.Size; ++iRow)
            {
                for (int iCol = 0; iCol < a.Size; ++iCol)
                {
                    result.Matrix[iRow, iCol] = a[iRow, iCol] - b[iRow, iCol];
                }
            }

            return result;
        }
        public static bool operator >(SquareMatrix a, SquareMatrix b)
        {
            return a.SumOfElem() > b.SumOfElem();
        }
        public static bool operator <(SquareMatrix a, SquareMatrix b)
        {
            return a.SumOfElem() < b.SumOfElem();
        }
        public static bool operator >=(SquareMatrix a, SquareMatrix b)
        {
            return a.SumOfElem() >= b.SumOfElem();
        }
        public static bool operator <=(SquareMatrix a, SquareMatrix b)
        {
            return a.SumOfElem() <= b.SumOfElem();
        }
        public static bool operator ==(SquareMatrix a, SquareMatrix b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(SquareMatrix a, SquareMatrix b)
        {
            if (a == b)
                return false;
            else
                return true;
        }
        public static bool operator true(SquareMatrix a)
        {
            return a.SumOfElem() != 0;
        }
        public static bool operator false(SquareMatrix a)
        {
            return a.SumOfElem() == 0;
        }
    }
}
