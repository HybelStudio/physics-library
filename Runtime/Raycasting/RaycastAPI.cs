using System;
using System.Collections.Generic;
using System.Linq;
using Hybel.ExtensionMethods;
using UnityEngine;

namespace Hybel
{
    public abstract class RaycastAPI
    {
        protected static bool HitComparer2D(RaycastHit2D h1, RaycastHit2D h2) => h1.collider == h2.collider;

        protected static bool HitComparer(RaycastHit h1, RaycastHit h2) => h1.collider == h2.collider;

        protected static void CheckDistinctAndAdd<T>(bool distinctHits, List<T> items, T item, Func<T, T, bool> comparer)
        {
            if (comparer is null)
                return;

            if (!distinctHits || !items.TrueForOne(i => comparer(i, item)))
                items.Add(item);
        }

        protected static void CheckDistinctAndAdd<T>(bool distinctHits, List<T[]> itemArrays, T[] items, Func<T, T, bool> comparer)
        {
            if (comparer is null)
                return;

            List<T> singleList = new List<T>();
            itemArrays.ForEach(i => singleList.AddRange(i));
            List<T> itemList = items.ToList();

            if (!distinctHits || IsDistinct())
                itemArrays.Add(itemList.ToArray());

            bool IsDistinct()
            {
                for (int i = itemList.Count - 1; i >= 0; i--)
                {
                    T item = itemList[i];
                    foreach (var item2 in singleList)
                        if (comparer(item, item2))
                            itemList.Remove(item);
                }

                return itemList.Count > 0;
            }
        }

        protected static void CheckDistinctAndAdd<T>(bool distinctHits, List<T[][]> itemArrays, T[][] items, Func<T, T, bool> comparer)
        {
            if (comparer is null)
                return;

            List<T> singleList = new List<T>();
            itemArrays.ForEach(i => i.ForEach(j => singleList.AddRange(j)));
            List<T[]> itemArrayList = items.ToList();

            if (!distinctHits || IsDistinct())
                itemArrays.Add(itemArrayList.ToArray());

            bool IsDistinct()
            {
                for (int i = itemArrayList.Count - 1; i >= 0; i--)
                {
                    T[] itemArray = itemArrayList[i];
                    for (int j = 0; j < itemArray.Length; j++)
                    {
                        T item = itemArray[j];
                        foreach (var item2 in singleList)
                            if (comparer(item, item2))
                                itemArrayList.Remove(itemArray);
                    }
                }

                return itemArrayList.Count > 0;
            }
        }

        protected static void CheckDistinctAndAdd<T1, T2>(bool distinctHits, List<T1> items1, T1 item1, List<T2> items2, T2 item2, Func<T1, T1, bool> comparer)
        {
            if (comparer is null)
                return;

            if (!distinctHits || !items1.TrueForOne(i => comparer(i, item1)))
            {
                items1.Add(item1);
                items2.Add(item2);
            }
        }

        protected static void CheckDistinctAndAdd<T1, T2>(bool distinctHits, List<T1[]> itemArrays, T1[] items, List<T2> items2, T2 item2, Func<T1, T1, bool> comparer)
        {
            if (comparer is null)
                return;

            List<T1> singleList1 = new List<T1>();
            itemArrays.ForEach(i => singleList1.AddRange(i));
            List<T1> itemList = items.ToList();

            if (!distinctHits || IsDistinct())
            {
                itemArrays.Add(itemList.ToArray());
                items2.Add(item2);
            }

            bool IsDistinct()
            {
                for (int i = itemList.Count - 1; i >= 0; i--)
                {
                    T1 item = itemList[i];
                    foreach (var item2 in singleList1)
                        if (comparer(item, item2))
                            itemList.Remove(item);
                }

                return itemList.Count > 0;
            }
        }

        protected static void CheckDistinctAndAdd<T1, T2>(bool distinctHits, List<T1[]> itemArrays, T1[] items, List<T2> items2, T2[] item2Array, Func<T1, T1, bool> comparer)
        {
            if (comparer is null)
                return;

            List<T1> singleList1 = new List<T1>();
            itemArrays.ForEach(i => singleList1.AddRange(i));
            List<T1> itemList = items.ToList();

            if (!distinctHits || IsDistinct())
            {
                itemArrays.Add(itemList.ToArray());
                items2.AddRange(item2Array);
            }

            bool IsDistinct()
            {
                for (int i = itemList.Count - 1; i >= 0; i--)
                {
                    T1 item = itemList[i];
                    foreach (var item2 in singleList1)
                        if (comparer(item, item2))
                            itemList.Remove(item);
                }

                return itemList.Count > 0;
            }
        }

        protected static void CheckDistinctAndAdd<T1, T2>(bool distinctHits, List<T1[]> itemArrays, List<T1> itemList, List<T2[]> item2Arrays, T2[] item2Array, Func<T1, T1, bool> comparer)
        {
            if (comparer is null)
                return;

            List<T2> item2List = item2Array.ToList();

            if (!distinctHits || IsDistinct())
            {
                itemArrays.Add(itemList.ToArray());
                item2Arrays.Add(item2List.ToArray());
            }

            bool IsDistinct()
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    T1 item = itemList[i];
                    foreach (T1[] hitArray in itemArrays)
                    {
                        foreach (T1 hit2 in hitArray)
                        {
                            if (comparer(item, hit2))
                            {
                                itemList.Remove(item);
                                item2List.Remove(item2Array[i]);
                            }
                        }
                    }
                }

                return itemList.Count > 0;
            }
        }
                
        protected static void CheckNumberOfRaysForInvalidValue(int numberOfRays)
        {
            if (numberOfRays <= 0)
            {
#if CLOGGER
                global::Clogger.LogWarning<RaycastAPI>("Raycasting", "Number of rays shouldn't be zero or negative.");
#else

#endif
            }
        }

        protected static void CheckNumberOfLayersForInvalidValue(int numberOfLayers)
        {
            if (numberOfLayers <= 0)
                throw new ArgumentOutOfRangeException("Number of layers cannot be zero or negative.");
        }
    }
}