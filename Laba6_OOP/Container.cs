using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

		int count = 0;

		private void readingShapes(StreamReader reader, ShapeFactory factory)
		{
			string line;
			while ((line = reader.ReadLine()) != null && line != "")
			{
				char code = line[0];
				Shape shape = factory.createShape(code);

				if (shape != null)
				{
					if (shape is CGroup)
					{
						(shape as CGroup).loadGroup(reader, factory);
						Push_back(shape);
						continue;
					}

					shape.load(reader);
					Push_back(shape);
				}
				else
				{
					return;
				}
			}
		}

		public void loadShapes(string pathToTheFile, ShapeFactory factory)
		{
			using (StreamReader reader = new StreamReader(pathToTheFile, System.Text.Encoding.Default))
			{
				readingShapes(reader, factory);
			}
		}

		public void loadShapes(StreamReader reader, ShapeFactory factory)
		{
			readingShapes(reader, factory);
		}

		public void saveShapes(string pathToTheFile)
		{
			if (count != 0)
			{
				using (StreamWriter writer = new StreamWriter(pathToTheFile, false, System.Text.Encoding.Default))
				{
					Node current = head;
					while (current != endNode)
					{
						current.key.save(writer);
						current = current.next;
					}
				}
			}

		}

		//Переставляем все указатели на объекты при добавлении нового
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

		//Подсчет количества объектов
		public int Count()
		{
			return count;
		}

		//Для того,чтобы убедиться, что данный объект есть в List
		public Node Search(Shape item)
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

		public void Insert(Shape newItem)
		{
			Node newNode = new Node();
			newNode.key = newItem;
			count++;

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
				count++;
				newNode.prev = back;
				back.next = newNode;
				back = newNode;
				newNode.next = endNode;
				endNode.prev = newNode;
				updateBackNEnd();
			}
		}

		//удаление объекта
		public bool remove(Shape item)
		{
			Node nodeToRemove;
			nodeToRemove = search(item);

			if (nodeToRemove != null)
			{
				count--;
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

		public ContainerIterator Begin()
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

		public ContainerIterator Last()
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

		public ContainerIterator End()
		{
			ContainerIterator endIterator = new ContainerIterator(endNode);
			return endIterator;
		}


	}

	//работа с итераторами в List
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

		//получение индекса объекта
		public Node getNode()
		{
			return currentNode;
		}

	}
}
