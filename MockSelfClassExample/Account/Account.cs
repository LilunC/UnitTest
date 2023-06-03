namespace Account
{
    public class Account
    {
        private readonly ICalculate _calculate;

        public int Money { get; private set; }

        public Account()
        {
            _calculate = new Calculate();
        }

        public Account(ICalculate calculate)
        {
            _calculate = calculate;
        }

        public void SetMoney(int value)
        {
            Money = value;
        }

        public void GenerateTenPercentInterest()
        {
            var interest = _calculate.GetPercent(Money, 0.1);
            Money = _calculate.Sum(Money, interest);

            Money = MeetThief();
            Money = MachineBroken();
        }
        public virtual int MeetThief()
        {
            return 1;
        }
        protected virtual int MachineBroken()
        {
            return 0;
        }
    }
}
