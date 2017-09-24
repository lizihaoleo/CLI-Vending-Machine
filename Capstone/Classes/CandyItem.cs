using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
   public class CandyItem : ItemGeneral
    {
        
        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }

        public CandyItem (string name, decimal cost) : base(name, cost)
        {
        }

    }

}
