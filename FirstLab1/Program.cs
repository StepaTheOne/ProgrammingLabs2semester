using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab1
{
    internal class Program
    {
        static void power() //программа первого подзадания
        {
            Console.Write("Введите число: ");
            double num = Convert.ToDouble(Console.ReadLine());
            double result = num;
            Console.Write("Введите степень: ");
            int power = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < power; ++i)
            {
                result *= num;
            }
            Console.WriteLine($"Ответ: {result}");
        }

        static void MoveN() //второго соответственно
        {
            Console.Write("Введите n: ");
            string SrcNum = Console.ReadLine();
            char temp = SrcNum[SrcNum.Length - 1];
            SrcNum = SrcNum.Remove(SrcNum.Length - 1);
            SrcNum = SrcNum.Insert(1, Convert.ToString(temp));
            Console.WriteLine($"Изначальное x: {SrcNum}");
        }

        static void Main(string[] args) //выбор какое задание выполнять.
        {
            Console.Write("Задание: ");
            int Task = Convert.ToInt32(Console.ReadLine());
            switch (Task)
            {
                case 1:
                    power();
                    break;
                case 2:
                    MoveN();
                    break;
                default:
                    Console.WriteLine("2 задания. 1 или 2.");
                    break;
            }
            Console.Write("Нажмите любую клавишу... ");
            Console.ReadKey();
        }
    }
}
