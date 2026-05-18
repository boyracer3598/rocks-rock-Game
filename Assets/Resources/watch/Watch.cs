using TMPro;
using UnityEngine;

public class Watch : MonoBehaviour
{
    public GameObject labTeleportPoint;
    public Vector3 caveTeleportPoint;
    public GameObject player;
    public GameObject telepotButton;
    public TextMeshProUGUI telepportButtonText;
    public bool isInLab = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        telepportButtonText = telepotButton.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
