namespace BankProgram
{
    abstract class BankAccount
    {
        private static int nextId = 1;

        public int Id { get; private set; }
        public double Balance { get; protected set; }
        public string AccountName { get; set; }
        public double OverdraftInterest { get; set; }
        public bool AllowOverdraft { get; set; }
        public long OverdraftLimit { get; set; }

        protected BankAccount(string accountName, double balance, bool allowOverdraft, long overdraftLimit, double overdraftInterest = 0)
        {
            Id = nextId++;
            AccountName = accountName;
            Balance = balance;
            AllowOverdraft = allowOverdraft;
            OverdraftLimit = overdraftLimit;
            OverdraftInterest = overdraftInterest;
        }

        public abstract double CalculateInterest();

        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Beløbet skal være positivt");
            }
            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Beløbet skal være positivt");
            }
            if (!AllowOverdraft && Balance - amount < 0)
            {
                throw new Exception("Saldoen er ikke tilstrækkelig til at hæve dette beløb");
            }
            if (AllowOverdraft && Balance - amount < -OverdraftLimit)
            {
                throw new Exception($"Overtrækskreditten på {OverdraftLimit} er overskredet");
            }
            Balance -= amount;
        }

        public override string ToString()
        {
            string typeName = this.GetType().Name;
            return $"[{Id}] {AccountName} ({typeName}) - Saldo: {Balance:N2} - Rente: {CalculateInterest():N2}";
        }
    }
}
