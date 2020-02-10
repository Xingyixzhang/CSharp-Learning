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
    public delegate void MyDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            bool more = true;
            while (more)
            {
int             zone = Zone();
                double price = Price();
                Console.WriteLine("The shipping fees are: {0}\nMore item checks? (y/n)\t", Fee(price, zone));
                if (Console.ReadLine() == "n") more = false;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadKey();
        }
        static int Zone()
        {
            int zone;

            try
            {
                Console.WriteLine("What zone number is the destination?\n" +
                                  "Notice that if you type any number besides 1,2,3,4 " +
                                  "your result will be set to default 0.");
                zone = int.Parse(Console.ReadLine());
            }
            catch { zone = 0; Console.WriteLine("Error reading the zone number."); }

            return zone;
        }

        static double Price()
        {
            double price;

            try
            {
                Console.WriteLine("What is the item price?");
                price = double.Parse(Console.ReadLine());
            }
            catch { price = 0; Console.WriteLine("Error reading the item price."); }

            return price;
        }
        static double Fee(double price, int zone)
        {
            switch (zone)
            {
                case 1:     return (price * 0.25);
                case 2:     return (price * 0.12 + 25.00);
                case 3:     return (price * 0.08);
                case 4:     return (price * 0.04 + 25.00);
                default:    return 0.00;
            }
        }
    }
}
