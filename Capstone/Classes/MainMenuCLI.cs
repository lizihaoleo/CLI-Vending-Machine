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
        public void Display()
        {
            PrintHeader();
            VendingMachine vendomatic = new VendingMachine();



            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Pick Yo Option");
                Console.WriteLine("1) Display Veding Machine items");
                Console.WriteLine("2) Purchase");
                string input = Console.ReadLine();
                string[] slots = vendomatic.Slots;
                decimal record = 0.00M;


                if (input == "1")
                {

                    for (int i = 0; i < slots.Length; i++)
                    {

                        Console.WriteLine(slots[i] + " " + vendomatic.GetQuantityRemaining(slots[i]) + " " + vendomatic.GetItemAtSlot(slots[i]).Name + " " + vendomatic.GetItemAtSlot(slots[i]).Cost);
                    }

                }
                else if (input == "2")
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
                            record = Convert.ToDecimal(money);
                            vendomatic.FeedMoney(int.Parse(money));
                            
                            Console.WriteLine("Current balance is $" + vendomatic.CurrentBalance);
                            log.RecordDeposit(record, vendomatic.CurrentBalance);


                        }
                        if (inputTwo == "2")
                        {

                            Console.WriteLine("Enter selected product code");
                            string userSelection = Console.ReadLine();

                            try
                            {
                                
                                if (!vendomatic.inventory.ContainsKey(userSelection)) 
                                    {
                                        throw new InvalidSlotSelectionException("That Slot does not exsit");

                                    }
                                

                            }
                            catch (InvalidSlotSelectionException ex)
                            {

                                Console.WriteLine(ex.Message);
                                Display();
                            }
                            try
                            {
                                for (int i = 0; i < slots.Length - 1; i++)
                                {
                                    if (vendomatic.GetQuantityRemaining(userSelection) == 0)
                                    {
                                        throw new OutOfStockException("There is nothing left at that slot");

                                    }
                                }
                            }
                            catch (OutOfStockException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Display();
                            }
                            try
                            {
                                    if (vendomatic.CurrentBalance < vendomatic.GetItemAtSlot(userSelection).Cost)
                                    {
                                        throw new InsufficientFundsException("Your currently do not have enough funds");
                                    }
                            }
                            catch (InsufficientFundsException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Display();
                            }
                            finally
                            {
                                itemsBought.Add(vendomatic.Purchase(userSelection));
                                Console.WriteLine("Here is your Item and current balance is " + vendomatic.CurrentBalance);
                                log.RecordPurchase(vendomatic.Purchase(userSelection).Name, userSelection, vendomatic.CurrentBalance, vendomatic.CurrentBalance - vendomatic.Purchase(userSelection).Cost);
                            }
                        }
                        if (inputTwo == "3")
                        {
                            Change coins = new Change(vendomatic.CurrentBalance);
                            log.RecordFinalChange(vendomatic.CurrentBalance);

                            for (int i = 0; i < itemsBought.Count; i++)
                            {
                                Console.WriteLine(itemsBought[i].Consume());
                            }
                            Console.WriteLine("Your money back is:");
                            Console.WriteLine("In Quarters " + coins.Quarters);
                            Console.WriteLine("In Dimes " + coins.Dimes);
                            Console.WriteLine("In Nickles " + coins.Nickels);
                            vendomatic.ReturnChange();
                            Console.WriteLine("Current Vendo Matic Balace is " + vendomatic.CurrentBalance);
                            

                        }



                    }
                }


            }


        }
        private void PrintHeader()
        {
            Console.WriteLine("Good Day! It's the Vendo-Matic 500!");
        }

    }
}
