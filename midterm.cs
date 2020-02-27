// https://docs.microsoft.com/en-us/dotnet/api/system?view=netframework-4.8
using System;
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=netframework-4.8
using System.Collections.Generic;
// https://docs.microsoft.com/en-us/dotnet/api/system.text?view=netframework-4.8
using System.Text;

namespace MidTerm
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Namespace #1: the System namespace contains fundamental classes and base classes that define commonly-used
                           value and reference data types, events, and event handlers, interfaces, attributes, and processing exceptions.
            */

            // Function #1: System.Math.Round(Double)/(Double, Int32)
            // Description: System.Math.Round provides can round an double to the
            //              nearest integer or specified fractional digits.
            double a = 34.798;
            double b = Math.Round(a);   // Rounds a to the nearest integer value.
            double c = Math.Round(a, 2);// Rounds a to a 2 fractional digits value.

            Console.WriteLine("Original Number: {0}, after rounding: {1}\n" +
                              "Round {2} to 2 fractional digits: {3}", a, b, a, c);
            Console.WriteLine("\nPress <Enter> to next method.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #2: System.Array.GetValue(Int32)
            // Description: Gets the value at the specified position in an array.
            //             The index is specified as a 32-bit integer.

            int[] myArray = new int[] { 1, 2, 3, 4, 5, 6 };    // Create a new array.
            Console.WriteLine("The array.GetValue(3) will return {0}.", myArray.GetValue(3)); //This will print out 4, since 4 is at the 3rd index in myArray.
            Console.WriteLine("\nPress <Enter> to next method.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #3: System.Array.CopyTo(Array, Int32)
            // Description: Copies all elements of the current 1D array to the specified
            //              1D array starting at the speficied destination array index.

            try
            {
                int[] myArray1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
                myArray.CopyTo(myArray1,1);
                Console.WriteLine(myArray1.GetValue(6)); // Instead of 7, this will 
                // print out 3, since myArray has replaced myArray1 starting from the 
                // number 9, which is the index of 1.
                // That means, the new myArray1 => 10,1,2,3,4,5,6,3,2,1.
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The target array is null.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Index is less than the lower bound of target array.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The target array is multi-dimensional.");
            // Or the number of elements in the source array is greater than the available
            // number of elements from index to the end of the destination array.
            }
            finally
            {
                Console.WriteLine("Error.");
            }

            // Function #4: System.Console.ReadKey()
            // Description: Obtains the next character of function key pressed by the user.
            //              one of the most common use of this method is to halt program execution until the user 
            //              presses a key and the app either terminates pr displays an additional 
            //              window of information.

            Console.WriteLine("\nPress <Enter> to exit the while loop.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #5: System.Convert.ChangeType(Object, Type)
            // Description: Returns an object of the specified type and whose value is 
            //              equivalent to the specified object

            double x = -2.745;
            int y = (int)Convert.ChangeType(x, typeof(int));    // To the nearest integer.
            Console.WriteLine("\nThe double value {0} when converted to an integer, " +
                              "becomes {1}", x, y);
            string s = "12/12/98";
            DateTime myDateAndTime = (DateTime)Convert.ChangeType(s, typeof(DateTime));
            Console.WriteLine("The string value {0} when converted to a Date " +
                              "becomes {1}", s, myDateAndTime);
            Console.WriteLine("Press <Enter> to next namespace.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            /* 
             * Namespace #2: System.Collections.Generic
             * Description: Contains interfaces and classes that define generic collections,
             *              allowing users to create strongly-typed collections that provide
             *              better Type Safety and performance than non-generic strongly-typed
             *              collections.
            */

            // Function #1: List<T>.Remove* methods
            /* Description: Remove(T item) -- to remove the first occurrence of the item from the list. item can be null for reference types.
             *              RemoveAll(Predicate<T> match) -- Remove all elements that match the conditions defined by the specified predicate.
             *              RemoveAt(index) -- Remove the element at the specific index of the list.
             *              RemoveRange(startingIndex, #of elements to remove)
             */

            // Create a list containing different types of dinosaurs.
            List<string> dinos = new List<string>();

            // Adding elements in the list.
            dinos.Add("T-rex");
            dinos.Add("Amarga");
            dinos.Add("Mamenchi");
            dinos.Add("deinonychus");
            dinos.Add("myDinosaur");
            dinos.Add("yourDinosaur");
            dinos.Add("RandomDino");
            dinos.Add("Hisdinosaur");
            DisplayDinos(dinos);

            dinos.Remove("T-rex");
            DisplayDinos(dinos);
            dinos.RemoveAt(2);  // remove "deinonychus"
            DisplayDinos(dinos);
            dinos.RemoveRange(0, 2);    // remove Amarga and Mamenchi.
            DisplayDinos(dinos);
            dinos.RemoveAll(EndsWithDinosaur);  // remove all names ending with dinosaurs.
            DisplayDinos(dinos);
            Console.WriteLine("\nPress <Enter> to next method.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #2: LinkedList<T>.Add* methods
            /* Description: AddAfter  (with 2 overloads) AddAfter(LinkedListNode<T>, LinkedListNode<T> || T)
             *              AddBefore (with 2 overloads) AddBefore(LinkedListNode<T>, LinkedListNode<T> || T)
             *              AddFirst  (with 2 overloads) AddFirst(LinkedListNode<T> || T)
             *              AddLast   (with 2 overloads) AddLast(LinkedListNode<T> || T)
             */

            LinkedList<int> integers = new LinkedList<int>();
            integers.AddFirst(12);
            integers.AddFirst(-2);
            integers.AddLast(89);   
            integers.AddLast(3);
            integers.AddLast(4);
            integers.AddFirst(3);   // 3, -2, 12, 89, 3, 4
            DisplayLinkedlist(integers);
            // Declare the LinkedlinstNode<T> node.
            LinkedListNode<int> node = integers.Find(3);    // Find the first 3 in LinkedList.
            integers.AddBefore(node, -23);
            node = integers.FindLast(3);                    // Find the last 3
            integers.AddBefore(node, -5);   // -23, 3, -2, 12, 89, -5, 3, 4
            integers.AddAfter(node, 43);
            node = integers.Find(89);
            integers.AddAfter(node, 11);    // -23, 3, -2, 12, 89, 11, -5, 3, 43, 4
            DisplayLinkedlist(integers);
            Console.WriteLine("\nPress <Enter> to next method.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #3: LinkedList<T>.Remove* methods
            /* Description: Remove      -- remove the specific node.
             *              RemoveFirst -- removes the node at the start of the LinkedList.
             *              RemoveLast  -- removes the node at the end of the LinkedList.
             *              Clear       -- removes all nodes from the LinkedList.
             */
            integers.RemoveFirst();
            integers.RemoveLast();
            integers.Remove(89);    // 3, -2, 12, 11, -5, 3, 43
            DisplayLinkedlist(integers);
            Console.WriteLine("\nPress <Enter> to next method.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #4: Dictionary<TKey, TValue> common methods
            /* Description: Remove -- (With 2 overloads) Remove(TKey); Remove(TKey, TValue)
             *              TryAdd(TKey key, TValue value)  returns bool value if it's addded successfully.
             *              ContainsKey/ ContainsValue
             *              Clear()
             *              TrimExcess() -- Sets the capacity of this dict to what it would be if it had been originally initialized with all its entries.
             *              TrimExcess(Int32) -- Sets the capacity of this dictionary to hold up a specified number of entries without any further expansion of its backing storage.
             */

            Dictionary<string, int> scores = new Dictionary<string, int>();
            scores.Add("Amy", 76);
            scores.Add("George", 83);
            scores.Add("Lily", 69);
            scores.Add("Jimmy", 99);
            scores.TryAdd("Stanley", 96);
            scores.Add("Lacy", 77);
            scores.TryAdd("Zach", 86);
            scores.Add("Sam", 90);
            scores.Add("Cody", 73);
            DisplayDict(scores);

            scores.TrimExcess(9);
            scores.Remove("Sam");   // & with both paras, returns a bool if the element is removed or not. 
            scores.Remove("Jimmy", out int value);
            if (scores.ContainsKey("Lily")) scores["Lily"] = 78;
            DisplayDict(scores);

            scores.Clear();
            DisplayDict(scores);
            Console.WriteLine("Oops, you've cleared you dictionary...\n");
            Console.WriteLine("\nPress <Enter> to next method.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #5: KeyValuePair<TKey, TValue>, methods: ToString
            // Description: Returns a string representation of the KeyValuePair<TKey, TValue>

            var pair = new KeyValuePair<string, int>("Bird", 10);
            string result = pair.ToString();
            Console.WriteLine($"\nToString: {result}\nToUpper: {result.ToUpper()}\n");
            Console.WriteLine("\nPress <Enter> to next namespace.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            /* 
             * Namespace #3: System.Text
             * Description: Contains classes representing ASCII and Unicode char encodings.
            */

            // Function #1: StringBuilder class, Append methods
            // Description: Passes values to the end of the current StringBuilder object.

            // StringBuilder sb = new StringBuilder(50);
            StringBuilder sb = new StringBuilder("Hello ", 50);

            sb.Append("World!!");
            sb.AppendLine("Hello C#");
            sb.AppendLine("This is new line.");

            Console.WriteLine(sb);
            Console.WriteLine("\nPress <Enter> to next method.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #2: StringBuilder class, Insert method
            // Description: Inserts the string at specified index in StringBuilder.

            sb.Insert(5, " C#");
            Console.WriteLine(sb);

            // Function #3: StringBuilder class, Replace method
            // Description: 

            sb.Replace("World", "C#");
            Console.WriteLine(sb);
            Console.WriteLine("\nPress <Enter> to next method.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #4: Encoding class, GetBytes method
            // Description: Returns type Byte[], A byte array containing 
            //              the results of encoding the specified set of characters.

            byte[] abData;
            string Str;
            int i;
            Str = "Hello world!";
            // Convert string to bytes
            abData = Encoding.Default.GetBytes(Str);
            Console.WriteLine("Encoding string to bytes: ");
            for (i = 0; i < abData.Length; i++)
            {
                Console.Write("{0:X}  ", abData[i]);
            }
            Console.WriteLine("\nPress <Enter> to next method.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("\tWrong key, please press <Enter> to exit.");
            }

            // Function #5: Encoding class, GetString(Byte[]) method
            // Description: Returns a string that contains the results of decoding the specified sequence of bytes.

            // Convert bytes to string
            Str = Encoding.Default.GetString(abData);
            Console.WriteLine("\n'{0}'", Str);
        }
        private static bool EndsWithDinosaur(string s)
        {
            return s.ToLower().EndsWith("dinosaur");
        }

        public static void DisplayDinos(List<string> dinos)
        {
            Console.WriteLine();
            foreach (string dino in dinos)
            {
                // Display the dinos list.
                Console.WriteLine($"Dinosaur: {dino} \tCapacity: {dinos.Capacity}\tCount: {dinos.Count}");
                // List.Count: # of elements present in the list.
                // List.Capacity: # of elements the List can store, until resizing of list needed.
            }
        }
        public static void DisplayLinkedlist(LinkedList<int> nums)
        {
            Console.WriteLine();
            Console.WriteLine($"Linkedlist Count: {nums.Count}");
            foreach (int num in nums)
            {
                Console.Write($"{num}  ");
            }
            Console.WriteLine();
        }
        public static void DisplayDict(Dictionary<string, int> dict)
        {
            Console.WriteLine();
            Console.WriteLine("Displaying your Dictionary:");
            foreach (KeyValuePair<string, int> item in dict)
            {
                Console.WriteLine($"Key = {item.Key}, Value = {item.Value}");
            }
        }
    }
}

/* Function: DataTable.NewRow    (under System.Data namespace)
// Description: Creates (and returns) a new DataRow with the same schema as the table..
// Reference: https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable.newrow?view=netframework-4.8

DataTable table = new DataTable();

DataColumn column;
DataRow row;
DataView view;

// Create new DataColumn, set DataType, Column name, and add to data table.
column = new DataColumn();
column.DataType = System.Type.GetType("System.Int32");
column.ColumnName = "ID";
table.Columns.Add(column);

// Create second column.
column = new DataColumn();
column.DataType = System.Type.GetType("System.String");
column.ColumnName = "Item";
table.Columns.Add(column);

// Create new DataRow objects and add to DataTable.
for (int i = 0; i < 10; i++)
{
    row = table.NewRow();
    row["ID"] = i;
    row["Item"] = "item " + i.ToString();
    table.Rows.Add(row);
}

// Create a DataView using the DataTable.
view = new DataView(table);
*/

