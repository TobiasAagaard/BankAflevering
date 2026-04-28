namespace BankProgram
{
    class LoanAccount : BankAccount
    {
        public double LoanInterestRate { get; set; }

        public LoanAccount(string accountName, double balance, long overdraftLimit, double loanInterestRate = 0.08)
            : base(accountName, balance, true, overdraftLimit)
        {
            LoanInterestRate = loanInterestRate;
        }

        public override double CalculateInterest()
        {
            return Balance * LoanInterestRate;
        }
    }
}
