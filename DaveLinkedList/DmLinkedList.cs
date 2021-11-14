using System;
using System.Text;

namespace DaveLinkedList
{
    public class DmLinkedList
    {
        public DmLinkedListNode Head;

        public DmLinkedListNode Insert(object data, int requiredPosition)
        {
            if (requiredPosition < 0)
            {
                throw new ApplicationException("position should be greater than or equal to zero");
            }

            if (requiredPosition == 0)
            {
                Head = new DmLinkedListNode { Data = data, Next = Head };
                return Head;
            }

            return CreateNode(data, requiredPosition);
        }

        public void Delete(int requiredPosition)
        {
            if (requiredPosition < 0)
            {
                throw new ApplicationException("position should be greater than or equal to zero");
            }

            if (requiredPosition == 0)
            {
                Head = Head?.Next;
                return;
            }

            DeleteNode(requiredPosition);
        }

        public string PrintList()
        {
            var data = new StringBuilder();
            var currentNode = Head;
            while (currentNode.Next != null)
            {
                data.Append($"{currentNode.Data},");
                currentNode = currentNode.Next;
            }
            data.Append(currentNode.Data);

            return data.ToString();
        }

        private DmLinkedListNode CreateNode(object data, int requiredPosition)
        {
            int nodeNumber = 0;
            var currentNode = Head;
            DmLinkedListNode previousNode = null, newNode = null;

            while (currentNode.Next != null)
            {
                if (nodeNumber == requiredPosition)
                {
                    newNode = new DmLinkedListNode { Data = data, Next = currentNode };
                    previousNode.Next = newNode;
                    break;
                }

                nodeNumber++;
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (newNode == null)
            {
                newNode = new DmLinkedListNode { Data = data, Next = null };
                currentNode.Next = newNode;
            }

            return newNode;
        }

        private void DeleteNode(int requiredPosition)
        {
            int nodeNumber = 0;
            var currentNode = Head;
            DmLinkedListNode previousNode = null;

            while (currentNode.Next != null)
            {
                if (nodeNumber == requiredPosition)
                {
                    previousNode.Next = currentNode.Next;
                    break;
                }

                nodeNumber++;
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (nodeNumber < requiredPosition)
            {
                throw new ApplicationException($"cannot delete node at position {requiredPosition} - not enough nodes in list");
            }
        }
    }
}
