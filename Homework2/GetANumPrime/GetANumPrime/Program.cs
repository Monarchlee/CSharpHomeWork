using System;

namespace GetANumPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1,PLS input a int and this give you its prime factors.");
            string userInput;
            int realInput = 0, arrayLength = 0;
            while(!int.TryParse(userInput=Console.ReadLine(), out realInput))
            {
                Console.WriteLine("Invalid input.");
            }
            arrayLength = GetPrime(realInput, out int[] result);
            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine(result[i].ToString());
            }

        }
        public static bool IsPrime(int input)
        {
            if (input == 2 || input == 3)
            {
                return true;
            }
            for (int i = 2; i * i < input; i++)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static int GetPrime(int input, out int[] result)
        {
            result = new int[100];
            int now = 2, count = 0;

            while (now * now <= input)
            {
                if (input % now == 0)
                {
                    if ((count == 0 || now != result[count - 1]) && IsPrime(now))
                    {
                        result[count] = now;
                        count++;
                    }
                    input = input / now;
                }
                else
                {
                    now++;
                }
            }
            if (IsPrime(input))
            {
                result[count] = input;
                count++;
            }
            return count;
        }
    }
}
