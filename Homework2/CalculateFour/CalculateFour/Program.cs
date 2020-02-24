using System;

namespace CalculateFour
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int realInput;
            Console.WriteLine("Question 2,PLS input an array and produce sum,max,min and average.");
            Console.WriteLine("PLS input the length of your array");
            while (!int.TryParse(userInput = Console.ReadLine(), out realInput))
            {
                Console.WriteLine("Invalid input.");
            }

                int nowInput = 0;
                int[] secondResult, inputArray;
                inputArray = new int[realInput];
                secondResult = new int[3];
                Console.WriteLine("Input your number with enter after each data.");
                for (int i = 0; i < realInput; i++)
                {
                    userInput = Console.ReadLine();
                    if (!int.TryParse(userInput, out nowInput))
                    {
                        Console.WriteLine("Invalid input,PLS do it again.");
                        i--;
                    }
                    else
                    {
                        inputArray[i] = nowInput;
                    }
                }
                GetFourFactors(inputArray, secondResult, out float average);
                Console.WriteLine("Sum is: " + secondResult[0]);
                Console.WriteLine("Max is: " + secondResult[1]);
                Console.WriteLine("Min is: " + secondResult[2]);
                Console.WriteLine("Average is: " + average.ToString());

        }
        public static void GetFourFactors(int[] input, int[] output, out float average)
        {
            int max = int.MinValue, min = int.MaxValue, sum = 0;

            foreach (int data in input)
            {
                sum += data;
                max = data > max ? data : max;
                min = data < min ? data : min;
            }
            average = (float)sum / input.Length;
            output[0] = sum;
            output[1] = max;
            output[2] = min;
        }
    }
}
