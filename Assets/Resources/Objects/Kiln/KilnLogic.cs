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
            Instantiate(Smoke);
        } 
        else if (rockMeltingPoint > temperature)
        {
            Destroy(rockObject);
            Instantiate(LavaBeaker);
        } else
        {
            Debug.Log("Not Hot Enough!!");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!running && GetComponentInChildren<RockCentering>().otherObject != null)
        {
            Invoke(nameof(RunKiln), 5);
            running = true;
        } else if (running && GetComponentInChildren<RockCentering>().otherObject == null)
        {
            CancelInvoke(nameof(RunKiln));
            running = false;
        }
    }
}
