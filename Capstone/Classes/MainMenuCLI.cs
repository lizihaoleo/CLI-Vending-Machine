using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class MainMenuCLI
    {
        TransactionFileLog log = new TransactionFileLog("VendingMachineLog.txt");
        List<ItemGeneral> itemsBought = new List<ItemGeneral>();
        VendingMachine vendomatic = new VendingMachine();

        public void DisplayVendingMachine()
        {
            PrintHeader();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Pick Yo Option");
                Console.WriteLine("1) Display Vending Machine items");
                Console.WriteLine("2) Purchase");

                string input = Console.ReadLine();
                
                if (input == "1")
                {
                    DisplayInventory();                    
                }
                else if (input == "2")
                {
                    DisplayPurchaseMenu();                    
                }
            }
        }

        private void DisplayInventory()
        {
            string[] slots = vendomatic.Slots;

            for (int i = 0; i < slots.Length; i++)
            {
                Console.WriteLine(slots[i] + " " + vendomatic.GetQuantityRemaining(slots[i]) + " " + vendomatic.GetItemAtSlot(slots[i]).Name + " " + vendomatic.GetItemAtSlot(slots[i]).Cost);
            }
        }

        private void DisplayPurchaseMenu()
        {
            while (true)
            {
                Console.WriteLine("Please Choose Below");
                Console.WriteLine("1) Feed Money");
                Console.WriteLine("2) Select Product");
                Console.WriteLine("3) Finish Transaction");
                string inputTwo = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                if (inputTwo == "1")
                {

                    Console.WriteLine("Please enter amount in 1's, 5's, 10's or 20's");
                    string money = Console.ReadLine();
                    decimal record = Convert.ToDecimal(money);
                    vendomatic.FeedMoney(int.Parse(money));

                    Console.WriteLine("Current balance is $" + vendomatic.CurrentBalance);
                    log.RecordDeposit(record, vendomatic.CurrentBalance);
                }
                else if (inputTwo == "2")
                {

                    Console.WriteLine("Enter selected product code");
                    string userSelection = Console.ReadLine();

                    try
                    {
                        ItemGeneral purchasedItem = vendomatic.Purchase(userSelection);

                        itemsBought.Add(purchasedItem);
                        Console.WriteLine($"Here is your {purchasedItem.Name} and current balance is " + vendomatic.CurrentBalance);
                        log.RecordPurchase(purchasedItem.Name, userSelection, vendomatic.CurrentBalance, vendomatic.CurrentBalance - purchasedItem.Cost);
                    }
                    catch (VendingMachineException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (inputTwo == "3")
                {
                    Change coins = vendomatic.ReturnChange();
                    log.RecordFinalChange(vendomatic.CurrentBalance);

                    for (int i = 0; i < itemsBought.Count; i++)
                    {
                        Console.WriteLine(itemsBought[i].Consume());
                    }
                    Console.WriteLine("Your money back is:");
                    Console.WriteLine("In Quarters " + coins.Quarters);
                    Console.WriteLine("In Dimes " + coins.Dimes);
                    Console.WriteLine("In Nickles " + coins.Nickels);

                    Console.WriteLine("Current Vendo Matic Balace is " + vendomatic.CurrentBalance);

                    break;
                }
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine("Good Day! It's the Vendo-Matic 500!");
        }

    }
}
