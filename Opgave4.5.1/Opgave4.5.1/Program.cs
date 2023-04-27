using System;

namespace Opgave4._5._1
{
    class Program
    {
        /// <Opgaver>
        /// <4.5.3> /
        /// Implementér et søgetræ. 
        /// Søgetræet skal have funktioner til søgning, til indsættelse og til sletning.
        /// Sletning er lidt kompliceret og kan eventuelt springes over.
        /// 
        /// <4.5.4> / toro jeg
        /// Hvis man gerne vil have udskrevet elementerne i et søgetræ i sorteret orden,
        /// kan man gennemløbe træet sådan at man først udskriver det venstre undertræ, 
        /// så det aktuelle element og derefter udskriver højre undertræ.
        /// Dette kan med fordel implementeres ved hjælp af rekursion.
        /// 
        /// <4.5.5>
        /// Det kan være lidt svært at sikre sig at søgetræet virker i alle tilfælde.
        /// Ved at implementere nedenstående kode til aftestning, kommer man godt rundt i alle hjørner af søgetræet.
        ///</Opgaver>
        static void Main(string[] args) 
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(7);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(7);
            binaryTree.Add(5);
            binaryTree.Add(8);

            // Findes a nummber and then can print ithere its oven data or the data of its children by RightNode.Data or LeftNode.Data
            Node node = binaryTree.Find(5);
            Console.WriteLine(node.Data);

            Console.WriteLine("PreOrder Traversal:");
            binaryTree.TraversePreOrder(binaryTree.Root);


            Console.WriteLine("\nInOrder Traversal:");
            binaryTree.TraverseInOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal:");
            binaryTree.TraversePostOrder(binaryTree.Root);
            Console.WriteLine();

            binaryTree.Remove(7);
            binaryTree.Remove(8);

            Console.WriteLine("PreOrder Traversal After Removing Operation:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();
        }


        // Binary tree
        #region
        class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public int Data { get; set; }
        }
        class BinaryTree
        {
            // All other methodes
            #region
            public Node Root { get; set; }

            //the method caller
            #region 
            public bool Add(int value)
            {
                Node before = null, after = this.Root;

                /// Skipes if therer is no other node ind the tree
                /// but if therer is nodes then it beagins by saving the posison det new node shode haves rigtht now ind the before value
                /// then it cheks if det newNode is bigger or smaller and then moves the vere it checks 
                /// and then reapid on tel it kant finde a node bigger or smaller 
                while (after != null)
                {
                    // saves its kurent positon
                    before = after;

                    // checks if
                    if (value < after.Data) //Is new node in left tree? 
                        after = after.LeftNode;
                    else if (value >= after.Data) //Is new node in right tree?
                        after = after.RightNode;
                    else
                    {
                        //Exist same value
                        return false;
                    }
                }

                // gives over new node a value
                Node newNode = new Node();
                newNode.Data = value;

                // if the Tree is emtig it then it makes the new node the root node
                if (this.Root == null)//Tree ise empty
                    this.Root = newNode;
                else
                {
                    // then depending on if it is smaller or lager then the parant node. the newNode goves ithere left or right
                    if (value < before.Data)
                        before.LeftNode = newNode;
                    else
                        before.RightNode = newNode;
                }

                return true;
            }

            public Node Find(int value)
            {
                return this.Find(value, this.Root);
            }

            public void Remove(int value)
            {
                this.Root = Remove(this.Root, value);
            }
            #endregion

            private Node Remove(Node parent, int key)
            {
                /// returns parant if the nummber we are looking for does not exist
                /// we know this by the fakt that if we reathe a point.
                /// where we are at a lief node and the data nummber is stil not the same
                if (parent == null) return parent;

                //lookes if the node we want is smaller or bigger then det curent branthe we are at.
                if (key < parent.Data) 
                    parent.LeftNode = Remove(parent.LeftNode, key);
                else if (key > parent.Data)
                    parent.RightNode = Remove(parent.RightNode, key);

                // if value is same as the branthe value, then this is the node we want to deleted  
                else
                {
                    // node with only one child or no child  
                    if (parent.LeftNode == null)
                        return parent.RightNode;
                    else if (parent.RightNode == null)
                        return parent.LeftNode;

                    // node with two children: Get the inorder successor (smallest in the right subtree)
                    parent.Data = MinValue(parent.RightNode);

                    // Delete the inorder successor  
                    // and moves the other noedes akordening lig with the remove methoed
                    parent.RightNode = Remove(parent.RightNode, parent.Data);
                }

                return parent;
            }

            private int MinValue(Node node)
            {
                int minv = node.Data;

                while (node.LeftNode != null)
                {
                    minv = node.LeftNode.Data;
                    node = node.LeftNode;
                }

                return minv;
            }

            private Node Find(int value, Node parent)
            {
                // Continyous ontel it reathes a point were it kant finde a parant node
                // this stopes the surthe if the thing we are looking for is not ind the tree
                if (parent != null)
                {
                    //if the branth we are looking at is the same as the nommber we are lokking for the we return the 
                    if (value == parent.Data) return parent;

                    // if we dident fint the node then we se if the nummber is higer or smaller the the branc we just looked at
                    if (value < parent.Data)
                        return Find(value, parent.LeftNode);
                    else
                        return Find(value, parent.RightNode);
                }

                return null;
            }

            public void TraversePreOrder(Node parent)
            {
                // Continyous ontel it reathes a point were it kant finde a parant node
                if (parent != null)
                {
                    // First writes the root nummber aka owere start node
                    Console.WriteLine(parent.Data + " ");
                    if (parent.LeftNode != null)
                    {
                        // reates the node parant node and then the left chiled node
                        Console.Write(parent.Data + " ");
                        TraversePreOrder(parent.LeftNode);
                    }
                    if (parent.RightNode != null)
                    {
                        Console.Write(parent.Data + " ");
                        TraversePreOrder(parent.RightNode);
                    }
                }
            }

            public void TraverseInOrder(Node parent)
            {
                if (parent != null)
                {
                    TraverseInOrder(parent.LeftNode);
                    Console.Write(parent.Data + " ");
                    TraverseInOrder(parent.RightNode);
                }
            }

            public void TraversePostOrder(Node parent)
            {
                if (parent != null)
                {
                    TraversePostOrder(parent.LeftNode);
                    TraversePostOrder(parent.RightNode);
                    Console.Write(parent.Data + " ");
                }
            }
            #endregion
        }

        #endregion


    }
}
