using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2task1
{
    class LinkedList : ILinkedList
    {
        public Node firstNode { get; set; }
        public Node lastNode { get; set; }
        private int Count = 0;

        public void AddNode(int value)
        {
            var newNode = new Node { Value = value };

            if (Count == 0)
            {
                firstNode = newNode;
                lastNode = firstNode;
                Count++;
            }
            else
            {
                lastNode.NextNode = newNode;
                newNode.PrevNode = lastNode;
                lastNode = newNode;
                Count++;
            }
        }
        // [node.Prev] [node] [*] [node.Next]
        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value, PrevNode = node, NextNode = node.NextNode };
            if (node.NextNode != null) // node != lastNode
            {
                node.NextNode.PrevNode = newNode;
            }
            node.NextNode = newNode;
            if (node == lastNode)
            {
                lastNode = newNode;
            }
            Count++;
        }

        public Node FindNode(int searchValue)
        {
            var currentNode = firstNode;

            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                {
                    return currentNode;
                }
                currentNode = currentNode.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            return Count;
        }

        public void RemoveNode(int index)
        {
            int currentIndex = 0;
            var currentNode = firstNode;
            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    RemoveNode(currentNode);
                }
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
        }

        public void RemoveNode(Node node)
        {

            if (node == firstNode)
            {
                if (node != lastNode)
                {
                    node.NextNode.PrevNode = null;
                }

                firstNode = node.NextNode;
            }
            else if (node == lastNode)
            {
                node.PrevNode.NextNode = null;
                lastNode = node.PrevNode;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }
            Count--;
        }
    }
}