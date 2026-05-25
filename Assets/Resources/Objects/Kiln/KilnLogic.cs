using UnityEngine;

public class KilnLogic : MonoBehaviour
{
    public Object LavaBeaker;
    public Object Smoke;
    void RunKiln(GameObject rockObject, int temperature)
    {
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
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
