using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine 
    {

        private decimal currentBalance;
        public Dictionary<string, List<ItemGeneral>> inventory;
        private ReadInInventory inventorysource;
        //private TransactionFileLog transactionLogger;

        public decimal CurrentBalance
        {
            get { return this.currentBalance; }
        }
        public string[] Slots
        {
            get { return inventory.Keys.ToArray(); }
        }
        public VendingMachine(Dictionary<string, List<ItemGeneral>> inventory)
        {
            this.inventory = inventory;
        }

        public void FeedMoney(int dollars)
        {
            this.currentBalance += Convert.ToDecimal(dollars);
        }
        public ItemGeneral GetItemAtSlot(string slotID)
        {
            List<ItemGeneral> list = inventory[slotID];
            return list[0];
        }
        public VendingMachine()
        {
            inventorysource = new ReadInInventory("vendingmachine.csv");
            inventory = inventorysource.GetInventory();
        }
      

        public int GetQuantityRemaining(string slotID)
        {
            return inventory[slotID].Count;
        }

        public ItemGeneral Purchase(string slotID)
        {
            

            for (int i = 0; i < Slots.Length ; i++)
            {
                if (slotID == Slots[i])
                {
                    if (inventory[slotID].Count > 0)
                    {
                        if (this.currentBalance >= inventory[slotID][0].Cost)
                        {
                            
                            this.currentBalance -= inventory[slotID][0].Cost;
                            ItemGeneral im = inventory[slotID][0];
                            inventory[slotID].Remove(inventory[slotID][0]);
                            return im;

                        }

                    }

                }

            }

            return null;

        }

        public Change ReturnChange()
        {
            Change money = new Change(this.currentBalance);
            this.currentBalance = 0;
            return money;
        }



    }
}
