using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class ItemGeneral
    {
        private string name;
        private decimal cost;

        public decimal Cost
        {
            get { return this.cost; }
        }


        public string Name
        {
            get { return this.name; }
        }

        public abstract string Consume();
       


        public ItemGeneral(string name, decimal cost)
        {
            this.name = name;
            this.cost = cost;
        }


    }
}
