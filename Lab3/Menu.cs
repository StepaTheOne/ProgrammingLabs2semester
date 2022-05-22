using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Menu
    {
        private static Menu _Instance;
        public Menu Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Menu();
                    return _Instance;
                }
                else
                {
                    return null;
                }
            }
        }
        public void ShowMenu()
        {
            Console.Write("Введите размерность матрицы:");
            int n = Convert.ToInt32(Console.ReadLine());
            var matrixA = new SquareMatrix(n);
            matrixA.Create();
            var matrixB = new SquareMatrix(n);
            matrixB.Create();
            var matrixResult = new SquareMatrix();
            Console.WriteLine("Первая матрица:");
            matrixA.PrintMatrix();
            Console.WriteLine();
            Console.WriteLine("Вторая матрица:");
            matrixB.PrintMatrix();

            Console.WriteLine("Опции с матрицей А: ");
            Console.WriteLine("* - умножние на число");
            Console.WriteLine("** - умножение на матрицу");
            Console.WriteLine("");

            string choice = Console.ReadLine();
            switch (choice) 
            {
                case "**":
                    matrixResult = matrixA * matrixB;
                    matrixResult.PrintMatrix();
                    break;
                case "*":
                    Console.WriteLine("Введите число:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    matrixResult = matrixA * num;
                    matrixResult.PrintMatrix();
                    break;
                case "+":

                default:
                    Console.WriteLine("Нет.");
                    break;
            }

        }
    }
}
