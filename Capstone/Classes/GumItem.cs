using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class GumItem:ItemGeneral
    {

       
        public override string Consume()
        {
            return "Chew Chew, Yum!";
        }

        public  GumItem(string name, decimal cost) : base(name, cost)
        {
            
        }

    }
}
