using UnityEngine;

public class ScaleLogic : MonoBehaviour
{
    public bool leftHeavy = true;
    public GameObject left, right;
    public Vector3 bowl1location, bowl2location;
    double difference;
    double calculateDifference(double a, double b) //a = left b = right
    {
        double result;
        if (a > b)
        {
            leftHeavy = false;
            result = a - b;
        } else if (a < b)
        {
            result = b - a;
        } else
        {
            result = 0;
            leftHeavy = false;
        }
        return result;
    }
    void MachineStart()
    {
        if (left.GetComponent<Rock>().RockName != "" && right.GetComponent<Rock>().RockName != "")
        {
            int heavyToInt =0;
            difference = calculateDifference(left.GetComponent<Rock>().Density, right.GetComponent<Rock>().Density);
            GameObject heavyRock;
            if (leftHeavy == true)
            {
                heavyToInt = 1;
                heavyRock = left;
            }
            else
            {
                heavyToInt = -1;
                heavyRock = right;
            }
            float bowl1LocationY = (bowl1location.y + 1/((float)difference / (float)heavyRock.GetComponent<Rock>().Density * 100) * heavyToInt);
            GameObject.FindWithTag("Bowl1").transform.position = new Vector3 (bowl1location.x, bowl1LocationY, bowl1location.z);
            float bowl2LocationY = (bowl2location.y + 1/((float)difference / (float)heavyRock.GetComponent<Rock>().Density * 100) * heavyToInt * -1);
            if (bowl2LocationY == float.NegativeInfinity || bowl2LocationY == float.PositiveInfinity)
            {
                bowl1LocationY = 0;
                bowl2LocationY = 0;
            }
            GameObject.FindWithTag("Bowl2").transform.position = new Vector3(bowl2location.x, bowl2LocationY, bowl2location.z);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bowl1location = GameObject.FindWithTag("Bowl1").transform.position;
        bowl2location = GameObject.FindWithTag("Bowl2").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.Find("bowl1Centerer").GetComponent<RockCentering>().otherObject != null && transform.Find("bowl2Centerer").GetComponent<RockCentering>().otherObject != null)
        {
            left = transform.Find("bowl1Centerer").GetComponent<RockCentering>().otherObject;
            right = transform.Find("bowl2Centerer").GetComponent<RockCentering>().otherObject;
            MachineStart();
        }
    }
}
