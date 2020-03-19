using System;
using System.IO; // StreamReader
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouLinkedList_Stack_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList2<int> myList = new LinkedList2<int>();
            myList.AddFirst(1);
            myList.AddFirst(2);
            myList.AddFirst(3);
            // WriteLine called the .ToString method for us.
            Console.WriteLine(myList); // we override the ToString method.

            var myStack = new Stack<string>();
            myStack.Push(" Zhang");
            myStack.Push(" Xingyi");
            myStack.Push(" is");
            myStack.Push(" name");
            myStack.Push("My");
            Console.WriteLine(myStack);

            // Use stack to reverse a list of text from input file.
            StreamReader inFile = new StreamReader("input.txt");
            var myStack2 = new Stack<string>();
            string line = inFile.ReadLine();
            while (line != null)
            {
                myStack2.Push(line);
                line = inFile.ReadLine();
            }
            Console.WriteLine(myStack2);
            inFile.Close();
            /*
            StreamWriter outFile = new StreamWriter("output.txt");
            while (myStack2.Peek() != null)
            {
                outFile.WriteLine(myStack2.Pop());
            }
            outFile.Close();
            */

            //var myQueue = new Queue<string>();
            //myQueue.Enqueue("My ");
            //myQueue.Enqueue("name ");
            //myQueue.Enqueue("is ");
            //myQueue.Enqueue("Xingyi ");
            //myQueue.Enqueue("Zhang");
            //Console.WriteLine(myQueue);

            var myQueue = new Queue();
            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);
            myQueue.Enqueue(40);
            myQueue.Enqueue(50);
            myQueue.Enqueue(60);
            myQueue.Dequeue();
            Console.WriteLine(myQueue);
        }
    }
    class LinkedList2<T> : LinkedList<T>
    {
        public override string ToString()
        {
            string ret = "";
            //foreach (var value in this)
            //{
            //    ret += value + " ";
            //}
            ret = string.Join(", ", this);
            return ret;
        }
    }

    class Stack<T> // where T: class => can validate T return null; however, int would be an invalid Stack parameter.
    {                                                               
        // Data                                                     
        LinkedList<T> allVals;                                      
                                                                    
        // Methods                          
        public T Peek()
        {
            // Need to FIND A WAY TO MAKE NULL VALID.

            //if (allVals.Count > 0) return allVals.First();
            //else return null;
            return allVals.First();
        }

        public void Push(T value)
        {
            allVals.AddFirst(value);
        }
        public T Pop() // remove the top item.
        {
            if (allVals.Count > 0)
            {
                T first = Peek();
                allVals.RemoveFirst();
                return first;
            }
            else
            {
                throw new Exception("The stack is empty.");
            }
        }
        // Constructor
        public Stack()
        {
            allVals = new LinkedList<T>();
        }
        public override string ToString()
        {
            string res = "";
            while (allVals.Count > 0)
            {
                res += Pop();
            }
            return res;
        }

    }

    class Queue
    {
        LinkedList<int> qVals;
        public void Enqueue(int val)
        {
            qVals.AddFirst(val);
        }
        public int Dequeue()
        {
            int lastVal = Peek();
            qVals.Remove(lastVal);
            return lastVal;
        }
        public int Peek()
        {
            return qVals.Last();
        }

        public Queue()
        {
            qVals = new LinkedList<int>();
        }

        public override string ToString()
        {
            string res = "";
            foreach (var val in qVals)
            {
                res += val + " ";
            }
            return res;
        }
    }
}
