using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
   public class VendingMachineException:Exception
    {

        public VendingMachineException(string message)
            : base(message)
        {

        }



    }
}
