using Newtonsoft.Json;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

public class Rock : MonoBehaviour
{
    public string RockName;
    public string RockType;
    public string WorldRegion;
    public string Composition;
    public double Density;
    public int MeltingPoint;
    public string fileName = "test";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Refresh();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Refresh()
    {

        string filePathJson = "Assets/Resources/Rocks/Data/" + fileName + ".json";
        string filePathMesh = "Rocks/models/FBX/" + fileName;
        string filePathMaterial = "Rocks/Materials/" + fileName;
        string[] fileText = File.ReadAllLines(filePathJson);
        string fileTextOneLine = "";
        for (int i = 0; i < fileText.Length; i++)
        {
            fileTextOneLine += fileText[i];
        }
        Rock temp = JsonConvert.DeserializeObject<Rock>(fileTextOneLine);
        this.RockName = temp.RockName;
        this.RockType = temp.RockType;
        this.WorldRegion = temp.WorldRegion;
        this.Composition = temp.Composition;
        this.Density = temp.Density;
        this.MeltingPoint = temp.MeltingPoint;
        Debug.Log(RockName + ", " + RockType + ", " + WorldRegion + ", " + Composition + ", " + Density + ", " + MeltingPoint);
        Material newMaterial = (Material)Resources.Load(filePathMaterial);
        GetComponent<Renderer>().material = newMaterial;
        GameObject model = Resources.Load<GameObject>(filePathMesh);
        GetComponent<MeshFilter>().sharedMesh = model.GetComponent<MeshFilter>().sharedMesh;
    }
}
