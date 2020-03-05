using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] arr = { 1, 3, 5, 7, 9 };
            // arr.add
            // Node n1;    // this is just a pointer.
            // Node n2 = new Node(); // n2 is an object/ instance of Node.
            Node n1 = new Node(7);
            Node n2 = new Node(3);
            n2.Next = n1;

            SinglyLinkedList myList = new SinglyLinkedList();
            myList.Print();
            // LinkedList<int> myList2 = new LinkedList<int>();
            myList.AddFirst(4);
            myList.AddFirst(7);
            myList.AddFirst(5);
            myList.Print();
            myList.AddLast(2);
            myList.AddLast(9);
            myList.AddLast(3);
            myList.Append(-1);
            myList.Print();
            myList.DeleteFirst();
            myList.Print();
            myList.DeleteFirst();
            myList.Print();
            myList.DeleteFirst();
            myList.Print();
            myList.DeleteLast();
            myList.Print();
            myList.Insert(-9, 1);
            myList.Print();
            myList.Delete(2);
            myList.Print();
        }
        class Node
        {
            // to store:
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node(int val)
            {
                Value = val;
            }
        }

        class SinglyLinkedList
        {
            // Data
            Node head;

            // behavior:
            //  * AddFirst
            public void AddFirst(int val)
            {
                Node newNode = new Node(val);
                newNode.Next = head;
                head = newNode;
            }
            //  * AddLast / Append
            public void Append(int val)
            {
                AddLast(val); // Call the other instead of copy and paste.
            }
            public void AddLast(int val)
            {
                if (head == null) { AddFirst(val); return; } // use return to end the function.
                Node newNode = new Node(val);
                Node finger = head;
                while (finger.Next != null) finger = finger.Next;
                finger.Next = newNode;
            }
            //  * DeleteFirst
            public void DeleteFirst()
            {
                if (head == null) { throw new Exception("List is empty"); return; }
                if (head.Next == null) { head = null; return; }
                head = head.Next;
            }
            //  * DeleteLast
            public void DeleteLast()
            {
                if (head == null) throw new Exception("List is empty");
                else if (head.Next == null) head = null;
                else
                {
                    Node finger = head;
                    while (finger.Next.Next != null) finger = finger.Next;
                    finger.Next = null;
                }
            }
            //  * Insert
            public void Insert(int val, int index)
            {
                if (index == 0 && head == null) { AddFirst(val); return; }
                Node newNode = new Node(val);
                Node finger = head;
                for (int pos = 0; finger.Next != null && pos < index - 1; pos++)
                {
                    if (finger == null)
                    {
                        Console.WriteLine("error"); return;
                    }
                    finger = finger.Next;
                }
                newNode.Next = finger.Next;
                finger.Next = newNode;
            }
            //  * Delete
            public void Delete(int idx)
            {
                if (idx < 0) return;
                if (idx == 0) DeleteFirst();
                else
                {
                    Node finger = head;
                    for (int pos = 0; pos < idx - 1; pos++)
                    {
                        if (finger == null)
                        {
                            Console.WriteLine("error");
                            return;
                        }
                        finger = finger.Next;
                    }
                    if (finger.Next != null && finger != null)
                        finger.Next = finger.Next.Next;
                    else Console.WriteLine("error2");
                }
            }
            //  * Print / traverse
            public void Print()     // static is the opposite of instance, do not use here.
            {
                if (head == null) Console.Write("The list is empty.");
                else
                {
                    Node finger = head;
                    while(finger != null)
                    {
                        Console.Write(finger.Value + " ");
                        finger = finger.Next;
                    }
                }
                Console.WriteLine();
            }

            public SinglyLinkedList()
            {
                // head = null;
            }
        }
    }
}
