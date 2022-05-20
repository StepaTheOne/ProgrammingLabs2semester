using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLabs
{
    class Task1_1
    {
        public int Power()
        {
            int NumberToMultiply = Convert.ToInt32(Console.ReadLine());
            int TimesToMultiply = Convert.ToInt32(Console.ReadLine());
            int BufferNumber = NumberToMultiply;
            for (int Iterator = 1; Iterator < TimesToMultiply; ++Iterator)
            {
                NumberToMultiply *= BufferNumber;
            }
            return NumberToMultiply;
        }
    }
}


