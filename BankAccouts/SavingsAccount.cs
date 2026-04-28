namespace BankProgram
{
    class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }

        public SavingsAccount(string accountName, double balance, double interestRate = 0.03)
            : base(accountName, balance, false, 0)
        {
            InterestRate = interestRate;
        }

        public override double CalculateInterest()
        {
            return Balance * InterestRate;
        }
    }
}
