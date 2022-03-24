using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ADT;
using DataStructures.TreeStructures;
using DataStructures.LinearStructures;

namespace DataStructures.OtherStructures
{
    class HeapUsingTree<K, V> : IHeap<K, V>
    {
        private GetPriorityDelegate<K, V> getPriority;
        private ComparePriorityDelegate<K> comparePriority;
        private int count;
        private TreeNode<K, V> root;
        private TreeNode<K, V> lastInserted;
        private bool lastInsertedIsLeft;
        private List<TreeNode<K, V>> siblings;
        private CustomStack<TreeNode<K, V>> nodesStack;

        public HeapUsingTree(GetPriorityDelegate<K, V> _getPriority, ComparePriorityDelegate<K> _comparePriority) {
            getPriority = _getPriority;
            comparePriority = _comparePriority;
            siblings = new List<TreeNode<K, V>>();
            lastInsertedIsLeft = false;
            lastInserted = null;
            nodesStack = new CustomStack<TreeNode<K, V>>();
        }

        public int Count()
        {
            return count;
        }

        public void Insert(V value)
        {
            if (IsEmpty())
            {
                TreeNode<K, V> newNode = new TreeNode<K, V>(getPriority(value), value);
                root = newNode; //Saving the reference to the last inserted node
                lastInserted = newNode;
                nodesStack.Push(lastInserted);
                count++;
                siblings.Add(root);
            }
            else 
            {
                TreeNode<K, V> newNode = new TreeNode<K, V>(getPriority(value), value);
                bool wasInserted = false;

                for (int i = 0; i < siblings.Count; i++) {
                    if (siblings[i].left == null)
                    { //new node can be inserted here
                        lastInsertedIsLeft = true;
                        siblings[i].left = newNode;
                        newNode.parent = siblings[i];
                        lastInserted = newNode; //Saving the reference to the last inserted node
                        nodesStack.Push(lastInserted);
                        count++;
                        UpdateAfterInsertInternal(newNode);
                        return;
                    }
                    else if (siblings[i].right == null)
                    { //new node can be inserted here
                        lastInsertedIsLeft = false;
                        siblings[i].right = newNode;
                        newNode.parent = siblings[i];
                        lastInserted = newNode; //Saving the reference to the last inserted node
                        nodesStack.Push(lastInserted);
                        count++;
                        UpdateAfterInsertInternal(newNode);
                        return;
                    }
                    
                }

                if (!wasInserted) {
                    //going to create new siblings list
                    List<TreeNode<K, V>>  newSiblings = new List<TreeNode<K, V>>();
                    for (int i = 0; i < siblings.Count; i++) {
                        newSiblings.Add(siblings[i].left);
                        newSiblings.Add(siblings[i].right);
                    }
                    siblings = newSiblings;
                    Insert(value);
                }
            }
        }

        public bool IsEmpty()
        {
            return 0 == count;
        }

        public V peek()
        {
            return root.value;
        }

        public V Remove()
        {
            if (!IsEmpty()) {
                V temp = root.value;

                if (Count() == 1) //only the root exists
                {
                    
                    count--;
                    root = null;
                    lastInserted = null;
                    nodesStack.Pull();
                    siblings.Clear();
                
                }
                else 
                {
                    //Swap between root and last inserted
                    root.key = lastInserted.key;
                    root.value = lastInserted.value;

                    //Delete the leaft
                    if (lastInsertedIsLeft)
                    {
                        lastInserted.parent.left = null;
                    }
                    else 
                    {
                        lastInserted.parent.right = null;
                    }

                    nodesStack.Pull();
                    lastInserted = nodesStack.Peek();

                    UpdateAfterDeleteInternal(root);
                }

                return temp;
            }

            return default;
        }

        private void UpdateAfterDeleteInternal(TreeNode<K, V> actual) {
            if (actual != null) {
                if (actual.left != null) {

                    if (actual.right != null)
                    {
                        int result = comparePriority(actual.left.key, actual.right.key);
                        if (result >= 0) //left has greater priority
                        {
                            result = comparePriority(actual.key, actual.left.key);
                            if (result < 0) { //Swap is needed because left child has greater priority
                                K tempPriority = actual.key;
                                V tempValue = actual.value;

                                actual.key = actual.left.key;
                                actual.value = actual.left.value;

                                actual.left.key = tempPriority;
                                actual.left.value = tempValue;
                            }
                        }
                        else if (result < 0) { //right has greater priority
                            result = comparePriority(actual.key, actual.right.key);
                            if (result < 0)
                            { //Swap is needed because left child has greater priority
                                K tempPriority = actual.key;
                                V tempValue = actual.value;

                                actual.key = actual.right.key;
                                actual.value = actual.right.value;

                                actual.right.key = tempPriority;
                                actual.right.value = tempValue;
                            }
                        }
                    }
                    else //Means doesn't have right child then compare only with the left child
                    {
                        int result = comparePriority(actual.left.key, actual.right.key);
                        if (result >= 0) //left has greater priority
                        {
                            result = comparePriority(actual.key, actual.left.key);
                            if (result < 0)
                            { //Swap is needed because left child has greater priority
                                K tempPriority = actual.key;
                                V tempValue = actual.value;

                                actual.key = actual.left.key;
                                actual.value = actual.left.value;

                                actual.left.key = tempPriority;
                                actual.left.value = tempValue;
                            }
                        }
                    }

                }
            }
        }

        private void UpdateAfterInsertInternal(TreeNode<K, V> actual) 
        {
            if (actual != null) {
                if (actual.parent != null) {
                    int result = comparePriority(actual.key, actual.parent.key);

                    if (result > 0) //actual priority is greater than parent priority
                    {
                        K tempPriority = actual.key;
                        V tempValue = actual.value;

                        actual.key = actual.parent.key;
                        actual.value = actual.parent.value;

                        actual.parent.key = tempPriority;
                        actual.parent.value = tempValue;


                    }

                }
            }
        }


    }
}
