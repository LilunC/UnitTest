namespace Account
{
    public class Calculate: ICalculate
    {
        public int Sum(int value1, int value2)
        {
            return value1 + value2;
        }

        public int GetPercent(int value, double percent)
        {
            return (int)(value * percent);
        }
    }
}
