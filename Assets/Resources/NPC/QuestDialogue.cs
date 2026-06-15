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
    public KayStack<string> CompletedQuests = new();
    public Dictionary<string, string> CurrentQuest = new();
    public string CurrentQuestText;
    public GameObject RockForQuest;
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
        CurrentQuest.Add("Condition", "");
        CurrentQuest.Add("RockNeeded", "");
        NewQuest();
    }
    void NewQuest()
    {
        string GimmeARock = RockNames.GrabRandom();
        string RandomQuestType = QuestTypes.ElementAt((int)Random.Range(0, QuestTypes.Count)).Key;
        CurrentQuest["RockNeeded"] = GimmeARock;
        CurrentQuest["Condition"] = RandomQuestType;
        CurrentQuestText = DisplayQuest(CurrentQuest["RockNeeded"], CurrentQuest["Condition"]);
        Debug.Log(CurrentQuestText);
    }
    string DisplayQuest(string rock, string Condition)
    {
        string text = "";
        if (Condition == "Combusts" || Condition == "Melts") text = QuestTypes[Condition];
        else text = QuestTypes[Condition] + " " + rock;
        return text;
    }
    bool CanComplete(GameObject Rock, string Condition, string rockNeeded)
    {
        Rock thisRock = Rock.GetComponent<Rock>();
        string filePathJson = "Assets/Resources/Rocks/Data/" + rockNeeded + ".json";
        string[] fileText = File.ReadAllLines(filePathJson);
        string fileTextOneLine = "";
        for (int i = 0; i < fileText.Length; i++)
        {
            fileTextOneLine += fileText[i];
        }
        SubRock otherRock = JsonConvert.DeserializeObject<SubRock>(fileTextOneLine);
        if (Condition == "Find") return (thisRock.RockName == rockNeeded);
        else if (Condition == "HeavierThan") return (thisRock.Density > otherRock.Density);
        else if (Condition == "LighterThan") return (thisRock.Density < otherRock.Density);
        else if (Condition == "Combusts") return (thisRock.MeltingPoint == -1);
        else if (Condition == "Melts") return (thisRock.MeltingPoint != -1);
        else return false;
    }
    // Update is called once per frame
    void Update()
    {
        RockForQuest = GetComponentInChildren<RockCentering>().otherObject;
        if (RockForQuest != null)
        {
            if (CanComplete(RockForQuest, CurrentQuest["Condition"], CurrentQuest["RockNeeded"]))
            {
                Destroy(RockForQuest);
                Debug.Log("winner!!!");
            }
        }
    }
}
