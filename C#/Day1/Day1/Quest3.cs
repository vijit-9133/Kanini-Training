using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Quest3
    {

        private int id;
        private string acctype;
        private double bal;

        public int Id { get; set; }
        public string Acctype { get; set; }
        public double Bal { get; set; }

        public Quest3()
        {
        }

        public Quest3(int id, string acctype, double bal)
        {
            this.Id = id;
            this.Acctype = acctype;
            this.Bal = bal;
        }

        public bool Withdraw(double amount)
        {
            if (Bal >= amount)
            {
                Bal -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetDetails()
        {
            return $"Account Id: {Id}\nAccount Type: {Acctype}\nBalance: {Bal}";
        }
    }
}
