using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class ChipsItem : ItemGeneral
    {

        public override string Consume()
        {
            return "Crunch Crunch, Yum!";
        }

        public ChipsItem(string name, decimal cost) : base(name, cost)
        {
        }

    }
}
