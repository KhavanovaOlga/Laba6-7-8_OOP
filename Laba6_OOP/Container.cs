using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6_OOP
{
	public class Node
	{
		public Shape key;
		public Node next = null;
		public Node prev = null;
	}

	public class Container
	{
		Node head = null;
		Node back = null;
		Node endNode = new Node();

		private void updateBackNEnd()
		{
			if (head == endNode)
			{
				head = null;
				back = null;
				endNode.next = endNode.prev = null;
				return;
			}

			if (endNode.prev == null)
			{
				if (head != null)
				{
					back = head;
					back.next = endNode;
					endNode.prev = back;
				}

				return;
			}

			if (back != endNode.prev)
			{
				back = endNode.prev;
			}
		}

		public Container()
		{

		}

		public Container(Shape newItem)
		{
			head = new Node();
			head.key = newItem;

			updateBackNEnd();
		}

		public int count()
		{
			Node node = head;
			int count = 0;
			while (node != null && node != endNode)
			{
				count++;
				node = node.next;
			}

			return count;
		}

		public Node search(Shape item)
		{
			Node node = head;
			while (node != null && node.next != endNode && node.key != item)
			{
				node = node.next;
			}

			if (node != null && node.next == endNode && node.key != item)
			{
				return null;
			}

			return node;
		}

		public void insert(Shape newItem)
		{
			Node newNode = new Node();
			newNode.key = newItem;

			newNode.next = head;
			if (head != null)
			{
				head.prev = newNode;
				newNode.next = head;
			}
			head = newNode;

			updateBackNEnd();
		}

		public void push_back(Shape newItem)
		{
			Node newNode = new Node();
			newNode.key = newItem;

			if (head == null)
			{
				insert(newItem);
			}
			else
			{
				newNode.prev = back;
				back.next = newNode;
				back = newNode;
				newNode.next = endNode;
				endNode.prev = newNode;
				updateBackNEnd();
			}
		}

		public bool remove(Shape item)
		{
			Node nodeToRemove;
			nodeToRemove = search(item);

			if (nodeToRemove != null)
			{
				if (nodeToRemove.prev != null)
				{
					nodeToRemove.prev.next = nodeToRemove.next;
				}
				else
				{
					head = nodeToRemove.next;
				}

				if (nodeToRemove.next != null)
				{
					nodeToRemove.next.prev = nodeToRemove.prev;
				}

				updateBackNEnd();
				return true;
			}

			updateBackNEnd();
			return false;
		}

		public ContainerIterator begin()
		{
			if (head != null)
			{
				ContainerIterator beginIterator = new ContainerIterator(head);
				return beginIterator;
			}
			else
			{
				ContainerIterator beginIterator = new ContainerIterator(endNode);
				return beginIterator;
			}
		}

		public ContainerIterator last()
		{
			if (back != null)
			{
				ContainerIterator beginIterator = new ContainerIterator(back);
				return beginIterator;
			}
			else
			{
				ContainerIterator beginIterator = new ContainerIterator(endNode);
				return beginIterator;
			}
		}

		public ContainerIterator end()
		{
			ContainerIterator endIterator = new ContainerIterator(endNode);
			return endIterator;
		}


	}

	public class ContainerIterator
	{
		Node currentNode = null;

		public ContainerIterator()
		{

		}

		public ContainerIterator(Node node)
		{
			currentNode = node;
		}

		public static ContainerIterator operator ++(ContainerIterator obj)
		{
			obj.currentNode = obj.currentNode.next;
			return obj;
		}

		public static ContainerIterator operator --(ContainerIterator it)
		{
			it.currentNode = it.currentNode.prev;
			return it;
		}

		public static bool operator ==(ContainerIterator it1, ContainerIterator it2)
		{
			return (it1.currentNode == it2.currentNode ? true : false);
		}

		public static bool operator !=(ContainerIterator it1, ContainerIterator it2)
		{
			return (it1.currentNode != it2.currentNode ? true : false);
		}

		public Node getNode()
		{
			return currentNode;
		}

	}
}
