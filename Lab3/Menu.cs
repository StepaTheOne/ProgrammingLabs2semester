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

        public CloneMatrix CreateMatrix()
        {
            var check = true;
            Console.WriteLine("Матрица полностью случайная?\n1 - да\n2-нет\n");
            while (check)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return new CloneMatrix();
                    case "2":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Такой опции нет.");
                        break;
                }
                
            }
            check = true;
            int size = 0;

            while (check)
            {
                Console.Write("Введите размерность: ");
                if(!int.TryParse(Console.ReadLine(),out size) || size <= 1)
                {
                        Console.WriteLine("Некорректный ввод.");
                }
                else
                {
                        check = false;
                }
            }
            check = true;
            Console.WriteLine("Элементы рандомные?\n1-Да\n2-нет");
            while (check)
            {
            switch (Console.ReadLine())
            {
                case "1":
                    return new CloneMatrix(size);
                case "2":
                    check = false;
                    break;
                default:
                    Console.WriteLine("Неа.");
                    break;
                }
            }
                check=true;
                var matrix = new int[size,size];
                int elem;
                for(int iRow = 0; iRow < size; ++iRow)
                {
                    for(int iCol = 0; iCol < size; ++iCol)
                    {
                        while (check)
                        {
                            Console.Write($"Ввод элемента[{iRow}][{iCol}]:");
                            if(!int.TryParse(Console.ReadLine(), out elem))
                            {
                                Console.WriteLine("неа....");
                            }
                            else
                            {
                                matrix[iRow,iCol] = elem;
                                check = false;
                            }
                        }
                        check = true;
                    }
                }
                
            return new CloneMatrix(size, matrix);
        }
        public void ShowMenu()
        {

            Console.WriteLine("Создаем первую матрицу: ");
            var matrix1 = CreateMatrix();
            Console.WriteLine("Вторую: ");
            var matrix2 = CreateMatrix();

            Console.Clear();
            matrix1.PrintMatrix();
            Console.WriteLine();
            matrix2.PrintMatrix();



            var check = true;
            while (check)
            {
                Console.Write("Выберите опцию: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        try
                        {
                            var result = (SquareMatrix)matrix1.Clone();
                            result += matrix2;
                            result.PrintMatrix();
                        }
                        catch(MatrixException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case "2":
                        try
                        {
                            var result = (SquareMatrix)matrix1.Clone();
                            result -= matrix2;
                            result.PrintMatrix();
                        }
                        catch (MatrixException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            var result = (SquareMatrix)matrix1.Clone();
                            result *= matrix2;
                            result.PrintMatrix();
                        }
                        catch (MatrixException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Какую: 1 or 2?: ");
                        switch (Console.ReadLine()) 
                        {
                            case "1":
                                var result = matrix1.Transpose();
                                result.PrintMatrix();
                                break;
                            case "2":
                                result = matrix2.Transpose();
                                result.PrintMatrix();
                                break;
                            default:
                                Console.WriteLine("неа.");
                                break;
                        }

                        break;
                    case "5":
                        Console.WriteLine("Какую: 1 or 2?: ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                matrix1.Info();
                                break;
                            case "2":
                                matrix2.Info();
                                break;
                            default:
                                Console.WriteLine("неа.");
                                break;
                        }
                        break;
                    case "e":
                        check = false;
                        break;

                    default:
                        Console.WriteLine("так не пойдет");
                        break;
                }
            }
        }
    }
}
