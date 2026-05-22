using System;
using TMPro;
using UnityEngine;
using Kay.Data;
using System.Collections.Generic;
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
    public List<string> bagOfRocks;
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
        //Debug.Log( backpack.objects.Size());
        bagOfRocks = backpack.objects.GrabAll();
        rockListText.text = "";
        
        for( int i=0; i<backpack.objects.Size(); i++)
        {
            //Debug.Log(backpack.objects.GrabAll()); ;
            rockListText.text += ".\n" + "-: " + backpack.objects.Grab(i);

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
