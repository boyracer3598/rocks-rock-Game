using NUnit.Framework;
using UnityEngine;
using Kay.Data;
using TMPro;
public class AnalyzeRock : MonoBehaviour
{
    public GameObject AnalysedRock;
    public GameObject MainScreen;
    public TextMeshProUGUI DataList;
    KayStack<string> GetData(GameObject a)
    {
        KayStack<string> temp = new();
        Rock thisRock = a.GetComponentInChildren<Rock>();
        if (thisRock.RockName != "" )
        {
            temp.Append("Name: " + (string)thisRock.RockName);
            temp.Append("Type: " + (string)thisRock.RockType);
            temp.Append("Details: " + (string)thisRock.RockVariety);
            temp.Append("Chemical Composition: " + (string)thisRock.Composition);
            temp.Append("Rock Density: " + (string)thisRock.Density.ToString() + "kg/m^3");
            //check if the rock melts or combusts at high temperatures
            if (thisRock.MeltingPoint >= 0)
            {
                temp.Append("Melting Point: " + (string)thisRock.MeltingPoint.ToString() + "°C");
            } else
            {
                temp.Append("Melting Point: Doesn't melt; combusts");
            }
        }
        return temp;
    }
    void UpdateScreen()
    {
        if (AnalysedRock != null)
        {

            KayStack<string> Data = GetData(AnalysedRock);
            DataList.text = "\n";
            for (int i = 0; i < Data.Size(); i++)
            {
                DataList.text += Data.Grab(i) + "\n";
            }
        } else
        {
            DataList.text = "Calculating data..........";
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DataList = MainScreen.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        AnalysedRock = GetComponentInChildren<RockCentering>().otherObject;
        UpdateScreen();
    }
}
