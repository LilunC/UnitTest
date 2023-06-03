using System;

namespace Account
{
    public class Calculate : ICalculate
    {
        public bool IsEngineeringCalculate { get; private set; } = false;

        public Calculate()
        {
            Console.WriteLine("[Construct] Calculate");
            IsEngineeringCalculate = true;
        }

        public int Sum(int value1, int value2)
        {
            Console.WriteLine("[Method Call] Calculate : Sum");
            return value1 + value2;
        }

        public int GetPercent(int value, double percent)
        {
            Console.WriteLine("[Method Call] Calculate : GetPercent");
            return (int)(value * percent);
        }
    }
}
