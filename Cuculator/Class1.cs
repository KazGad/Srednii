using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuculator
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите перове число:");
            int n1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int n2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите действие:");
            String Sym = Console.ReadLine();
            int arr = Class1.validateSym(n1, n2, Sym);
            Console.WriteLine("resout = " + arr);

            Console.ReadKey();
        }
        public static int validateSym(int n1, int n2, String Sym)
        {
            if (Sym == "+")
                return n1 + n2;
            if (Sym == "-")
                return n1 - n2;
            if (Sym == "*")
                return n1 * n2;
            if (Sym == "/")
            {
                try
                {
                    if (n2 == 0)
                    {
                        throw new DivideByZeroException("Не делите на ноль!");
                    }
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
                Console.Read();
                /*if (n2 == 0)
                {
                    Console.WriteLine(0);
                }*/
                return n1 / n2;
            }
            return 0;
        }
    }
}
