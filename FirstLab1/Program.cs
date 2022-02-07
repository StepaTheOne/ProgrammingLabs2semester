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
            Console.Write("Введите a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            double ans = a;
            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < n; ++i)
            {
                ans *= a;
            }
            Console.WriteLine($"Ответ: {ans}");
        }

        static void nTOx() //второго соответственно
        {
            Console.Write("Введите n: ");
            string n = Console.ReadLine();
            char temp = n[n.Length - 1];
            n = n.Remove(n.Length - 1);
            n = n.Insert(1, Convert.ToString(temp));
            Console.WriteLine($"Изначальное x: {n}");
        }

        static void Main(string[] args) //выбор какое задание выполнять.
        {
            Console.Write("Задание: ");
            int t = Convert.ToInt32(Console.ReadLine());
            switch (t)
            {
                case 1:
                    power();
                    break;
                case 2:
                    nTOx();
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
