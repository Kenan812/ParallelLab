using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelLab
{
    class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter number of task(1 - 5)");
                    Console.WriteLine("Enter '0' to exit");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~");
                    Console.Write("Task #: ");
                    string ch = Console.ReadLine();

                    if (ch == "0") break;

                    else if (ch == "1") StartEx1();

                    else if (ch == "2") StartEx2();

                    else if (ch == "3") StartEx3();

                    else if (ch == "4") StartEx4();

                    else if (ch == "5") StartEx5(); 


                    Console.WriteLine("\nEnter any key to continue");
                    Console.ReadKey();
                }
                catch (Exception) { }
            }
        }



        private static void StartEx1()
        {
            try
            {
                Console.WriteLine("\nThis task finds factorial of number");
                Console.Write("Enter n: ");

                int n = Int32.Parse(Console.ReadLine());

                Parallel.Invoke(() => PrintFactorial(n));
            }
            catch (Exception) { }
        }

        private static void StartEx2()
        {
            try
            {
                Console.WriteLine("\nThis task finds digit count and digit sum of number");
                Console.Write("Enter n: ");

                int n = Int32.Parse(Console.ReadLine());

                Parallel.Invoke(() => PrintDigitCount(n));
                Parallel.Invoke(() => PrintDigitSum(n));
            }
            catch (Exception) { }
        }

        private static void StartEx3()
        {
            try
            {
                Console.WriteLine("\nThis task prints multiplication tables");
                Console.Write("Enter lower bound: ");
                int lb = Int32.Parse(Console.ReadLine());
                Console.Write("Enter upper bound: ");
                int ub = Int32.Parse(Console.ReadLine());

                Parallel.For(lb, ub + 1, PrintMultiplicationTable);
            }
            catch (Exception) { }
        }

        private static void StartEx4()
        {
            Console.WriteLine("\nThis task prints factorial for all numbers in list");

            Random rnd = new Random();
            List<int> list = new List<int>(); 

            for (int i = 0; i < 30; i++)
                list.Add(rnd.Next(11));

            Parallel.ForEach(list, PrintFactorial);

        }

        private static void StartEx5()
        {
            Console.WriteLine("\nThis task prints sum, min and max in list");

            Random rnd = new Random();
            List<int> list = new List<int>();

            Console.WriteLine("\nList");
            Console.WriteLine("~~~~~~~~~~~~~~~~~");
            for (int i = 0; i < 100; i++)
            {
                list.Add(rnd.Next(1000));
                Console.Write(list[i] + " ");
            }
            Console.WriteLine("\n");

            Parallel.Invoke(() => PrintSum(list));
            Parallel.Invoke(() => PrintMin(list));
            Parallel.Invoke(() => PrintMax(list));
        }


        private static void PrintFactorial(int n)
        {
            int res = 1;

            for (int i = 1; i <= n; i++)
                res *= i;

            Console.WriteLine($"Factorial of {n}: {res}");
        }

        private static void PrintDigitCount(int n)
        {
            int res = 0;
            while(n != 0)
            {
                res++;
                n /= 10;
            }

            Console.WriteLine($"Digit count: {res}");
        }

        private static void PrintDigitSum(int  n)
        {
            int res = 0;
            while (n != 0)
            {
                res += n % 10;
                n /= 10;
            }

            Console.WriteLine($"Digit sum: {res}");
        }

        private static void PrintMultiplicationTable(int n)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{n} * {i} = {n * i}");
            }
            Console.WriteLine();
        }

        private static void PrintSum(List<int> ls)
        {
            Console.WriteLine($"Sum of all numbers: {ls.Sum()}");
        }

        private static void PrintMin(List<int> ls)
        {
            Console.WriteLine($"Min in list: {ls.Min()}");
        }

        private static void PrintMax(List<int> ls)
        {
            Console.WriteLine($"Max in list: {ls.Max()}");
        }

    }
}
