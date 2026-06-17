using UnityEngine;

public class RockCentering : MonoBehaviour
{
    public Vector3 center;
    public GameObject otherObject = null;
    private bool handIn = false;

    public void Start()
    {
        center = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock")) {
            other.gameObject.transform.position = center;
            otherObject = other.gameObject;
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            otherObject = null;
        }
    }
}
