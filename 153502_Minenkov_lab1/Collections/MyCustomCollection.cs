using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Minenkov_lab1.Interfaces;
using System.Collections;

namespace _153502_Minenkov_lab1.Collections
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    internal class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T>
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        Node<T> current;
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);

            if (head == null)
                head = tail = current = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        public bool Remove(T item)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            try
            {
                throw new Exception("Element was not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T this[int index]
        {
            get
            {
                try
                {
                    if (index > count - 1)
                        throw new IndexOutOfRangeException();
                    current = head;
                    int i = 0;
                    while (i != index)
                    {
                        current = current.Next;
                        i++;
                    }
                    return current.Data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return head.Data;
                }
            }
            set
            {
                try
                {
                    if (index > count - 1)
                        throw new IndexOutOfRangeException();
                    current = head;
                    int i = 0;
                    while (i != index)
                    {
                        current = current.Next;
                        i++;
                    }
                    current.Data = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void Reset()
        {
            current = head;
        }

        public void Next()
        {
            if(current != null && current.Next != null)
            {
                current = current.Next;
            }
        }

        public T Current()
        {
            return current.Data;
        }

        public void RemoveCurrent()
        {
            if (current == null) return;
            else
            {
                if (current == head)
                {
                    if (head.Next != null)
                        head = current = head.Next;
                    else
                        head = tail = current = null;
                }
                else if (current == tail)
                {
                    Node<T> temp = head;
                    while (temp.Next != current)
                        temp = temp.Next;
                    tail = current = temp;
                }
                else
                {
                    Node<T> temp = head;
                    while (temp.Next != current)
                        temp = temp.Next;
                    temp.Next = current.Next;
                }
                count--;
            }
        }


    }
}
