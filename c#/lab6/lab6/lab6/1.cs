using System;

namespace Task1
{
    public delegate double MathOperation(double a, double b);

    class Program1
    {
        static void Main(string[] args)
        {
            MathOperation operation = Add;
            Console.WriteLine(operation(20, 10));

            operation = Subtract;
            Console.WriteLine(operation(20, 10));

            operation = Multiply;
            Console.WriteLine(operation(20, 10));

            operation = Divide;
            Console.WriteLine(operation(20, 10));
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b != 0)
                return a / b;
            return 0;
        }
    }
}