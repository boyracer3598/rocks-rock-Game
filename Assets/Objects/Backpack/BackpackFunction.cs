using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using static UnityEditor.FilePathAttribute;
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
public class BackpackFunction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ItsAlmostAStack<string> objects = new ItsAlmostAStack<string>();
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "rock pickup")
        {
            string rock = other.gameObject.GetComponent<Rock>().RockName;
            objects.Append(rock);
            Destroy(other.gameObject);
        }
    }
    public void RemoveRock()
    {
        if (objects.Size() > 0)
        {
            GameObject newRock = (GameObject)Instantiate(Resources.Load("rock pickup"));
            newRock.GetComponent<Rock>().fileName = (string)objects.Pop();
            // newRock.GetComponent<Rock>().Refresh();
        }
    }
    public void RemoveRock(int location)
    {
        GameObject newRock = (GameObject)Instantiate(Resources.Load("rock pickup"));
        newRock.GetComponent<Rock>().fileName = (string)objects.Remove(location);
        // newRock.GetComponent<Rock>().Refresh();
    }
    public void EmptyBag()
    {
        for (int i = 0; i < objects.Size(); i++)
        {
            GameObject newRock = (GameObject)Instantiate(Resources.Load("rock pickup"));
            newRock.GetComponent<Rock>().fileName = (string)objects.Stab();
            // newRock.GetComponent<Rock>().Refresh();
        }
    }
}
