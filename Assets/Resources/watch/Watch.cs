using System;
using TMPro;
using UnityEngine;
using Kay.Data;
public class Watch : MonoBehaviour
{
    public GameObject labTeleportPoint;
    public Vector3 caveTeleportPoint;
    public GameObject player;
    public GameObject telepotButton;
    public TextMeshProUGUI telepportButtonText;
    public bool isInLab = false;
    public GameObject rockList;
    public TextMeshProUGUI rockListText;
    public BackpackFunction backpack;
    public KayStack<string> bagOfRocks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        telepportButtonText = telepotButton.GetComponent<TextMeshProUGUI>();
        rockListText = rockList.GetComponent<TextMeshProUGUI>();
        rockListText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        bagOfRocks = backpack.objects;
        if (bagOfRocks.Size() > 0)
        {
            for( int i=0; i<bagOfRocks.Size(); i++)
            {
                rockListText.text += bagOfRocks.Pop();
            }
        }
        
        

    }

    public void telportToLab()
    {
        if (isInLab)
        {
            telepportButtonText.text = "Teleport to Lab";
            player.transform.transform.position = caveTeleportPoint;
            isInLab = false;
        }
        else
        {
            telepportButtonText.text = "Teleport to Cave";
            caveTeleportPoint = player.transform.transform.position;
            player.transform.transform.position = labTeleportPoint.transform.position;
            isInLab = true;
        }
    }     
}
