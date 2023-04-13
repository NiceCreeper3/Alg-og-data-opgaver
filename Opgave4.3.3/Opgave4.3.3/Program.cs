using System;

namespace Opgave4._3._3
{
    class Program
    {
        /// <Opgave>
        /// Implementér en Fifo kø og en Lifo kø ved hjælp af dobbeltlinkede lister som du selv implementerer helt fra bunden.
        /// I begge datastrukturer skal der være metoder til indsættelse (push) og udtagelse (pop).
        /// 
        ///Lav et lille program til at teste dine køer, hvor du sætter en række tal ind i køen og derefter trækker dem ud.
        /// </Opgave>
        static void Main(string[] args)
        {
            bool programISActtive = true;

            // keaps the program running ontel you exit
            while (programISActtive)
            {
                Console.WriteLine(
                    "Please tip ind the nummber of what you want to do" +
                    "\n(1) Work as fifo kø" +
                    "\n(2) Work as lifo kø" +
                    "\n(0) Exit Program");

                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
            }


            //Linksite valus
            DoublLinkedList linkedList = new DoublLinkedList();
            linkedList.Append(5);
            linkedList.Append(6);
            linkedList.Append(1);
            linkedList.Append(8);
            linkedList.Append(2);
            linkedList.Append(7);
            linkedList.Append(345);

            //removes a node from the list
            DoubleLinkedListNode nodeToRemove = linkedList.tail;
            linkedList.RemoveNode(nodeToRemove);

            // afleser listen
            // lige nu lease den i om vent firke følge
            linkedList.PrintList();


            linkedList.PrintReverseList();


            //Tail
        }

        #region

        /// <summary>
        /// a linlist node aka how we hold informason
        /// it has a linke to det next and preaivs node. this makes it a double
        /// and a int kalede data
        /// 
        /// it also has a meafhod to make a node
        /// withe info
        /// </summary>
        class DoubleLinkedListNode
        {
            public DoubleLinkedListNode privies;
            public int data;
            public DoubleLinkedListNode next;

            public DoubleLinkedListNode(int x)
            {
                privies = null;
                data = x;
                next = null;
            }

            //Lazy<int>
        }

        /// <summary>
        /// this class is easental all the short hand meathods we use to do what we want to the Double link list
        /// </summary>
        class DoublLinkedList
        {
            public DoubleLinkedListNode head;
            public DoubleLinkedListNode tail;

            public DoublLinkedList()
            {
                head = null;
                tail = null;
            }

            public void Append(int data)
            {
                DoubleLinkedListNode newNode = new DoubleLinkedListNode(data);
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    newNode.privies = tail;
                    tail.next = newNode;
                    tail = newNode;
                }
            }

            #region Remove
            public void RemoveNode(DoubleLinkedListNode toRemove)
            {   
                // deturmens if we remove from the head or tail of the Linklist
                if (toRemove == null)
                {
                    // makes it so if there is nothing to remove 
                    return;
                } 
                if (toRemove == head) 
                {
                    head = head.next;
                    if (head != null)
                    {
                        head.privies = null;
                    }
                    else
                    {
                        tail = null;
                    }
                    return;
                }
                if (toRemove == tail)
                {
                    // moves the preavies node 
                    tail = tail.privies;
                    if (tail != null)
                    {
                        tail.next = null;
                    }
                    else
                    {
                        head = null;
                    }
                    return;
                }
                toRemove.privies.next = toRemove.next;
                toRemove.next.privies = toRemove.privies;
            }
            #endregion

            #region PrintLinkList
            public void PrintList()
            {
                DoubleLinkedListNode runner = head;
                while (runner != null)
                {
                    Console.Write(runner.data + " ");
                    runner = runner.next;
                }
                Console.WriteLine();
            }

            public void PrintReverseList()
            {
                DoubleLinkedListNode runner = tail;
                while (runner != null)
                {
                    Console.Write(runner.data + " ");
                    runner = runner.privies;
                }
                Console.WriteLine();
            }
            #endregion
        }
        #endregion
    }
}

