using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4task2
{
    public class Tree
    {
        private Node<int> firstNode;
        //public void Insert(int value)
        //{
        //    if (firstNode == null)
        //    {
        //        firstNode = new Node<int> { Data = value };
        //        count++;
        //        return;
        //    }

        //    var currentNode = firstNode;
        //    while (currentNode != null)
        //    {
        //        if (value > currentNode.Data)
        //        {
        //            if (currentNode.Right != null)
        //            {
        //                currentNode = currentNode.Right;
        //                continue;
        //            }
        //            else
        //            {
        //                currentNode.Right = new Node<int> { Data = value };
        //            }
        //            count++;
        //            rights++;
        //            return;
        //        }
        //        else if (value < currentNode.Data)
        //        {
        //            if (currentNode.Left != null)
        //            {
        //                currentNode = currentNode.Left;
        //                continue;
        //            }
        //            else
        //            {
        //                currentNode.Left = new Node<int> { Data = value };
        //                count++;
        //                lefts++;
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Wrong tree state");                  // Дерево построено неправильно
        //        }
        //    }
        //    // count++;
        //}


        public void Insert(int value)
        {
            var node = new Node<int>() { Data = value };
            if (firstNode == null)
            {
                firstNode = node;
            }
            else
            {
                firstNode = RecursiveInsert(firstNode, node);
            }
        }
        private Node<int> RecursiveInsert(Node<int> current, Node<int> newNode)
        {
            if (current == null)
            {
                current = newNode;
                return current;
            }
            else if (current.Data > newNode.Data)
            {
                current.Left = RecursiveInsert(current.Left, newNode);
                current = BalanceTree(current);
            }
            else if (current.Data < newNode.Data)
            {
                current.Right = RecursiveInsert(current.Right, newNode);
                current = BalanceTree(current);
            }
            return current;
        }

        private int GetHeight(Node<int> node)
        {
            int nodeHeight = 0;
            if (node != null)
            {
                int leftNodeHeight = GetHeight(node.Left);
                int rightNodeHeight = GetHeight(node.Right);
                nodeHeight = Math.Max(leftNodeHeight, rightNodeHeight) + 1;
            }
            return nodeHeight;
        }

        private Node<int> BalanceTree(Node<int> node)
        {
            int balanceFactor = BalanceFactor(node); // -2
            if (balanceFactor > 1)
            {
                if (BalanceFactor(node.Left) > 0)
                {
                    node = RotateLeftLeft(node);
                }
                else
                {
                    node = RotateLeftRight(node);
                }
            }
            else if (balanceFactor < -1)
            {
                if (BalanceFactor(node.Right) > 0)
                {
                    node = RotateRightLeft(node);
                }
                else
                {
                    node = RotateRightRight(node);
                }
            }
            return node;
        }
        public Node<int> Find(int value)
        {
            return Find(value, firstNode);
        }
        private Node<int> Find(int target, Node<int> current)
        {
            if (current == null)
            {
                return null;
            }
            if (target < current.Data)
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Left);
            }
            else
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Right);
            }

        }
        private int BalanceFactor(Node<int> node)
        {
            int leftNodeHeight = GetHeight(node.Left);
            int rightNodeHeight = GetHeight(node.Right);
            return leftNodeHeight - rightNodeHeight;
        }
        private Node<int> RotateRightRight(Node<int> parent)
        {
            var pivot = parent.Right;//pivot =  4
            parent.Right = pivot.Left;// 3.Right = 4.Left = B
            pivot.Left = parent; // 4.Left = 3
            return pivot;
        }
        private Node<int> RotateLeftLeft(Node<int> parent)
        {
            var pivot = parent.Left; // 5.Left = 4
            parent.Left = pivot.Right; // 5.Left = 4.Right = C
            pivot.Right = parent; // 4.Right = 5
            return pivot;
        }
        private Node<int> RotateLeftRight(Node<int> parent)
        {
            var pivot = parent.Left; // pivot = 3;
            parent.Left = RotateRightRight(pivot);
            return RotateLeftLeft(parent);
        }
        private Node<int> RotateRightLeft(Node<int> parent)
        {
            var pivot = parent.Right;
            parent.Right = RotateLeftLeft(pivot);
            return RotateRightRight(parent);
        }
    }
}
