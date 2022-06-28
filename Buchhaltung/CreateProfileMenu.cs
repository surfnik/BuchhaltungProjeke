using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltung
{
    internal class CreateProfileMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Profil erstellen");
            Console.WriteLine();

            string profileName = InputName();
            decimal profileStarBallance = InputStartBallance();

            ProfileManager.CreateProfile(profileName, profileStarBallance);

            Menu nextMenu = new MainMenu();
        }

        private string InputName()
        {
            while (true)
            {
                string input = "";
                Console.Write("Profilname: ");
                input = Console.ReadLine();

                if (ValidateName(input))
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bitte einen gültigen Namen eingeben.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        private bool ValidateName(string name)
        {
            if (ProfileManager.CheckIfProfileExists(name))
                return false;

            foreach (char  c in name)
            {
                if(!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private decimal InputStartBallance()
        {
            while (true)
            {
                Console.Write("Start Kontostand: ");
                decimal input;
                string strInput = Console.ReadLine();

                if(!decimal.TryParse(strInput, out input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fehler: Ungültiger Betrag");
                    Console.ResetColor();
                    continue;
                }
                return input;
            }
        }

    }
}
