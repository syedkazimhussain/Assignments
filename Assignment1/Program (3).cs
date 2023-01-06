using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Program
    {


        class Stack
        {
            public int[] arr;
            public int top;
            public int capacity;

            // Creating a stack
            public Stack(int size)
            {
                arr = new int[size];
                capacity = size;
                top = -1;
            }


            public class ST
            {
                Stack sk;

                public ST()
                {
                    Stack sk = null;
                }
                public ST(int size)
                {
                    sk= new Stack(size);
                }
                // Add elements into stack
                public void push(int x)
                {
                    if (sk.top + 1 == sk.capacity )
                    {
                        Console.WriteLine("OverFlow\nProgram Terminated\n");
                        
                    }

                    Console.WriteLine("Inserting " + x);
                    sk.arr[++sk.top] = x;
                }

                // Remove element from stack
                public int pop()
                {
                    if (isEmpty())
                    {
                        System.out.println("STACK EMPTY");
                        System.exit(1);
                    }
                    return arr[top--];
                }

            }


            static void Main(string[] args)
            {




            }
        }
    }
}