using System;
using System.Collections;
using System.Collections.Generic;

namespace Array
{
    class Program
    {
        // static is bounded with class name, not instance. non-static is with instance. static void main can onlt work with static members in the same class.
        static void Main(string[] args)
        {
            int[] vals = { 1,6,7,8};
            int[] another = new int[10];

            string[] strArr = new string[7];
            if (strArr[2] == "")
                Console.WriteLine("Empty String");
            else if (strArr[2] == null)
                Console.WriteLine("null");
            else
                Console.WriteLine("Unknown");

            string str1 = "", str2 = null;
            str1.ToLower();
            // str2.ToLower();

            int[] ids = { 2, 3, 8, 9, -2, 10 };
            // isd.Append(34）；

            // ArrayList -- System.Collections; LinkedList and List -- System.Collections.Generic.
            // ArrayList myList = new ArrayList();  // Everything derived from object.
            List<int> myList = new List<int>();     // Generic type, you can specify the type.
                                                    // LinkedList (have to be linear search for any item) and ArrayList are different than List (can locate any index directly)
      
            Console.WriteLine("Count = {0}, capacity = {1}", myList.Count, myList.Capacity);

            myList.Add(23);
            Console.WriteLine("Count = {0}, capacity = {1}", myList.Count, myList.Capacity);

            myList.Add(22);
            Console.WriteLine("Count = {0}, capacity = {1}", myList.Count, myList.Capacity);

            myList.Add(21);
            Console.WriteLine("Count = {0}, capacity = {1}", myList.Count, myList.Capacity);

            myList.Add(26);
            Console.WriteLine("Count = {0}, capacity = {1}", myList.Count, myList.Capacity);

            myList.Add(29);
            Console.WriteLine("Count = {0}, capacity = {1}", myList.Count, myList.Capacity);

            myList.Add(32);
            Console.WriteLine("Count = {0}, capacity = {1}", myList.Count, myList.Capacity);

            myList.Remove(23);
            Console.WriteLine("Count = {0}, capacity = {1}", myList.Count, myList.Capacity);

            Console.WriteLine(myList);

            // Creating instances of my type/class.
            MyArrayList myList1 = new MyArrayList();
            // MyArrayList myList2 = new MyArrayList();

            myList1.Add(23);
            Console.WriteLine("\nCount = {0}, capacity = {1}", myList1.Count, myList1.Capacity);

            myList1.Add(22);
            Console.WriteLine("Count = {0}, capacity = {1}", myList1.Count, myList1.Capacity);

            myList1.Add(21);
            Console.WriteLine("Count = {0}, capacity = {1}", myList1.Count, myList1.Capacity);

            myList1.Add(26);
            Console.WriteLine("Count = {0}, capacity = {1}", myList1.Count, myList1.Capacity);

            myList1.Add(29);
            Console.WriteLine("Count = {0}, capacity = {1}", myList1.Count, myList1.Capacity);

            myList1.Add(32);
            Console.WriteLine("Count = {0}, capacity = {1}", myList1.Count, myList1.Capacity);

            Console.WriteLine(myList1);

            // myList1.Remove(23);
            // Console.WriteLine("Count = {0}, capacity = {1}", myList.Count, myList.Capacity);
            // mylist1.Count = 7;
            // myList1.Count = myList.Count + 20;  
            // Console.WriteLine(myList1.Capacity);

        }
    }

    class MyArrayList
    {
        private int[] values;       // users can not access the data outside of this class. can be accessed in this class and any derived classes.
        private int capacity;
        private int count;

        
        // Creating properties:
        public int Count { get { return count; } }   // without set, we can not set/change the value in the main function.   (bank accounts)
        // public int Capacity { set { capacity = value; } } // without get, the user can no longer see the info. (password, customer survey)
        public int Capacity { get { return capacity; } set { if(value > 0) capacity = value; } }   
        // public int Capacity {  get;  private set; }   // private allows you to set value in this class but not the public to set/change the value.

        // Creating methods:
        public void Add(int value)  // cannot be accessed if it's private or protected.
        {
            if (Count == Capacity)
                Resize();
            values[Count] = value;
            count++;
        }

        public void Append(int value)  // cannot be accessed if it's private or protected.
        {
            Add(value);         // instead of copy and paste the same code, call the method. Reason: debug convinience and people's habbit of using Add()/Append().
        }

        private void Resize()
        {
            if (Capacity == 0)
            {
                values = new int[4];
                Capacity = 4;
            }
            else    // double the Capacity.
            {
                Capacity *= 2;
                // values = new int[Capacity] would not work because it will create a new one without all previous values.
                int[] oldValues = values;       // Keep track of old values.
                values = new int[Capacity];
                for (int i = 0; i < Count; i++) // Copy all values from the old block to the new block.
                {
                    values[i] = oldValues[i];
                }
            }
        }

        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < Count; i++)
            // foreach (int val in values)
                 ret = ret + " " + values[i];
            // Console.WriteLine(val);
            return ret;
        }

        // Creating constructor:
        public MyArrayList()        // No return type; Same name as the class. it can have parameters or methods.
        {
            // We do initializations here in constructors:
            values = new int[0];
            // Capacity = 0;
            // Count = 0;
        }
    }
}
