namespace BankProgram.Services
{
    class BankAccountService
    {
        private readonly List<BankAccount> accounts = new List<BankAccount>();

        public void AddAccount(BankAccount account)
        {
            accounts.Add(account);
        }

        public BankAccount? FindById(int id)
        {
            return accounts.FirstOrDefault(a => a.Id == id);
        }

        public IReadOnlyList<BankAccount> GetAll()
        {
            return accounts;
        }

        public double TotalInterest()
        {
            double sum = 0;
            foreach (BankAccount account in accounts)
            {
                sum += account.CalculateInterest();
            }
            return sum;
        }

        public void Transfer(int fromId, int toId, double amount)
        {
            BankAccount? from = FindById(fromId);
            BankAccount? to = FindById(toId);

            if (from == null || to == null)
            {
                throw new ArgumentException("En af kontiene blev ikke fundet");
            }

            from.Withdraw(amount);
            to.Deposit(amount);
        }
    }
}
