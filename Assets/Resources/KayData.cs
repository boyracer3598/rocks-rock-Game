using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Kay.Data
{
    public class KayStack<T>
    {

        private List<T> items = new List<T>();

        public void Append(T item)
        {
            items.Add(item);
        }
        public void Prepend(T item)
        {
            items.Prepend(item);
        }
        public T Pop()
        {
            if (items.Count > 0)
            {
                T temp = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);
                return temp;
            }
            else
                return default(T);
        }
        public T PopGrab()
        {
            if (items.Count > 0)
            {
                return items[items.Count - 1];
            }
            else
                return default(T);
        }
        public T Stab()
        {
            if (items.Count > 0)
            {
                T temp = items[0];
                items.RemoveAt(0);
                return temp;
            }
            else
                return default(T);
        }
        public T StabGrab()
        {
            if (items.Count > 0)
            {
                return items[0];
            }
            else
                return default(T);
        }
        public T Remove(int itemAtPosition)
        {
            if (items.Count > 0)
            {
                T temp = items[itemAtPosition];
                items.RemoveAt(itemAtPosition);
                return temp;
            }
            else
                return default(T);
        }
        public T Grab(int itemAtPosition)
        {
            if (items.Count > 0)
            {
                return items[itemAtPosition];
            }
            else
                return default(T);
        }
        public int Size()
        {
            return items.Count;
        }
        public List<T> GrabAll()
        {
            List<T> tempList = new List<T>();
            for (int i = 0; i < Size(); i++)
            {
                tempList.Append(items[i]);
            }
            return tempList;
        }
    }
}