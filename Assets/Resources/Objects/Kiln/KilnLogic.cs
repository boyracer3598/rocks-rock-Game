using UnityEngine;

public class KilnLogic : MonoBehaviour
{
    public Object LavaBeaker;
    public Object Smoke;
    public int temperature;
    public bool running = false;
    void RunKiln()
    {
        GameObject rockObject = GetComponentInChildren<RockCentering>().otherObject;
        int rockMeltingPoint = rockObject.GetComponentInChildren<Rock>().MeltingPoint;
        if (rockMeltingPoint == -1)
        {
            Destroy(rockObject);
            Instantiate(Smoke, rockObject.transform.position, rockObject.transform.rotation);
        } 
        else if (temperature >= rockMeltingPoint)
        {
            Destroy(rockObject);
            Instantiate(LavaBeaker, rockObject.transform.position, rockObject.transform.rotation);
        } else
        {
            Debug.Log("Not Hot Enough!!");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void setTemperature(int temperature) {
        this.temperature = temperature;
    }

    // Update is called once per frame
    void Update()
    {
        if(temperature > 0 && GetComponentInChildren<RockCentering>().otherObject != null)
        {
            RunKiln(GetComponentInChildren<RockCentering>().otherObject);
            temperature = 0;
        }

        //if (!running && GetComponentInChildren<RockCentering>().otherObject != null)
        //{
        //    Invoke("RunKiln(GetComponentInChildren<RockCentering>().otherObject)", 5);
        //    running = true;
        //} else if (running && GetComponentInChildren<RockCentering>().otherObject == null)
        //{

        //    CancelInvoke("RunKiln(GetComponentInChildren<RockCentering>().otherObject)");
        //    running = false;
        //}
    }
}
