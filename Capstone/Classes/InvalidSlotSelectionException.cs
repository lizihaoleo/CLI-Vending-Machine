using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
   public class InvalidSlotSelectionException : VendingMachineException
    {

        public InvalidSlotSelectionException(string message)
            : base(message)
        {

        }
       

    }
}
