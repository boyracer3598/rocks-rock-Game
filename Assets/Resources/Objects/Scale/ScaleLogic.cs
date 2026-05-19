using UnityEngine;

public class ScaleLogic : MonoBehaviour
{
    public bool leftHeavy = true;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
