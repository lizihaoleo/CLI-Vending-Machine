using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class BeverageItem : ItemGeneral
    {

        public override string Consume()
        {
            return "Glug Glug, Yum!";
        }

        public BeverageItem(string name, decimal cost) : base(name, cost)
        {

        }

    }
}
