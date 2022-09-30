using System.Diagnostics;
using System;

namespace DatiEAlgoritmi3
{ 
    class TestDoubleLink
    {
        private static Node head;
        private static Node tail;
        public static void Init()
        {
            // primo nodo chiamato testa nodo
            head = new Node("A");

            head.prev = null;
            head.next = null;

            Node nodeB = new Node("B");
            nodeB.prev = head;
            nodeB.next = null;
            head.next = nodeB;

            Node nodeC = new Node("C");
            nodeC.prev = nodeB;
            nodeC.next = null;
            nodeB.next = nodeC;

            //ultimo nodo chiamato coda nodo
            tail = new Node("D");
            tail.prev = nodeC;
            tail.next = null;
            nodeC.next = tail;

        }

        public static void Print(Node node)
        {
            Node p = node;
            Node end = null;
            while (p != null)
            {
                Console.Write(p.data + " -> ");
                end = p;
                p = p.next;
            }

            Console.Write("End\n");
            p = end;

            while(p != null)
            {
                Console.Write(p.data + " -> ");
                p = p.prev;
            }
            Console.Write("Start\n\n");
        }

        public static void Main(string[] args)
        {
            Init();
            Add(new Node("E"));
            Insert(2, new Node("X"));
            Remove(2);
            Print(head);
        }

        public static void Add(Node newNode)
        {
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }

        public static void Insert(int insertPosition, Node newNode)
        {
            Node p = head;
            int i = 0;

            while(p.next!= null && i < insertPosition - 1)
            {
                p = p.next;
                i++;
            }
            newNode.next = p.next;
            p.next = newNode;
            newNode.prev = p;
            newNode.next.prev = newNode;
        }

        public static void Remove(int removePosition)
        {
            Node p = head;
            int i = 0;

            // Sposta il nodo sul nodo precedente che vuoi eliminare 
            while (p.next != null && i < removePosition - 1)
            {
                p = p.next;
                i++;
            }

            Node temp = p.next; // Salva il nodo che vuoi eliminare

            p.next = p.next.next; 
            p.next.prev = p;
            temp.next = null; // elimina il nodo
            temp.prev = null; // elimina il nodo


        }
    }
}