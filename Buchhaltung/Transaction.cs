using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltung
{
    [Serializable]
    internal class Transaction
    {
        public string Name { get; set; }
        public decimal Ammount { get; set; }
        public DateTime Date   { get; set; }

        public Transaction(string name, decimal ammount, DateTime date)
        {
            Name = name;
            Ammount = ammount;
            Date = date;
        }

        public override string ToString()
        {
            return "Name: " + Name + " | Datum: " + Date.ToShortDateString() + " | Betrag: " + Ammount + " Euro";
        }
    }
}
