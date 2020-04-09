using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitWise
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * int x = 7
             * 
             * int uses 4 bytes:
             * -------- -------- -------- --------  // what 4 bytes hold.
             * 00000000 00000000 00000000 00000111  // 7
             * 
             * start with 0: num is positive; 
             * start with 1: num is negative.
             * 
             * 00000000 00000000 00000000 00001101  // 13
             * 11111111 11111111 11111111 11110010  // Flip the 13 (One Complement)
             * 11111111 11111111 11111111 11110011  // -13 (Two's Complement)
             * 
             * 
             *          Take 13 and -13:
             *  00000000 00000000 00000000 00001101
             *  11111111 11111111 11111111 11110011
             *          Plus them together:
             * 100000000 00000000 00000000 00000000  // 0
             * 
             * 
             * --- => 2*2*2 = 8 
             * 000 = 0      001 = 1     010 = 2     011 = 3
             * 111 = -1     110 = -2    101 = -3    100 = -4
             * Explanation:
             * 1. start with 0: positive; start with 1: negative
             * 2. 100 = 011 + 1 = 100 -> 4 --> -4
             * 3. 101 = 010 + 1 = 011 -> 3 --> -3
             * 4. 110 = 001 + 1 = 010 -> 2 --> -2
             * 5. 111 = 000 + 1 = 001 -> 1 --> -1
             * 
             * 
             * >> right shift (division of 2)
             * x = (base 10) 5 = (base 2) 100 = 
             * 00000000 00000000 00000000 00000101 (stored as int)
             * x >> 1:
             * 00000000 00000000 00000000 00000010 = (base 10) 2
             * x (with the value of 5) >> 2: 
             * 00000000 00000000 00000000 00000001 = (base 10) 1
             * 
             * 
             * << left shift (multiplication of 2)
             * x = (base 10) 5 = (base 2) 100 = 
             * 00000000 00000000 00000000 00000101 (stored as int)
             * x << 1:
             * 00000000 00000000 00000000 00001010 = (base 10) 10
             * x (with the value of 5) << 2: 
             * 00000000 00000000 00000000 00010100 = (base 10) 20
             * 
             * 
             * WHY SHIFT instead of MATH:
             * The Math algorithm takes more behind the scene, SHIFT makes the calculation way more efficient.
             * */
            int x = 7;
            Console.WriteLine(x << 1);  // 7 * 2 = 14
            Console.WriteLine(x << 3);  // 7 * 2 * 2 * 2 = 56

            int y = 56;
            Console.WriteLine(y >> 1);  // 56 / 2 = 28
            Console.WriteLine(y >> 3);  // 56 / 2 / 2 / 2 = 7

            int z = 0x13FA;             // 0x indicates that the num is written in Hex (base 16)
            Console.WriteLine(z);

            int num = 2020;
            Console.WriteLine(Convert.ToString(num, 2));    // Convert a base 10 int to a Binary number.

            int num1 = num * 2;
            Console.WriteLine(Convert.ToString(num1, 2));   // Examine the result and see the shift to the left.


            int number1 = 0b00000000_00000000_00100000_11001011;    // 0b indicates that the num is written in Binary
            int number2 = 0b00000000_10010010_00100100_10001001;

            /*
             * Logical Operator (&&, ||, !   0: false; 1: true):
             * x && y: Both has to be true for this statement to be true
             * x || y: Either one correct makes this statement true (Inclusive OR)
             * 
             * Bitwise Operator:
             * number1 & number2:
             * 0b00000000_00000000_00100000_10001001
             * 
             * number1 | number2
             * 0b00000000_10010010_00100100_11001011
             * 
             * XOR (^): Exclusive OR:
             * Both correct/wrong  => false
             * One of them correct => true
             */
            Console.WriteLine("\nDisplay num1 and num2:");
            Console.WriteLine(Convert.ToString(number1, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(number2, 2).PadLeft(32, '0'));
            Console.WriteLine("\nBitwise Operator AND (&), the Base 10 Value is: {0}", number1 & number2);
            Console.WriteLine(Convert.ToString(number1, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(number2, 2).PadLeft(32, '0') + "\n");

            Console.WriteLine(Convert.ToString(number1 & number2, 2).PadLeft(32, '0')); // Padleft here allows the zeros on the left to show.
            Console.WriteLine("\nBitwise Operator OR (|), the Base 10 Value is: {0}", number1 | number2);
            Console.WriteLine(Convert.ToString(number1, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(number2, 2).PadLeft(32, '0') + "\n");

            Console.WriteLine(Convert.ToString(number1 | number2, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(number1, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(number2, 2).PadLeft(32, '0') + "\n");

            Console.WriteLine("\nBitwise Operator XOR (^), the Base 10 Value is: {0}", number1 ^ number2);
            Console.WriteLine(Convert.ToString(number1 ^ number2, 2).PadLeft(32, '0'));

            int m = 5;
            int n = 808920;
            Console.WriteLine("\nBitwise XOR - Exclusive OR");
            Console.WriteLine((m ^ n) ^ n);     // return m
            /*
             * Tricks in the Math:
             * n1 ^ n1 = 0
             * 0 ^ n1 = n1
             */

            int[] arr = { 6, 2, 1, 3, 1, 3, 2, 10, 6 };
            // Find the Unique Value:   
            /*
             * Solution 1: check each value if it has duplicate --> O(n^2)
             * Solution 2: Merge Sort --> O(nlog(n))
             * Solution 3: XOR --> O(n)
             */
            int unique = 0;
            foreach (int val in arr)    unique = unique ^ val;
            Console.WriteLine($"\nThe unique number in the array is: {unique}");

            Console.Read();
        }
    }
}
