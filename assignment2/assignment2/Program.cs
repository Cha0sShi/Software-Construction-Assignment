using System;
using System.Collections.Generic;

namespace PrimeFactorization
{
    class Program
    {
        static void Main(string[] args)
        {
            // 获取用户输入的数据
            Console.WriteLine("请输入一个整数：");
            int input = Convert.ToInt32(Console.ReadLine());

            // 输出用户指定数据的所有素数因子
            Console.WriteLine($"输入的整数 {input} 的素数因子为：");
            List<int> primeFactors = GetPrimeFactors(input);
            foreach (int factor in primeFactors)
            {
                Console.Write(factor + " ");
            }
            Console.WriteLine();

            // 整数数组
            int[] numbers = { 5, 2, 8, 10, 3 };

            // 输出整数数组的最大值、最小值、平均值和所有数组元素的和
            Console.WriteLine($"整数数组的最大值为：{GetMax(numbers)}");
            Console.WriteLine($"整数数组的最小值为：{GetMin(numbers)}");
            Console.WriteLine($"整数数组的平均值为：{GetAverage(numbers)}");
            Console.WriteLine($"整数数组的和为：{GetSum(numbers)}");

            // 用埃氏筛法求2~100以内的素数
            Console.WriteLine("2~100以内的素数为：");
            List<int> primes = SieveOfEratosthenes(2, 100);
            foreach (int prime in primes)
            {
                Console.Write(prime + " ");
            }
            Console.WriteLine();

            // 托普利茨矩阵
            int[,] matrix = {
                {1, 2, 3, 4},
                {5, 1, 2, 3},
                {9, 5, 1, 2}
            };

            // 判断矩阵是否是托普利茨矩阵
            bool isToeplitzMatrix = IsToeplitzMatrix(matrix);
            Console.WriteLine($"给定的矩阵{(isToeplitzMatrix ? "是" : "不是")}托普利茨矩阵。");
        }

        // 获取用户指定数据的所有素数因子
        static List<int> GetPrimeFactors(int n)
        {
            List<int> primeFactors = new List<int>();

            // 找出所有的2作为质因子
            while (n % 2 == 0)
            {
                primeFactors.Add(2);
                n /= 2;
            }

            // n现在应该是奇数
            // 在这里只需要检查奇数作为质因子
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    primeFactors.Add(i);
                    n /= i;
                }
            }

            // 如果 n 是质数且大于 2，则它本身也是一个质因子
            if (n > 2)
                primeFactors.Add(n);

            return primeFactors;
        }

        // 获取整数数组的最大值
        static int GetMax(int[] numbers)
        {
            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }

        // 获取整数数组的最小值
        static int GetMin(int[] numbers)
        {
            int min = numbers[0];
            foreach (int num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }

        // 获取整数数组的平均值
        static double GetAverage(int[] numbers)
        {
            int sum = GetSum(numbers);
            return (double)sum / numbers.Length;
        }

        // 获取整数数组的和
        static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        // 使用埃氏筛法求素数
        static List<int> SieveOfEratosthenes(int start, int end)
        {
            List<int> primes = new List<int>();
            bool[] isPrime = new bool[end + 1];
            for (int i = 2; i <= end; i++)
            {
                isPrime[i] = true;
            }
            for (int p = 2; p * p <= end; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= end; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }
            for (int i = start; i <= end; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        // 判断矩阵是否是托普利茨矩阵
        static bool IsToeplitzMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] != matrix[i - 1, j - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
