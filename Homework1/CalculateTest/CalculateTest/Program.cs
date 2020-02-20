using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTest
{
    class Func
    {

        public static double Doneit(double x,double y,char opt,ref bool flag)
        {
            double result = 0;
            switch (opt)
            {
                case '+':
                    result = x + y;
                    flag = true;
                    break;
                case '-':
                    result = x - y;
                    flag = true;
                    break;
                case '*':
                    result = x * y;
                    flag = true;
                    break;
                case '/':
                    if (y == 0)
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        result = x / y;
                        flag = true;
                    }
                    break;
                default:
                    flag = false;
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = "";string num2 = "";
            double realnum1 = 0, realnum2 = 0, result = 0;
            string opt="",end="";char realopt = '\0';
            bool flag = true;
            Console.WriteLine("This is a calculate.");
            while(true)
            {
                Console.WriteLine("PLS enter the two number needed to be done:");
                num1 = Console.ReadLine();
                while (Double.TryParse(num1, out realnum1) == false)
                {
                    Console.WriteLine("Invaild input.PLS input a valid num:");
                    num1 = Console.ReadLine();
                }
                num2 = Console.ReadLine();
                while (Double.TryParse(num2, out realnum2) == false)
                {
                    Console.WriteLine("Invaild input.PLS input a valid num:");
                    num1 = Console.ReadLine();
                }
                Console.WriteLine("Now for the option:");
                opt = Console.ReadLine();
                while (!Char.TryParse(opt, out realopt))
                {
                    Console.WriteLine("Invaild input.PLS input a valid opt:");
                    opt = Console.ReadLine();
                }
                result=Func.Doneit(realnum1, realnum2, realopt, ref flag);
                if(flag==false)
                {
                    Console.WriteLine("Invaild opt for these two nums,do it again.");
                    continue;
                }
                Console.WriteLine($"Your result is {result}");
                Console.WriteLine("Push z to end,c to continue.");
                end = Console.ReadLine();
                while (end!="z"&&end!="c")
                {
                    Console.WriteLine("PLS input a valid char");
                    end = Console.ReadLine();
                }
                if (end == "z")
                    break;
            }
        }
    }

}
