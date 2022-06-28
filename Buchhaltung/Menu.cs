using System;


namespace Buchhaltung
{
    abstract internal class Menu
    {
        public Menu()
        {
            Console.Clear();
            DisplayMenu();
        }
        public abstract void DisplayMenu();
    }
}
