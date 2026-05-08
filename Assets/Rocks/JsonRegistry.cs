using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class Rock
{
    public string RockName { get; set; }
    public string RockType { get; set; }
    public string WorldRegion { get; set; }
    public string Composition { get; set; }
    public double Density { get; set; }
    public int MeltingPoint { get; set; }
}
public class JsonRegistry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rock test = new Rock();
        test.RockName = "testRock";
        test.RockType = "pith";
        test.WorldRegion = "asia";
        test.Composition = "NaCl";
        test.Density = 12.32;
        test.MeltingPoint = 500;
        string json = JsonUtility.ToJson(test);
        StreamWriter text = new StreamWriter("test.json", false);
        text.Write(json);
        text.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
