namespace Buchhaltung
{
    internal class ShowTransactionsMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Gebe den Zeitraum ein");
            Console.WriteLine("---------------------");

            DateTime startDate = ImputStartDate();
            DateTime endDate = InputEndDate(startDate);
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            PrintTransactionsFromTo(startDate, endDate);
            Console.WriteLine("-----------------------------");

            Console.WriteLine("Drücke eine Taste um zum Hauptmenü zurückzukenhren");
            Console.ReadKey();
            Menu nextMenu = new MainMenu();
        }

        private DateTime ImputStartDate()
        {
            DateTime input;
            bool correctInput = true;

            do
            {
                Console.Write("Startdatum (TT.MM.YYYY): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                {
                    correctInput = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültiges Datum");
                    Console.ResetColor();
                }
                else correctInput = true;
            }
            while (!correctInput);
            return input;
        }

        private DateTime InputEndDate(DateTime startDate)
        {
            DateTime input;
            bool correctInput = true;

            do
            {
                Console.Write("Enddatum (TT.MM.YYYY): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input) || input < startDate)
                {
                    correctInput = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültiges Datum");
                    Console.ResetColor();
                }
                else correctInput = true;
            }
            while (!correctInput);
            return input;
        }

        private void PrintTransactionsFromTo(DateTime startDate, DateTime endDate)
        {
            foreach(Transaction transaction in ProfileManager.CurrentProfile.Transactions)
            {
                if (transaction.Date >= startDate && transaction.Date <= endDate)
                {
                    if(transaction.Ammount < 0)
                        Console.ForegroundColor= ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(transaction.ToString());
                    Console.ResetColor();
                }
            }
        }
    }
}