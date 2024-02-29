using System;

namespace SimpleCalculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
            // 提示用户输入第一个数字
            Console.Write("请输入第一个数字: ");
            double num1;
            // 尝试将用户输入转换为双精度浮点数
            while (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("请输入有效的数字!");
                Console.Write("请输入第一个数字: ");
            }

            // 提示用户输入运算符
            Console.Write("请输入运算符 (+, -, *, /): ");
            char op;
            // 尝试读取用户输入的字符
            while (!char.TryParse(Console.ReadLine(), out op) || !IsValidOperator(op))
            {
                Console.WriteLine("请输入有效的运算符 (+, -, *, /)!");
                Console.Write("请输入运算符 (+, -, *, /): ");
            }

            // 提示用户输入第二个数字
            Console.Write("请输入第二个数字: ");
            double num2;
            // 尝试将用户输入转换为双精度浮点数
            while (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("请输入有效的数字!");
                Console.Write("请输入第二个数字: ");
            }

            // 计算结果
            double result = Calculate(num1, op, num2);

            // 打印结果
            Console.WriteLine($"计算结果: {result}");

            Console.ReadLine(); // 等待用户按下 Enter 键退出程序
        }

        // 检查运算符是否有效
        static bool IsValidOperator(char op)
        {
            return op == '+' || op == '-' || op == '*' || op == '/';
        }

        // 执行计算
        static double Calculate(double num1, char op, double num2)
        {
            double result = 0;
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("除数不能为零!");
                        Environment.Exit(0); // 退出程序
                    }
                    break;
            }
            return result;
        }
    }
}
