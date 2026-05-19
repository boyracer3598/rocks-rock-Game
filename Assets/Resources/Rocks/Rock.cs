using Newtonsoft.Json;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

public class Rock : MonoBehaviour
{
    public string RockName { get; private set; }
    public string RockType { get; private set; }
    public string WorldRegion { get; private set; }
    public string Composition { get; private set; }
    public double Density { get; private set; }
    public int MeltingPoint { get; private set; }
    [SerializeField] public string fileName = "test";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string filePathJson = "Assets/Resources/Rocks/Data/" + fileName + ".json";
        string filePathMesh = "Assets/Resources/Rocks/models" + fileName + ".obj";
        string filePathMaterial = "Assets/Resources/Rocks/Materials" + fileName + ".mat";
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
        // Debug.Log(RockName + ", " + RockType + ", " + WorldRegion + ", " + Composition + ", " + Density + ", " + MeltingPoint);
        Material materialToChange = this.gameObject.transform.GetChild(0).GetComponent<Renderer>().material;
        MeshFilter meshToChange = this.gameObject.GetComponent<MeshFilter>();
        if (materialToChange.name != this.RockName) //|| meshToChange.name != this.RockName
        {
            materialToChange = (Material)Resources.Load(filePathMaterial);
            meshToChange.sharedMesh = (Mesh)Resources.Load(filePathMesh);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
