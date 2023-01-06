﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BST
{
    internal class Program
    {

        public class Node
        {
            public int key;
            public Node left, right;

            public Node(int item)
            {
                key = item;
                left = right = null;
            }
        }



        public class BST
        {


            public Node root;

            // Constructor
            public BST() { root = null; }

            public BST(int value) { root = new Node(value); }
            public void insertRecursive(int key) { root = insertRec(root, key); }

            // A recursive function to insert
            // a new key in BST
            Node insertRec(Node root, int key)
            {

                // If the tree is empty,
                // return a new node
                if (root == null)
                {
                    root = new Node(key);
                    return root;
                }

                // Otherwise, recur down the tree
                if (key < root.key)
                    root.left = insertRec(root.left, key);
                else if (key > root.key)
                    root.right = insertRec(root.right, key);

                // Return the (unchanged) node pointer
                return root;
            }



            // Function to insert a new key in the BST
            public void insert(int key)
            {
                Node node = new Node(key);
                if (root == null)
                {
                    root = node;
                    return;
                }
                Node prev = null;
                Node temp = root;
                while (temp != null)
                {
                    if (temp.key > key)
                    {
                        prev = temp;
                        temp = temp.left;
                    }
                    else if (temp.key < key)
                    {
                        prev = temp;
                        temp = temp.right;
                    }
                }
                if (prev.key > key)
                    prev.left = node;
                else
                    prev.right = node;
            }



            // This method mainly calls deleteRec()
            public void deleteKey(int key) { root = deleteRec(root, key); }



            /* A recursive function to
         delete an existing key in BST
        */
            Node deleteRec(Node root, int key)
            {
                /* Base Case: If the tree is empty */
                if (root == null)
                    return root;

                /* Otherwise, recur down the tree */
                if (key < root.key)
                    root.left = deleteRec(root.left, key);
                else if (key > root.key)
                    root.right = deleteRec(root.right, key);

                // if key is same as root's key, then This is the
                // node to be deleted
                else
                {
                    // node with only one child or no child
                    if (root.left == null)
                        return root.right;
                    else if (root.right == null)
                        return root.left;

                    // node with two children: Get the
                    // inorder successor (smallest
                    // in the right subtree)
                    root.key = minValue(root.right);

                    // Delete the inorder successor
                    root.right = deleteRec(root.right, root.key);
                }
                return root;
            }


            int minValue(Node root)
            {
                int minv = root.key;
                while (root.left != null)
                {
                    minv = root.left.key;
                    root = root.left;
                }
                return minv;
            }

            // A utility function to search
            // a given key in BST
            public Node search(Node root, int key)
            {
                // Base Cases: root is null
                // or key is present at root
                if (root == null ||
                    root.key == key)
                    return root;

                // Key is greater than root's key
                if (root.key < key)
                    return search(root.right, key);

                // Key is smaller than root's key
                return search(root.left, key);
            }

            // This method mainly calls InorderRec()
            public void inorder() { inorderRec(root); }

            // A utility function to
            // do inorder traversal of BST
            void inorderRec(Node root)
            {
                if (root != null)
                {
                    inorderRec(root.left);
                    Console.Write(root.key + " ");
                    inorderRec(root.right);
                }
            }

        }



        static void Main(string[] args)
        {

            BST bs = new BST(5);

            bs.insert(7);
            bs.insert(6);
            bs.insert(3);
            bs.insertRecursive(8);

            bs.inorder();

            bs.deleteKey(7);
            Console.WriteLine();
            bs.inorder();
            Console.ReadLine();


        }
    }
}
