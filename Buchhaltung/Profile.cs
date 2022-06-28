using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltung
{
    [Serializable]
    internal class Profile
    {
        public string Name { get; set; }
        public decimal Ballance { get; set; }
        public List<Transaction> Transactions { get; private set; }

        public Profile(string name, decimal ballance)
        {
            Name = name;
            Ballance = ballance;
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
            Ballance += transaction.Ammount;
            ProfileManager.SaveProfile(this);
        }
    }
}
