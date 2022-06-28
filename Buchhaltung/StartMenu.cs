﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltung
{
    internal class StartMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Willkommen zue Buchhaltungssoftware");
            Console.WriteLine();
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("--------------------");
            Console.WriteLine("[1] Neues Profil anlegen");
            Console.WriteLine("[2] Profil laden");
            Console.WriteLine();
            //Console.WriteLine("[3] Programm beenden");

            InputOption();
        }

        private void InputOption()
        {
            string input;
            Menu nextMenu;

            while (true)
            {
                Console.Write("Eingabe: ");
                input = Console.ReadLine();

                bool correctInput = true;

                switch (input)
                {
                    case "1":
                        nextMenu = new CreateProfileMenu();
                        break;
                    case "2":
                        nextMenu = new LoadProfileMenu();
                        break;
                    default:
                        correctInput = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ungültige Eingabe!");
                        Console.ResetColor();
                        break;
                }

                if (correctInput) break;
            }
        }
    }
}
