using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {

        static void Main(string[] args)
        {
            bool arr = Class1.validatePassword(""); //обращается к validatePassword для проверки пароля
            Console.WriteLine("res = " + arr); //выводит значение, которое возвращает validatePassword

            string password = "ABVGD"; //создаёт симбволы в строке
            Console.WriteLine("len = " + password.Length); //считает симбволы в строке

            Console.ReadKey();
        }

        public static bool validatePassword(string password)
        {
            if (password.Length < 8 || password.Length > 20) //проверяет пароль на длину
                return false;
            if (!password.Any(Char.IsLower)) //проверяет пароль на наличие прописных букв
                return false;
            if (!password.Any(Char.IsUpper)) //проверяет пароль на наличие заглавных букв
                return false;
            if (!password.Any(Char.IsDigit)) //проверяет пароль на наличие цифр
                return false;
            if (password.Intersect("#$%^&_").Count() == 0) //проверяет пароль на наличие спец. симбволов
                return false;

            return true;
        }
    }
}
