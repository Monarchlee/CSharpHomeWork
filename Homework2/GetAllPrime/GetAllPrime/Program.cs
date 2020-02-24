using System;

namespace GetAllPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int realInput;
            Console.WriteLine("Question 3,input a interger and we give you all primes smaller than it.");
            
            while (!int.TryParse(userInput = Console.ReadLine(), out realInput))
            {
                Console.WriteLine("Invalid input.");
            }

            
            GetAllPrime(out int[] output, realInput);
            foreach (int n in output)
            {
                Console.Write(n + " ");
            }
            
        }

        public static void GetAllPrime(out int[] output, int input)
        {
            int num = 0, now = 2;
            bool[] flag = new bool[input + 1];
            for (int i = 2; i * i <= input; i++)
            {
                now = i;
                while (now * i <= input)
                {
                    flag[now * i] = true;
                    now++;
                }
            }
            for (int i = 2; i <= input; i++)
            {
                if (!flag[i])
                {
                    num++;
                }
            }
            output = new int[num];
            for (int i = 2, j = 0; i <= input; i++)
            {
                if (!flag[i])
                {
                    output[j] = i;
                    j++;
                }
            }
        }
    }
}
