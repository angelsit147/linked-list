using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomListLib
{
    /// <summary>
    /// Вузол однозв'язного списку.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Значення вузла.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Посилання на наступний вузол.
        /// </summary>
        public Node? Next { get; set; }

        /// <summary>
        /// Конструктор з параметром.
        /// </summary>
        /// <param name="value">Значення вузла.</param>
        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    /// <summary>
    /// Однозв'язний список цілих чисел.
    /// </summary>
    public class MyLinkedList : IEnumerable<int>
    {
        private Node? head;
        private int count;

        /// <summary>
        /// Додає елемент після першого елементу.
        /// </summary>
        /// <param name="value">Значення для додавання.</param>
        public void AddAfterFirst(int value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
            }
            else if (head.Next == null)
            {
                head.Next = newNode;
            }
            else
            {
                newNode.Next = head.Next;
                head.Next = newNode;
            }
            count++;
        }

        /// <summary>
        /// Знаходить перше входження елементу більшого за задане значення.
        /// </summary>
        /// <param name="target">Значення для порівняння.</param>
        /// <returns>Перше більше значення або null.</returns>
        public int? FindFirstGreaterThan(int target)
        {
            Node? current = head;
            while (current != null)
            {
                if (current.Value > target)
                    return current.Value;

                current = current.Next;
            }
            return null;
        }

        /// <summary>
        /// Обчислює суму всіх елементів, менших за задане значення.
        /// </summary>
        /// <param name="target">Граничне значення.</param>
        /// <returns>Сума елементів або null, якщо список порожній.</returns>
        public int? SumLessThan(int target)
        {
            int sum = 0;
            bool found = false;
            Node? current = head;

            while (current != null)
            {
                if (current.Value < target)
                    sum += current.Value;
                    found = true;
                current = current.Next;
            }

            if (found)
            {
                return sum;
            }

            return null;
        }

        /// <summary>
        /// Створює новий список зі значеннями більшими за задане.
        /// </summary>
        /// <param name="target">Граничне значення.</param>
        /// <returns>Новий список або null, якщо таких елементів нема.</returns>
        public MyLinkedList? FilterGreaterThan(int target)
        {
            MyLinkedList result = new MyLinkedList();
            Node? current = head;

            while (current != null)
            {
                if (current.Value > target)
                    result.AddAfterFirst(current.Value);
                current = current.Next;
            }

            if (result.count <= 0)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Видаляє всі елементи після максимального.
        /// </summary>
        /// <returns>true, якщо операція виконана; false — якщо список порожній.</returns>
        public bool RemoveAfterMax()
        {
            if (head == null)
                return false;

            Node? current = head;
            Node? maxNode = head;

            while (current != null)
            {
                if (current.Value > maxNode.Value)
                    maxNode = current;
                current = current.Next;
            }

            if (maxNode != null)
            {
                maxNode.Next = null;
                count = Count();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Видаляє елемент за індексом.
        /// </summary>
        /// <param name="index">Індекс елементу.</param>
        /// <returns>true, якщо елемент видалено; false — якщо індекс недійсний.</returns>
        public bool RemoveBy(int index)
        {
            if (index < 0 || index >= count)
                return false;

            if (index == 0 && head != null)
            {
                head = head.Next;
                count--;
                return true;
            }

            Node? current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current?.Next;
            }

            if (current?.Next != null)
            {
                current.Next = current.Next.Next;
                count--;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Кількість елементів у списку.
        /// </summary>
        /// <returns>Кількість елементів.</returns>
        public int Count()
        {
            int total = 0;
            Node? current = head;

            while (current != null)
            {
                total++;
                current = current.Next;
            }

            return total;
        }

        /// <summary>
        /// Повертає значення за індексом.
        /// </summary>
        /// <param name="index">Індекс елементу.</param>
        /// <returns>Значення елементу.</returns>
        public int? this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException();

                Node? current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current?.Next;
                }

                if (current == null)
                {
                    return null;
                }

                return current.Value;
            }
        }

        /// <summary>
        /// Реалізація підтримки foreach.
        /// </summary>
        /// <returns>Ітератор.</returns>
        public IEnumerator<int> GetEnumerator()
        {
            Node? current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
