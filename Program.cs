namespace BankProgram
{
    using BankProgram.Services;
    using BankProgram.UI;

    class Program
    {
        static void Main()
        {
            BankAccountService service = new BankAccountService();

            service.AddAccount(new SavingsAccount("Tobias Opsparing", 10000));
            service.AddAccount(new CheckingAccount("Tobias Lønkonto", 2500));
            service.AddAccount(new LoanAccount("Boliglån", -500000, 600000));

            BankAccountMenu menu = new BankAccountMenu(service);
            menu.ShowMenu();
        }
    }
}
