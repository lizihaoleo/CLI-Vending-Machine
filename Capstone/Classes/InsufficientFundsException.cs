using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes;

namespace Capstone.Classes
{
   public class InsufficientFundsException : VendingMachineException
    {

        public InsufficientFundsException(string message)
            : base(message)
        {
            
        }

    }
}
