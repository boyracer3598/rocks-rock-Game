using UnityEngine;

public class RockCentering : MonoBehaviour
{
    Vector3 center;
    public GameObject otherObject = null;
    private bool handIn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        center = GetComponent<BoxCollider>().center;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock")) {
            other.gameObject.transform.position = center;
            otherObject = other.gameObject;
        }    
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
            handIn = true;
        else
            handIn = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Rock") && handIn)
        {
            otherObject = null;
        }
    }
}
