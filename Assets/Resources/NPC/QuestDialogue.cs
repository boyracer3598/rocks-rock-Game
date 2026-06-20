using Kay.Data;
//using Mono.Cecil.Cil;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
public class Rocks
{
    public string[] RockNameList;
}
public class QuestDialogue : MonoBehaviour
{
    public TextMeshProUGUI WantQuestText;
    public KayStack<string> CompletedQuests = new();
    public Dictionary<string, string> CurrentQuest = new();
    public Dictionary<string, string> DisplayedQuest = new();
    public string CurrentQuestText;
    public GameObject RockForQuest;
    [SerializeField]AudioSource QuestCompleteSound;
    KayStack<string> RockNames = new();
    Dictionary<string, string> QuestTypes = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QuestCompleteSound= GetComponent<AudioSource>();
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
        CurrentQuest.Add("RockNeeded", "test");
        DisplayedQuest.Add("Condition", "");
        DisplayedQuest.Add("RockNeeded", "");
        NewQuest();
    }
    public void NewQuest()
    {
        string GimmeARock = RockNames.GrabRandom();
        string RandomQuestType = QuestTypes.ElementAt(Random.Range(0, QuestTypes.Count)).Key;
        DisplayedQuest["RockNeeded"] = GimmeARock;
        DisplayedQuest["Condition"] = RandomQuestType;
        WantQuestText.text = DisplayQuest(DisplayedQuest["RockNeeded"], DisplayedQuest["Condition"]);
    }
    public void AcceptQuest()
    {
        CurrentQuest["RockNeeded"] = DisplayedQuest["RockNeeded"];
        CurrentQuest["Condition"] = DisplayedQuest["Condition"];
        CurrentQuestText = DisplayQuest(CurrentQuest["RockNeeded"], CurrentQuest["Condition"]);
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
    public void CompleteQuest()
    {
        CompletedQuests.Append(CurrentQuestText);
        QuestCompleteSound.Play();
        Debug.Log("Completed quest: " + CurrentQuestText);
        CurrentQuest["Condition"] = "";
        CurrentQuest["RockNeeded"] = "";
        CurrentQuestText = "";
        Destroy(RockForQuest);
        NewQuest();
        RockForQuest = null;
    }
    // Update is called once per frame
    void Update()
    {
        RockForQuest = GetComponentInChildren<RockCentering>().otherObject;
        if (RockForQuest != null)
        {
            if (CanComplete(RockForQuest, CurrentQuest["Condition"], CurrentQuest["RockNeeded"])) CompleteQuest();
        }
    }
}
