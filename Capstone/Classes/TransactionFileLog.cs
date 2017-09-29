using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
   public class TransactionFileLog
    {

        public string filePath;

        public TransactionFileLog(string filepath)
        {
            filepath = "VendingMachineLog.txt";
            string cd = Directory.GetCurrentDirectory();
            string filePathOld = Path.Combine(cd, filepath);
            this.filePath = filePathOld;
        }

        public void RecordFinalChange(decimal initialAmount)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(DateTime.Now + " RETURN CHANGE " + initialAmount + " $0.00");
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("Error writing tx file.");
            }
        }

        public void RecordDeposit(decimal depositAmount, decimal finalBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(DateTime.Now + " FEED MONEY: $" + depositAmount + " $" + finalBalance);
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("Error writing tx file.");
            }
        }

        public void RecordPurchase(string productName, string slotid, decimal initialBalance, decimal finalBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(DateTime.Now + " " + productName + " " + slotid + " " + initialBalance + " " + finalBalance);
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("Error writing tx file.");            
            }
        }
        

       


    }
}
