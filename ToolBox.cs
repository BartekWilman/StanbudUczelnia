using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosty_Kalkulator
{
    internal class ToolBox
    {
        public static int SafeIntParse()
        {
            while (true)
            {
                int num;
                if(int.TryParse(Console.ReadLine(), out num) == true)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Błędna wartość");
                }
            }
        }
        public static float SafeFloatParse()
        {
            while (true)
            {
                float num;
                if(float.TryParse(Console.ReadLine(), out num) == true)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Błędna wartość");
                }
            }
        }

    }
}
