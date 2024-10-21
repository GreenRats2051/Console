namespace Calculation
{
    public delegate T CalculationDelegate<T>(T number);
    public delegate void PrintDelegate(int number);
    public delegate bool RemoveDelegate(int number, out int result, ref int count);

    internal class Calculation
    {
        public int Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Negative numbers don't have factorials.");
            return n == 0 ? 1 : n * Factorial(n - 1);
        }
        public int NumSum(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
        public int NumMult(int number)
        {
            int product = 1;
            while (number > 0)
            {
                product *= number % 10;
                number /= 10;
            }
            return product;
        }
        public void PrintSum(int number)
        {
            Console.WriteLine(NumSum(number));
        }
        public void PrintMult(int number)
        {
            Console.WriteLine(NumMult(number));
        }
        public bool RemoveOdd(int number, out int result, ref int count)
        {
            string numberStr = number.ToString();
            string newNumberStr = "";
            count = 0;

            foreach (char digit in numberStr)
            {
                if ((digit - '0') % 2 == 0)
                {
                    count++;
                }
                else
                {
                    newNumberStr += digit;
                }
            }
            result = newNumberStr.Length > 0 ? int.Parse(newNumberStr) : 0;
            return count > 0;
        }
        public double NumSum(double number)
        {
            return NumSum((int)Math.Abs(number));
        }
        public double NumMult(double number)
        {
            return NumMult((int)Math.Abs(number));
        }

        public CalculationDelegate<double> GetSumDelegate()
        {
            return NumSum;
        }

        public CalculationDelegate<double> GetMultDelegate()
        {
            return NumMult;
        }
    }
}
