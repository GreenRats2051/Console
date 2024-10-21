namespace Calculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculation calc = new Calculation();
            CalculationDelegate<int> factorialDelegate = calc.Factorial;
            CalculationDelegate<int> numSumDelegate = calc.NumSum;
            CalculationDelegate<int> numMultDelegate = calc.NumMult;
            PrintDelegate printSumDelegate = calc.PrintSum;
            PrintDelegate printMultDelegate = calc.PrintMult;
            Console.WriteLine("Factorial of 5: " + factorialDelegate(5));
            Console.WriteLine("Sum of digits in 1234: " + numSumDelegate(1234));
            Console.WriteLine("Product of digits in 1234: " + numMultDelegate(1234));
            printSumDelegate(1234);
            printMultDelegate(1234);
            CalculationDelegate<int> combinedDelegate = numSumDelegate + numMultDelegate;
            Console.WriteLine("Combined delegate results:");
            foreach (CalculationDelegate<int> del in combinedDelegate.GetInvocationList())
            {
                Console.WriteLine(del(1234));
            }
            PrintDelegate dynamicPrintDelegate = null;
            string input;
            do
            {
                Console.WriteLine("Add 'PrintSum' or 'PrintMult' or 'exit' to quit:");
                input = Console.ReadLine();
                if (input == "PrintSum")
                {
                    dynamicPrintDelegate += printSumDelegate;
                }
                else if (input == "PrintMult")
                {
                    dynamicPrintDelegate += printMultDelegate;
                }
                else if (input == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command.");
                }
            } while (true);
            if (dynamicPrintDelegate != null)
            {
                dynamicPrintDelegate(1234);
            }
            int factorial13 = calc.Factorial(13);
            int sumOfDigits = calc.NumSum(factorial13);
            int multOfDigits = calc.NumMult(factorial13);

            Console.WriteLine($"Sum of digits in 13!: {sumOfDigits}");
            Console.WriteLine($"Product of digits in 13!: {multOfDigits}");
        }
    }
}
