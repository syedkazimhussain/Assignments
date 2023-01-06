using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Program
    {
        /* A Single Linked list Node*/
        public class Node
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }
        public class lList
        {
            public Node head;
            /* Inserts a new Node at front of the list. */
            public void push(int new_data)
            {
                /* 1 & 2: Allocate the Node &
                Put in the data*/
                Node new_node = new Node(new_data);

                /* 3. Make next of new Node as head */
                new_node.next = head;

                /* 4. Move the head to point to new Node */
                head = new_node;
            }



            /* Appends a new node at the end. This method is
                defined inside LinkedList class shown above */
            public void append(int new_data)
            {
                /* 1. Allocate the Node &
                2. Put in the data
                3. Set next as null */
                Node new_node = new Node(new_data);

                /* 4. If the Linked List is empty,
                then make the new node as head */
                if (head == null)
                {
                    head = new Node(new_data);
                    return;
                }

                /* 4. This new node is going to be
                the last node, so make next of it as null */
                new_node.next = null;

                /* 5. Else traverse till the last node */
                Node last = head;
                while (last.next != null)
                    last = last.next;

                /* 6. Change the next of last node */
                last.next = new_node;
                return;
            }



            /* Inserts a new node after the given prev_node. */
            public void insertAfter(Node prev_node, int new_data)
            {
                /* 1. Check if the given Node is null */
                if (prev_node == null)
                {
                    Console.WriteLine("The given previous node"
                    + " cannot be null");
                    return;
                }

                /* 2 & 3: Allocate the Node &
                Put in the data*/
                Node new_node = new Node(new_data);

                /* 4. Make next of new Node as
                 next of prev_node */
                new_node.next = prev_node.next;

                /* 5. make next of prev_node
                     as new_node */
                prev_node.next = new_node;
            }

            public void deleteFirst()
            {
                head = head.next;
            }

            public void deleteLast()
            { 


              Node temp = head;


                while(temp.next.next!=null){
                    temp = temp.next;

                 }
                temp.next = null;

                
            }










            public bool searchIterative(Node head, int x)
            {
                Node current = head; // Initialize current
                while (current != null)
                {
                    if (current.data == x)
                        return true; // data found
                    current = current.next;
                }
                return false; // data not found
            }






            public bool searchResersive(Node head, int x)
            {
                // Base case
                if (head == null)
                    return false;

                // If key is present in current node,
                // return true
                if (head.data == x)
                    return true;

                // Recur for remaining list
                return searchResersive(head.next, x);
            }




























            public void printList()
                {
                    Node tnode = head;
                    while (tnode != null)
                    {
                        Console.WriteLine(tnode.data + " ");
                        tnode = tnode.next;

                    }
                   

                }
            
        }


            static void Main(string[] args)
            {
                lList obj = new lList();

             
                obj.push(5);
                obj.append(9);
                obj.insertAfter(obj.head, 7);


            Console.WriteLine(obj.searchIterative(obj.head,5));

            Console.WriteLine(obj.searchResersive(obj.head, 8));

            obj.printList();

                // obj.deleteLast();

                     obj.printList();  


                Console.ReadLine();
             
        }
           

    }    
}

