using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private int dimes;
        private int nickles;
        private int quarters;
        private double totalChange;


        public int Dimes
        {
            get { return this.dimes; }
        }

        public int Nickels
        {
            get { return this.nickles; }
        }

        public int Quarters
        {
            get { return this.quarters; }
        }

        public double TotalChange
        {
            get { return this.totalChange; }
        }

        public Change(decimal amountInDollars)
        {
            this.totalChange = decimal.ToDouble(amountInDollars);
            while (amountInDollars >= .05M)
            {
                if (amountInDollars >= .25M)
                {
                    this.quarters++;
                    amountInDollars -= .25M;

                }
                else if(amountInDollars >= .10M)
                {
                    this.dimes++;
                    amountInDollars -= .10M;
                }
                else if(amountInDollars == .05M)
                {
                    this.nickles++;
                    amountInDollars -= .05M;
                }                              
            }
             
        }                
    }
}
