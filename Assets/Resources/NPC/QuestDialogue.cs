using UnityEngine;
using Kay.Data;
using NUnit.Framework;
using System.IO;
using Newtonsoft.Json;
public class Rocks
{
    public string[] RockNameList;
}
public class QuestDialogue : MonoBehaviour
{
    KayStack<string> RockNames;
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
        for (int i =0; i < temp.RockNameList.Length; i++)
        {
            RockNames.Append(temp.RockNameList[i]);
        }
    }
    void NewQuest()
    {
        string GimmeARock = RockNames.GrabRandom();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
