using BankProgram;

namespace BankApplication
{
    class Program
    {
        static void Main()
        {
            List<BankAccount> accounts = new List<BankAccount>();
            BankAccount account1 = new BankAccount(1, 2700, "Sørn Dam", true, 5000);
            BankAccount account2 = new BankAccount(2, 500, "Mads Dam", false, 0);
            BankAccount account3 = new BankAccount(3, 10000, "Mikkel Dam", true, 10000);
            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(account3);

            Console.WriteLine(account1.withdraw(3000));
        }
    }
}
