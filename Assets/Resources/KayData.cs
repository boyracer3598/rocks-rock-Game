using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Kay.Data
{
    public class KayStack<T>
    {

        private List<T> items = new();

        public void Append(T item) /*Adds an item to the end of the kaystack*/
        {
            items.Add(item);
        }
        public void Prepend(T item) /*Adds an item to the start of the kaystack*/
        {
            items.Prepend(item);
        }
        public T Pop() /*Removes and returns the last item of the kaystack*/
        {
            if (items.Count > 0)
            {
                T temp = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);
                return temp;
            }
            else
                return default;
        }
        public T PopGrab() /*Returns the last item of the kaystack*/
        {
            if (items.Count > 0)
            {
                return items[items.Count - 1];
            }
            else
                return default;
        }
        public T Stab() /*Removes and returns the first item of the kaystack*/
        {
            if (items.Count > 0)
            {
                T temp = items[0];
                items.RemoveAt(0);
                return temp;
            }
            else
                return default;
        }
        public T StabGrab() /*Returns the first item of the kaystack*/
        {
            if (items.Count > 0)
            {
                return items[0];
            }
            else
                return default;
        }
        public T Remove(int itemAtPosition) /*Removes and returns the item at a specific position*/
        {
            if (items.Count > 0)
            {
                T temp = items[itemAtPosition];
                items.RemoveAt(itemAtPosition);
                return temp;
            }
            else
                return default;
        }
        public T Grab(int itemAtPosition) /*Returns the item at a specific position*/
        {
            if (items.Count > 0)
            {
                return items[itemAtPosition];
            }
            else
                return default;
        }
        public int Size() /*What do you think this does*/
        {
            return items.Count;
        }
        public List<T> GrabAll() /*Creates and returns a list containing each item in the kaystack*/
        {
            List<T> tempList = new();
            for (int i = 0; i < Size(); i++)
            {
                tempList.Append(items[i]);
            }
            return tempList;
        }
        public T GrabRandom(int min = 0, int max = 0)
        {
            Random rnd = new();
            int outputNo;
            if (max == 0)
            {
                max = Size();
            }
            if (max != 0)
            {
                outputNo = (int)Math.Floor((decimal)rnd.Next(min, max));
            }
            else
                outputNo = 0;
            return items[outputNo];
        }
    }
}