namespace Buchhaltung
{
    internal class NewTransactionMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Neue Transaktion");
            Console.WriteLine("----------------");

            string newTransactionName = InputTransactionName();
            decimal newTransactionAmmount = InputTransactionAmmount();
            DateTime newTransactionDate = InputTransactionDate();

            Transaction transaction = new Transaction(newTransactionName, newTransactionAmmount, newTransactionDate);
            ProfileManager.CurrentProfile.AddTransaction(transaction);
            Console.WriteLine();
            Console.WriteLine("Die folgende Transaktion wurde gebucht.");

            if (transaction.Ammount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(transaction.ToString());
            Console.ResetColor();
            Console.ReadKey();
            Menu nextMenu = new MainMenu();
        }


        private string InputTransactionName()
        {
            Console.Write("Transaktions-Name: ");
            return Console.ReadLine();
        }
        private decimal InputTransactionAmmount()
        {
            decimal input;
            bool correctInput = true;

            do
            {
                Console.Write("Euro-Betrag: ");
                if (!decimal.TryParse(Console.ReadLine(), out input))
                {
                    correctInput = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültiger Betrag");
                    Console.ResetColor();
                }
                else correctInput = true;

            } 
            while (!correctInput);
            return input;
        }
        private DateTime InputTransactionDate()
        {
            DateTime input;
            bool correctInput = true;

            do
            {
                Console.Write("Datum (TT.MM.YYYY) eingeben: ");
                if(!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                {
                    correctInput=false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültiges Datum");
                    Console.ResetColor();
                }
                else correctInput = true;
            } 
            while (!correctInput);
            return input;
        }
    }
}