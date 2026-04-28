namespace BankProgram
{
    class CheckingAccount : BankAccount
    {
        public double DailyInterestRate { get; set; }

        public CheckingAccount(string accountName, double balance, long overdraftLimit = 5000, double dailyInterestRate = 0.005)
            : base(accountName, balance, true, overdraftLimit)
        {
            DailyInterestRate = dailyInterestRate;
        }

        public override double CalculateInterest()
        {
            if (Balance < 0)
            {
                return 0;
            }
            return Balance * DailyInterestRate;
        }
    }
}
