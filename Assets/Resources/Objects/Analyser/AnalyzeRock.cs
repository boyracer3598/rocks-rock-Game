using NUnit.Framework;
using UnityEngine;
using Kay.Data;
public class AnalyzeRock : MonoBehaviour
{
    KayStack<string> GetData(GameObject a)
    {
        KayStack<string> temp = new();
        Rock thisRock = a.GetComponentInChildren<Rock>();
        if (thisRock.RockName != "" )
        {
            temp.Append((string)thisRock.RockName);
            temp.Append((string)thisRock.RockType);
            temp.Append((string)thisRock.WorldRegion);
            temp.Append((string)thisRock.Composition);
            temp.Append((string)thisRock.Density.ToString());
            temp.Append((string)thisRock.MeltingPoint.ToString());
        }
        return temp;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
