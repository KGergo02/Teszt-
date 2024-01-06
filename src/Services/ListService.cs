using System;
using System.Collections.Generic;

namespace Teszt__.src.Services
{
    public static class ListService
    {
        public static List<T> Shuffle<T>(List<T> list)
        {
            List<T> newList = new List<T>();

            while (list.Count != 0)
            {
                Random rnd = new Random();

                int index = rnd.Next(0, list.Count);

                newList.Add(list[index]);

                list.RemoveAt(index);
            }

            return newList;
        }
    }
}
