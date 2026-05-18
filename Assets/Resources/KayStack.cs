using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Kay.Data
{
    public class ItsAlmostAStack<T>
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
        //public T RemoveFirstByName(T index)
        //{
        //    T value = index;
        //    bool complete = false;
        //    for (int i = 0; i < items.Count; i++)
        //    {
        //        if (items[i] == index)
        //        {
        //            T temp = items[i];
        //            items.RemoveAt(i);
        //            value = temp;
        //            complete = true;
        //            break;
        //        }
        //    }
        //    if (complete)
        //    {
        //        return value;
        //    } else
        //    {
        //        return default(T);
        //    }
        //}
        public int Size()
        {
            return items.Count;
        }
    }

}
