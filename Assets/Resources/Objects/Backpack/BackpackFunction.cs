using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using static UnityEditor.FilePathAttribute;
using Kay.Data;

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
