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
            Console.WriteLine(ans);
        }

        static void nTOx() //второго соответственно
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string strn = n.ToString();
            char temp = strn[strn.Length - 1];
            strn = strn.Remove(strn.Length - 1);
            strn = strn.Insert(1, Convert.ToString(temp));
            Console.WriteLine(strn);
        }

        static void Main(string[] args) //выбор какое задание выполнять.
        {
            Console.WriteLine("Задание: ");
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
            Console.ReadKey();
        }
    }
}
