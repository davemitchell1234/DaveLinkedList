using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace DaveLinkedList.Tests
{
    [TestClass()]
    public class DmLinkedListTests
    {
        private DmLinkedList _list;
        private const string NODEDATA = "node data";

        [TestInitialize]
        public void Initialise()
        {
            var currentNode = new DmLinkedListNode { Data = $"{NODEDATA} 0", Next = null };
            _list = new DmLinkedList { Head = currentNode };

            for (int i = 1; i < 10; i++)
            {
                var newNode = new DmLinkedListNode { Data = $"{NODEDATA} {i}", Next = null };
                currentNode.Next = newNode;
                currentNode = newNode;
            }
        }

        [TestMethod()]
        public void InsertNewNodeAsHead()
        {
            // Arrange
            var data = $"{NODEDATA} 99";
            int requiredPosition = 0;

            // Act
            var newNode = _list.Insert(data, requiredPosition);

            // Assert
            Assert.AreEqual($"{NODEDATA} 99", newNode.Data);
        }

        [TestMethod()]
        public void InsertNewNodeWithinList()
        {
            // Arrange
            var data = $"{NODEDATA} 99";
            int requiredPosition = 7;

            // Act
            var newNode = _list.Insert(data, requiredPosition);

            // Assert
            Assert.AreEqual($"{NODEDATA} 99", newNode.Data);
        }

        [TestMethod()]
        public void InsertNewNodeAtEndOfList()
        {
            // Arrange
            var data = $"{NODEDATA} 99";
            int requiredPosition = 777;

            // Act
            var newNode = _list.Insert(data, requiredPosition);

            // Assert
            Assert.AreEqual($"{NODEDATA} 99", newNode.Data);
        }

        [TestMethod()]
        public void DeleteHeadNode()
        {
            // Arrange
            int requiredPosition = 0;

            // Act
            _list.Delete(requiredPosition);

            // Assert
            Assert.AreEqual($"{NODEDATA} {1}", _list.Head.Data);
        }

        [TestMethod()]
        public void DeleteSpecificNode()
        {
            // Arrange
            int requiredPosition = 3;
            var originalList = _list.PrintList();

            // Act
            _list.Delete(requiredPosition);

            // Assert
            var newList = _list.PrintList();
            var difference = CompareTwoCommaDelimitedStrings(originalList, newList);
            Assert.AreEqual($"{NODEDATA} {3}", difference);
        }

        [TestMethod()]
        public void PrintList()
        {
            // Arrange

            // Act
            var result = _list.PrintList();

            // Assert
            var expected = new StringBuilder();
            var currentNode = _list.Head;
            while(currentNode.Next != null)
            {
                expected.Append($"{currentNode.Data},");
                currentNode = currentNode.Next;
            }
            expected.Append(currentNode.Data);

            Assert.AreEqual(expected.ToString(), result);
        }
        
        private string CompareTwoCommaDelimitedStrings(string string1, string string2)
        {
            var first = string1.Split(',');
            var second = string2.Split(',');
            var primary = first.Length > second.Length ? first : second;
            var secondary = primary == second ? first : second;
            var difference = primary.Except(secondary).ToArray();

            return string.Join(" ", difference);
        }
    }
}
