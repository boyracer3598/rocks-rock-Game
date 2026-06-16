using Kay.Data;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
public class SpawnerBehaviour : MonoBehaviour
{
    KayStack<string> RockNames = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        string filePathJson = "Assets/Resources/NPC/RockList.json";
        string[] fileText = File.ReadAllLines(filePathJson);
        string fileTextOneLine = "";
        for (int i = 0; i < fileText.Length; i++)
        {
            fileTextOneLine += fileText[i];
        }
        Rocks temp = JsonConvert.DeserializeObject<Rocks>(fileTextOneLine);
        for (int i = 0; i < temp.RockNameList.Length; i++)
        {
            this.RockNames.Append(temp.RockNameList[i]);
        }
    }
    void Spawn(string rock )
    {
        Vector3 position = transform.position + new Vector3(0, 1, 0);
        GameObject newRock = (GameObject)Instantiate(Resources.Load("rock pickup"), this.transform);
        newRock.GetComponent<Rock>().fileName = rock;
        newRock.GetComponent<Rock>().Refresh();
        Debug.Log("Spawned " + rock);
    }
    public void SpawnRandom()
    {
        Spawn(this.RockNames.GrabRandom());
    }
    public void KillRock()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
            Debug.Log("Killed rock");
        }
    }
}
