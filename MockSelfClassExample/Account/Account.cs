using System;

namespace Account
{
    public class Account
    {
        private readonly ICalculate _calculate;

        public int Money { get; private set; }

        public Account()
        {
            Console.WriteLine("[Construct] Account");
            _calculate = new Calculate();
        }

        public Account(ICalculate calculate)
        {
            Console.WriteLine("[Construct] Account(ICalculate)");
            _calculate = calculate;
        }

        public void SetMoney(int value)
        {
            Console.WriteLine("[Method Call] Account : SetMoney");
            Money = value;
        }

        public void GenerateTenPercentInterest()
        {
            Console.WriteLine("[Method Call] Account : GenerateTenPercentInterest");
            var interest = _calculate.GetPercent(Money, 0.1);
            Money = _calculate.Sum(Money, interest);

            Money = MeetThief();
            Money = MachineBroken();
            Money = MachineGotVirus();
            Money = FixMachine();
        }

        public virtual int MeetThief()
        {
            Console.WriteLine("[Method Call] Account : MeetThief");

            var noMoney = 0;
            return noMoney;
        }

        protected virtual int MachineBroken()
        {
            Console.WriteLine("[Method Call] Account : MachineBroken");

            var errorValue = int.MinValue;
            return errorValue;
        }
        protected virtual int MachineGotVirus(double moneyTimes = 0.1)
        {
            Console.WriteLine("[Method Call] Account : MachineBroken");

            var errorValue = Money * moneyTimes;
            return (int)errorValue;
        }
        protected virtual int FixMachine()
        {
            Console.WriteLine("[Method Call] Account : FixMachine");

            var returnToZero = 0;
            return returnToZero;
        }

    }
}
