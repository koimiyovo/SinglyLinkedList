using System;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkeList myList = new SinglyLinkeList();
            myList.AddFirst(3);
            myList.AddFirst(2);
            myList.AddFirst(1);
            myList.AddFirst(0);
            myList.DisplayList();   // 0 1 2 3
            Console.WriteLine($"Count = {myList.Count}\n");

            Console.WriteLine("Removing first node...");
            myList.RemoveFirst();
            myList.DisplayList();   // 1 2 3
            Console.WriteLine($"Count = {myList.Count}\n");

            Console.WriteLine("Adding in index 0...");
            myList.AddInIndex(0, 11);
            myList.DisplayList();   // 11 1 2 3
            Console.WriteLine($"Count = {myList.Count}\n");

            Console.WriteLine("Adding in index 2...");
            myList.AddInIndex(2, 69);
            myList.DisplayList();   // 11 1 69 2 3
            Console.WriteLine($"Count = {myList.Count}\n");

            Console.WriteLine("Removing last node...");
            myList.RemoveLast();
            myList.DisplayList();   // 11 1 69 2
            Console.WriteLine($"Count = {myList.Count}\n");

            Console.WriteLine("Removing at index 2...");
            myList.RemoveAtIndex(2);
            myList.DisplayList();   // 11 1 2
            Console.WriteLine($"Count = {myList.Count}\n");
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
        }

        public void DisplayNode()
        {
            Console.WriteLine($"<{ Data }>");
        }
    }

    public class SinglyLinkeList
    {
        public Node First { get; set; }

        // Check if the linked list is empty
        public bool IsEmpty()
        {
            return First == null;
        }

        public int Count
        {
            get
            {
                int i = 0;
                Node currentNode = First;
                while (currentNode != null)
                {
                    i++;
                    currentNode = currentNode.Next;
                }
                return i;
            }
        }

        // Add value at the beginning of the linked list
        public void AddFirst(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = First;
            First = newNode;
        }

        public Node RemoveFirst()
        {
            Node temp = First;
            First = First.Next;
            return temp;
        }

        public void AddLast(int value)
        {
            Node currentNode = First;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            Node newNode = new Node(value);
            currentNode.Next = newNode;
        }

        public void RemoveLast()
        {
            Node currentNode = First;
            while (currentNode.Next.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = null;
        }

        public void AddInIndex(int index, int value)
        {
            if (index >= 0 && index < this.Count)
            {
                if (index == 0)
                {
                    AddFirst(value);
                }
                else if (index == this.Count - 1)
                {
                    AddLast(value);
                }
                else
                {
                    Node currentNode = First;
                    int cpt = 0;
                    while (cpt < index-1)
                    {
                        currentNode = currentNode.Next;
                        cpt++;
                    }
                    Node newNode = new Node(value);
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;
                }
            }
            else
            {
                Console.WriteLine("Impossible to add : Index out of range");
            }
        }

        public void RemoveAtIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                if (index == 0)
                {
                    RemoveFirst();
                }
                else if (index == this.Count-1)
                {
                    RemoveLast();
                }
                else
                {
                    Node currentNode = First;
                    int cpt = 0;
                    while (cpt < index-1)
                    {
                        currentNode = currentNode.Next;
                        cpt++;
                    }
                    currentNode.Next = currentNode.Next.Next;
                }
            }
            else
            {
                Console.WriteLine("Impossible to remove : Index out of range");
            }
        }

        public void DisplayList()
        {
            Console.WriteLine("Displaying List (First -> Last)");
            Node currentNode = First;
            while (currentNode != null)
            {
                currentNode.DisplayNode();
                currentNode = currentNode.Next;
            }
        }
    }
}
