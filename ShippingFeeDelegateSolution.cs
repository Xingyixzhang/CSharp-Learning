using System;
using System.Collections.Generic;
using System.Text;

/* Instruction:
 * Given a destination and item price, calculate the shipping fee.
   Shipping fees are % of given item price + additional risk fee $20 for certain places.
 * Zone         Details
 *  1             25%
 *  2             12% + risk fee
 *  3             8%
 *  4             4% + risk fee
*/
namespace ShippingFee
{
    public delegate void ShippingFeeDelegate(Decimal thePrice, ref decimal fee);

    abstract class ShippingDestination
    {
        public bool m_isHighRisk;
        public virtual void calcFees(decimal price, ref decimal fee) { }

        public static ShippingDestination getDestinationInfo(string dest)
        {
            switch (dest)
            {
                case "zone1": return new Dest_Zone1();
                case "zone2": return new Dest_Zone2();
                case "zone3": return new Dest_Zone3();
                case "zone4": return new Dest_Zone4();
                default: return null;
            }
        }
    }

    class Dest_Zone1 : ShippingDestination
    {
        public Dest_Zone1()
        {
            this.m_isHighRisk = false;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.25m;
        }
    }
    class Dest_Zone2 : ShippingDestination
    {
        public Dest_Zone2()
        {
            this.m_isHighRisk = true;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.12m;
        }
    }
    class Dest_Zone3 : ShippingDestination
    {
        public Dest_Zone3()
        {
            this.m_isHighRisk = false;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.08m;
        }
    }
    class Dest_Zone4 : ShippingDestination
    {
        public Dest_Zone4()
        {
            this.m_isHighRisk = true;
        }
        public override void calcFees(decimal price, ref decimal fee)
        {
            fee = price * 0.04m;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ShippingFeeDelegate theDel;
            ShippingDestination theDest;

            string theZone;
            do
            {
                Console.WriteLine("What zone number is the destination in?");
                theZone = Console.ReadLine();

                if (!theZone.Equals("exit"))
                {
                    theDest = ShippingDestination.getDestinationInfo(theZone);
                    if (theDest != null)
                    {
                        Console.WriteLine("What is the item price?");
                        string thePriceStr = Console.ReadLine();
                        decimal itemPrice = decimal.Parse(thePriceStr);

                        theDel = theDest.calcFees;
                        if (theDest.m_isHighRisk)
                        {
                            theDel += delegate (decimal thePrice, ref decimal itemFee)
                            {
                                itemFee += 25.0m;
                            };
                        }

                        decimal theFee = 0.0m;
                        theDel(itemPrice, ref theFee);
                        Console.WriteLine("The shipping fees are: {0}", theFee);
                    }
                    else
                    {
                        Console.WriteLine("Hmm, you seem to have entered an invalid zone.");
                    }
                }
            } while (theZone != "exit");

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadKey();
        }
    }
}
