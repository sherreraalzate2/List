using System;
using System.Collections.Generic;

namespace List.Class
{   
        public class Node<T> where T : IComparable<T>
        {
            public T Data;
            public Node<T> Next;
            public Node<T> Prev;

            public Node(T data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        public class DoublyLinkedList<T> where T : IComparable<T>
        {
            private Node<T> head;
            private Node<T> tail;

            public void AddOrdered(T data)
            {
                Node<T> newNode = new Node<T>(data);

                if (head == null)
                {
                    head = tail = newNode;
                }
                else if (data.CompareTo(head.Data) <= 0)
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
                else if (data.CompareTo(tail.Data) >= 0)
                {
                    tail.Next = newNode;
                    newNode.Prev = tail;
                    tail = newNode;
                }
                else
                {
                    Node<T> aux = head;
                    while (aux.Next != null && aux.Next.Data.CompareTo(data) < 0)
                    {
                        aux = aux.Next;
                    }
                    newNode.Next = aux.Next;
                    newNode.Prev = aux;
                    aux.Next.Prev = newNode;
                    aux.Next = newNode;
                }
            }

            public void DisplayForward()
            {
                Node<T> aux = head;
                while (aux != null)
                {
                    Console.Write(aux.Data + " ");
                    aux = aux.Next;
                }
                Console.WriteLine();
            }

            public void DisplayBackward()
            {
                Node<T> aux = tail;
                while (aux != null)
                {
                    Console.Write(aux.Data + " ");
                    aux = aux.Prev;
                }
                Console.WriteLine();
            }

            public void SortDescending()
            {
                if (head == null) return;
                Node<T> aux = head;
                while (aux != null)
                {
                    Node<T> temp = aux.Next;
                    while (temp != null)
                    {
                        if (aux.Data.CompareTo(temp.Data) < 0)
                        {
                            T swap = aux.Data;
                            aux.Data = temp.Data;
                            temp.Data = swap;
                        }
                        temp = temp.Next;
                    }
                    aux = aux.Next;
                }
            }

            public void Moda()
            {
                if (head == null)
                {
                    Console.WriteLine("Lista vacía.");
                    return;
                }

                Dictionary<T, int> freq = new Dictionary<T, int>();
                Node<T> aux = head;
                int max = 0;

                while (aux != null)
                {
                    if (!freq.ContainsKey(aux.Data))
                        freq[aux.Data] = 0;

                    freq[aux.Data]++;
                    if (freq[aux.Data] > max)
                        max = freq[aux.Data];

                    aux = aux.Next;
                }

                Console.Write("Moda(s): ");
                foreach (var item in freq)
                {
                    if (item.Value == max)
                        Console.Write(item.Key + " ");
                }
                Console.WriteLine();
            }

            public bool Exists(T data)
            {
                Node<T> aux = head;
                while (aux != null)
                {
                    if (aux.Data.CompareTo(data) == 0)
                        return true;
                    aux = aux.Next;
                }
                return false;
            }

            public void RemoveOne(T data)
            {
                Node<T> aux = head;
                while (aux != null)
                {
                    if (aux.Data.CompareTo(data) == 0)
                    {
                        if (aux == head)
                        {
                            head = head.Next;
                            if (head != null) head.Prev = null;
                        }
                        else if (aux == tail)
                        {
                            tail = tail.Prev;
                            tail.Next = null;
                        }
                        else
                        {
                            aux.Prev.Next = aux.Next;
                            aux.Next.Prev = aux.Prev;
                        }
                        Console.WriteLine($"Se eliminó una ocurrencia de {data}");
                        return;
                    }
                    aux = aux.Next;
                }
                Console.WriteLine("No se encontró el dato.");
            }

            public void RemoveAll(T data)
            {
                bool removed = false;
                Node<T> aux = head;

                while (aux != null)
                {
                    if (aux.Data.CompareTo(data) == 0)
                    {
                        removed = true;
                        if (aux == head)
                        {
                            head = head.Next;
                            if (head != null) head.Prev = null;
                        }
                        else if (aux == tail)
                        {
                            tail = tail.Prev;
                            if (tail != null) tail.Next = null;
                        }
                        else
                        {
                            aux.Prev.Next = aux.Next;
                            aux.Next.Prev = aux.Prev;
                        }
                    }
                    aux = aux.Next;
                }

                Console.WriteLine(removed
                    ? $"Se eliminaron todas las ocurrencias de {data}"
                    : "No se encontró el dato.");
            }

            public void ShowGraph()
            {
                if (head == null)
                {
                    Console.WriteLine("Lista vacía.");
                    return;
                }

                Dictionary<T, int> freq = new Dictionary<T, int>();
                Node<T> aux = head;
                while (aux != null)
                {
                    if (!freq.ContainsKey(aux.Data))
                        freq[aux.Data] = 0;

                    freq[aux.Data]++;
                    aux = aux.Next;
                }

                foreach (var item in freq)
                {
                    Console.Write(item.Key + " ");
                    for (int i = 0; i < item.Value; i++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
    }


