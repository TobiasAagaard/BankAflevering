namespace BankProgram.UI
{
    using BankProgram.Services;

    class BankAccountMenu
    {
        private readonly BankAccountService service;

        public BankAccountMenu(BankAccountService service)
        {
            this.service = service;
        }

        public void ShowMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Velkommen til Bankprogrammet ===");
                Console.WriteLine("1. Opret ny konto");
                Console.WriteLine("2. Vis alle konti");
                Console.WriteLine("3. Indsæt penge");
                Console.WriteLine("4. Hæv penge");
                Console.WriteLine("5. Overfør mellem konti");
                Console.WriteLine("6. Vis samlet rente");
                Console.WriteLine("7. Afslut");
                Console.Write("Vælg en mulighed: ");

                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": CreateAccount(); break;
                        case "2": ListAccounts(); break;
                        case "3": Deposit(); break;
                        case "4": Withdraw(); break;
                        case "5": Transfer(); break;
                        case "6": ShowTotalInterest(); break;
                        case "7": running = false; break;
                        default:
                            Console.WriteLine("Ugyldigt valg.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}");
                }

                if (running)
                {
                    Console.WriteLine("\nTryk på en tast for at fortsætte...");
                    Console.ReadKey();
                }
            }
        }

        private void CreateAccount()
        {
            Console.WriteLine("\n--- Opret ny konto ---");
            Console.WriteLine("1. Opsparingskonto");
            Console.WriteLine("2. Lønkonto");
            Console.WriteLine("3. Lånekonto");
            Console.Write("Vælg type: ");
            string? type = Console.ReadLine();

            Console.Write("Kontonavn: ");
            string name = Console.ReadLine() ?? "Ukendt";

            Console.Write("Startsaldo: ");
            double balance = double.Parse(Console.ReadLine() ?? "0");

            BankAccount account = type switch
            {
                "1" => new SavingsAccount(name, balance),
                "2" => new CheckingAccount(name, balance),
                "3" => new LoanAccount(name, balance, 100000),
                _ => throw new ArgumentException("Ukendt kontotype")
            };

            service.AddAccount(account);
            Console.WriteLine($"Konto oprettet: {account}");
        }

        private void ListAccounts()
        {
            Console.WriteLine("\n--- Alle konti ---");
            IReadOnlyList<BankAccount> accounts = service.GetAll();
            if (accounts.Count == 0)
            {
                Console.WriteLine("Ingen konti oprettet endnu.");
                return;
            }
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine(account);
            }
        }

        private void Deposit()
        {
            Console.Write("Konto-ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            BankAccount? account = service.FindById(id);
            if (account == null)
            {
                Console.WriteLine("Konto ikke fundet.");
                return;
            }
            Console.Write("Beløb: ");
            double amount = double.Parse(Console.ReadLine() ?? "0");
            account.Deposit(amount);
            Console.WriteLine($"Indsat. Ny saldo: {account.Balance:N2}");
        }

        private void Withdraw()
        {
            Console.Write("Konto-ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            BankAccount? account = service.FindById(id);
            if (account == null)
            {
                Console.WriteLine("Konto ikke fundet.");
                return;
            }
            Console.Write("Beløb: ");
            double amount = double.Parse(Console.ReadLine() ?? "0");
            account.Withdraw(amount);
            Console.WriteLine($"Hævet. Ny saldo: {account.Balance:N2}");
        }

        private void Transfer()
        {
            Console.Write("Fra konto-ID: ");
            int fromId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Til konto-ID: ");
            int toId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Beløb: ");
            double amount = double.Parse(Console.ReadLine() ?? "0");
            service.Transfer(fromId, toId, amount);
            Console.WriteLine("Overførsel gennemført.");
        }

        private void ShowTotalInterest()
        {
            double total = service.TotalInterest();
            Console.WriteLine($"\nSamlet rente på tværs af alle kontotyper: {total:N2}");
            Console.WriteLine("(Hver kontotype beregner rente forskelligt — det er polymorfi)");
        }
    }
}
