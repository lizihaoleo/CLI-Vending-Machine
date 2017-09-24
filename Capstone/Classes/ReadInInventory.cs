using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Capstone.Classes
{
    public class ReadInInventory
    {
        private string filePath;
       

        public ReadInInventory(string filePath)
        {

            string currentDirectory = Directory.GetCurrentDirectory();

            this.filePath = Path.Combine(currentDirectory,filePath);


        }
        


        Dictionary<string, List<ItemGeneral>> inventory = new Dictionary<string, List<ItemGeneral>>();
        

        public Dictionary<string, List<ItemGeneral>> GetInventory()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {

                    string thisLine = sr.ReadLine();
                    string[] temp = thisLine.Split('|');
                    List<ItemGeneral> list = new List<ItemGeneral>();


                    if (temp[0].Contains("A"))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            ChipsItem chips = new ChipsItem(temp[1], decimal.Parse(temp[2]));
                            list.Add(chips);

                        }

                    }

                    if (temp[0].Contains("B"))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            CandyItem candy = new CandyItem(temp[1], decimal.Parse(temp[2]));
                            list.Add(candy);

                        }

                    }

                    if (temp[0].Contains("C"))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            BeverageItem drink = new BeverageItem(temp[1], decimal.Parse(temp[2]));
                            list.Add(drink);

                        }

                    }


                    if (temp[0].Contains("D"))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            GumItem gum = new GumItem(temp[1], decimal.Parse(temp[2]));
                            list.Add(gum);

                        }

                    }


                    inventory[temp[0]] = list;
                    
                }

            }
            return inventory;
        }
    }
}
