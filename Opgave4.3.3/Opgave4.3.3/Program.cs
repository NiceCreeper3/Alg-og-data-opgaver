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

        // avere double linkList
        static DoublLinkedList linkedList = new DoublLinkedList();

        static void Main(string[] args)
        {
            // over valus
            bool programISActtive = true;

            //Double link list valus
            linkedList.Append(5);
            linkedList.Append(6);
            linkedList.Append(1);
            linkedList.Append(8);
            linkedList.Append(2);
            linkedList.Append(7);
            linkedList.Append(345);

            try
            {
                while (programISActtive)
                {
                    // afleser listen
                    linkedList.PrintList();

                    Console.WriteLine(
                    "Please tip ind the nummber of what you want to do" +
                    "\n(1) Add new node" +
                    "\n(2) Remove node" +
                    "\n(Enig othere nummber) Exit Program");

                    int UserChois = int.Parse(Console.ReadLine());

                    if (UserChois == 1)
                    {
                        Console.WriteLine("wite the nummber you want to add");
                        int NewNode = int.Parse(Console.ReadLine());

                        linkedList.Append(NewNode);
                    }
                    else if (UserChois == 2)
                    {
                        RemoveMeathod();
                    }
                    else
                    {
                        programISActtive = false;
                    }
                }
                Console.Clear();            
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Fifo og Lifo meathods
        static void RemoveMeathod()
        {
            DoubleLinkedListNode nodeToRemove;

            Console.WriteLine(
                "Please tip ind the nummber of what you want to do" +
                "\n(1) Remove from front" +
                "\n(2) Remove from Bake" +
                "\n(Nothing) Exit Program");

            int FifokøOrLifokø = int.Parse(Console.ReadLine());

            // sees if the user wants to remove from the front
            if (FifokøOrLifokø == 1)
            {
                nodeToRemove = linkedList.head;
                linkedList.RemoveNode(nodeToRemove);
            }
            else if (FifokøOrLifokø == 2)
            {
                nodeToRemove = linkedList.tail;
                linkedList.RemoveNode(nodeToRemove);
            }
        }
        #endregion

        #region Double Linklist

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
        }

        /// <summary>
        /// this class is easental all the short hand meathods we use to do what we want to the Double link list
        /// suthe as remove add or printing avet the list
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
                    // makes it so if there is nothing to remove we do nothing
                    return;
                } 
                if (toRemove == head) 
                {
                    /// checks if the next ind row is null or not.
                    /// if it is it takes the 
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

                /// Removes the refrinsens to the node we are reamoving
                /// and moving them to the 
                toRemove.privies.next = toRemove.next;
                toRemove.next.privies = toRemove.privies;
            }
            #endregion

            /// <summary>
            /// Prints out the list
            /// it does this by printint from the ferst  
            /// and then goving fru its link to the next and reapid with this nod.
            /// and it keeps doving this ontil it reathes null
            /// </summary>
            public void PrintList()
            {
                DoubleLinkedListNode runner = head;
                while (runner != null)
                {
                    Console.Write(runner.data + " ");
                    // gets the next nummber
                    runner = runner.next;
                }
                Console.WriteLine();
            }

        }
        #endregion


    }
}

