using CustomListLib;
using System;
using System.Collections.Generic;

namespace ListDemoApp
{
    class Tests
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MyLinkedList list = new MyLinkedList();

            int[] values = { 15, -25, 32, -12, 64, 224, 77, -69, 23, -14 };
            foreach (int value in values)
                list.AddAfterFirst(value);

            Console.WriteLine("Початковий список:");
            foreach (int value in list)
            {
                if (value == list[0])
                    Console.Write($"{value}");
                else
                    Console.Write($" --> {value}");
            }
            Console.WriteLine("\n");

            int[] greaterThanTargets = { 22, 56, 250 };
            for(int i = 0; i < greaterThanTargets.Length; i++)
            {
                Console.Write($"1.{i + 1}. Перший елемент, більший за {greaterThanTargets[i]}: ");
                if (list.FindFirstGreaterThan(greaterThanTargets[i]) == null)
                    Console.WriteLine($"Серед елементів списку немає більших за {greaterThanTargets[i]}\n");
                else
                    Console.WriteLine($"{list.FindFirstGreaterThan(greaterThanTargets[i])}\n");
            }
            Console.WriteLine();

            int[] lessThanTargets = { 70, -10, -89 };
            for (int i = 0; i < lessThanTargets.Length; i++)
            {
                Console.Write($"2.{i + 1}. Сума елементів, менших за {lessThanTargets[i]}: ");
                if (list.SumLessThan(lessThanTargets[i]) == 0)
                    Console.WriteLine($"Серед елементів списку немає менших за {lessThanTargets[i]}\n");
                else
                    Console.WriteLine($"{list.SumLessThan(lessThanTargets[i])}\n");
            }
            Console.WriteLine();

            int[] filterTargets = { -5, 17, 350 };
            int number = 1;
            foreach (int target in filterTargets)
            {
                var filtered = list.FilterGreaterThan(target);
                Console.Write($"3.{number}. Список із елементами, більшими за {target}: ");

                if (filtered == null)
                {
                    Console.WriteLine($"Немає елементів, більших за {target}.\n");
                    continue;
                }

                foreach (int value in filtered)
                {
                    if (value == filtered[0])
                        Console.Write($"\n{value, 7}");
                    else
                        Console.Write($" --> {value}");
                }
                number++;
                Console.WriteLine("\n");
            }
            Console.WriteLine();

            list.RemoveAfterMax();
            Console.WriteLine("4. Видалення елементів після максимума:");
            foreach (int value in list)
            {
                if (value == list[0])
                    Console.Write($"{value,5}");
                else
                    Console.Write($" --> {value}");
            }
            Console.WriteLine("\n\n");

            int[] removeIndexTargets = { 1, 3, 9 };
            foreach (int target in removeIndexTargets)
            {
                Console.Write($"Видалення елемента за індексом {target}: ");
                if (list.RemoveBy(target))
                {
                    foreach (int value in list)
                    {
                        if (value == list[0])
                            Console.Write($"\n{value}");
                        else
                            Console.Write($" --> {value}");
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine($"У списку немає елемента з індексом {target}\n");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
