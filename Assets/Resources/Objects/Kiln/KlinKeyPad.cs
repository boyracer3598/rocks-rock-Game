using TMPro;
using UnityEngine;

public class KlinKeyPad : MonoBehaviour
{
    public string displayTemperature;
    public TextMeshProUGUI displayTemperatureText;
    private int maxDigits = 8;
    public KilnLogic Klin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        displayTemperature = "0";
    }

    // Update is called once per frame
    void Update()
    {
        displayTemperatureText.text = displayTemperature+"C";
    }

    public void addToTemperature(string number) {
        if (displayTemperature == "0")
        {
            displayTemperature = number;
        }
        else if(displayTemperature.Length < maxDigits)
        {
            displayTemperature += number;
        }
    }

    public void clearTemperature() {
        displayTemperature = "0";
    }

    public void startKiln() {
        Klin.setTemperature(int.Parse(displayTemperature));
        displayTemperature = "0";

    }



}
