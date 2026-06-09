using UnityEngine;
using Kay.Data;
using NUnit.Framework;
using System.IO;
using Newtonsoft.Json;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Linq;
public class Rocks
{
    public string[] RockNameList;
}
public class QuestDialogue : MonoBehaviour
{
    KayStack<string> RockNames = new();
    Dictionary<string, string> QuestTypes = new();
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
        QuestTypes.Add("Find", "Bring me a");
        QuestTypes.Add("HeavierThan", "Bring me a rock that's heavier than");
        QuestTypes.Add("LighterThan", "Bring me a rock that's lighter than");
        QuestTypes.Add("Combusts", "Bring me a rock that combusts");
        QuestTypes.Add("Melts", "Bring me a rock that melts");
        NewQuest();
    }
    void NewQuest()
    {
        string GimmeARock = RockNames.GrabRandom();
        string RandomQuestType = QuestTypes.ElementAt(3).Value;
        Debug.Log(RandomQuestType + GimmeARock);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
