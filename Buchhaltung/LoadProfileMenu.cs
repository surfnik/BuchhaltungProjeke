using System.IO;

namespace Buchhaltung
{
    internal class LoadProfileMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Wähle ein Profil aus:");
            Console.WriteLine("---------------------");
            ShowProfiles();
            Console.WriteLine();
            string profilePath = InputProfileName();
            if (profilePath != "cancel")
            {
            ProfileManager.LoadProfile(profilePath);
            Menu nextMenu = new MainMenu();
            }
            else
            {
                Menu nextMenu = new StartMenu();
            }
        }

        private void ShowProfiles() 
        {
            string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");

            foreach (string file in profileFiles)
            {
                Console.WriteLine("- " + Path.GetFileName(file));
            }
        }

        private string InputProfileName()
        {
            string input = "";

            while (true)
            {
                Console.Write("Zu ladendes Profil: [\"cancel zum abbrechen\"]: ");
                input = Console.ReadLine();
                string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");
                bool correctInput = false;

                if (input == "cancel")
                {
                    correctInput = true;
                }
                else
                {
                    for (int i = 0; i < profileFiles.Length; i++)
                    {
                        profileFiles[i] = Path.GetFileName(profileFiles[i]);

                        if (input == profileFiles[i])
                        {
                            correctInput = true;
                            input = AppContext.BaseDirectory + input;
                            break;
                        }
                    }
                }

                if (correctInput)
                {
                    break;
                }else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Falsche Eingabe");
                    Console.ResetColor();
                }
            }
            return input;
        }

    }
}
