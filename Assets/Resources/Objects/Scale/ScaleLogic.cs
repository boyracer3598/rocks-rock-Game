using UnityEngine;

public class ScaleLogic : MonoBehaviour
{
    public bool leftHeavy = true;
    public GameObject left, right;
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
            double ghetsis = calculateDifference(left.GetComponent<Rock>().Density, right.GetComponent<Rock>().Density);
            Debug.Log(ghetsis);
            if (leftHeavy == true)
            {
                heavyToInt = 1;
            }
            else
            {
                heavyToInt = -1;
            }
            GameObject.FindWithTag("Bowl1").transform.transform.position = new Vector3 (0, (float)(0 + (1000 / (ghetsis * heavyToInt))), 0);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        MachineStart();
    }
}
