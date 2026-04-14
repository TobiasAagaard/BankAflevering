namespace BankProgram
{
    class BankAccount
    {
        private int id;
        private double balance;
        private string name;
        private bool allowOverdraft;
        private long overdraftLimit;

        public BankAccount(int id, double balance, string name, bool allowOverdraft, long overdraftLimit)
        {
            this.id = id;
            this.balance = balance;
            this.name = name;
            this.allowOverdraft = allowOverdraft;
            this.overdraftLimit = overdraftLimit;
        }

        public string Name { get { return name; } set { name = value; }}

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
                return "Withdrawal was successfull, your balance is now: " + balance;
            }
        }

        public string deposit(double amount)
        {
            if (amount < 0)
            {
                return "You cannot deposit a negative amount";
            }
            else
            {
                balance += amount;
                return "Deposit was successfull, your balance is now: " + balance;
            }
        }

        public string getBalance()
        {
            return $"Your balance is: {balance}";
        }
    }
}