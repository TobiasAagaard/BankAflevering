namespace BankProgram
{
    class BankAccount
    {
        private int id;
        private double balance;
        private string accountName;
        private const double interestRate = 0.05;
        private bool allowOverdraft;
        private long overdraftLimit;

        public BankAccount(int id, double balance, string accountName, bool allowOverdraft, long overdraftLimit)
        {
            this.id = id;
            this.balance = balance;
            this.accountName = accountName;
            this.allowOverdraft = allowOverdraft;
            this.overdraftLimit = overdraftLimit;
        }

        public string AccountName { get { return accountName; } set { accountName = value; }}

        public string withdraw(double amount)
        {
            if (amount < 0 && allowOverdraft == false)
            {
                return "You cannot withdraw into a negative amount";
            }
            else if (amount < 0 && allowOverdraft == true && balance - amount < -overdraftLimit)
            {
                return $"You cannot exceed your limit of overdraft, which is {overdraftLimit}. Contact your bank for more information.";
            }
            else
            {
                balance -= amount;
                return $"{AccountName}: Withdrawal was successful, your balance is now: {balance}";
            }
        }

        public string deposit(double amount)
        {
            if (amount < 0)
            {
                return $"{AccountName}: You cannot deposit a negative amount";
            }
            else
            {
                balance += amount;
                return $"{AccountName}: Deposit was successful, your balance is now: {balance}";
            }
        }

        public string transfer(BankAccount toAccount, double amount)
        {
            if (amount < 0 && allowOverdraft == false)
            {
                return $"{AccountName}: You cannot transfer money from an account, into a negative amount";
            }
            else if (amount < 0 && allowOverdraft == true && balance - amount < -overdraftLimit)
            {
                return $"{AccountName}: You cannot transfer money from an account, into a negative amount that exceeds your limit of overdraft, which is {overdraftLimit}. Contact your bank for more information.";
            }
            else
            {
                balance -= amount;
                toAccount.balance += amount;
                return $"{AccountName}: Transfer was successful. You transferred money over to {toAccount.AccountName}, your balance is now: {balance}";
            }
        }
        public string getBalance()
        {
            return $"{AccountName}: Your balance is: {balance}";
        }

    }
}