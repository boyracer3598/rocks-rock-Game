using UnityEngine;
using UnityEngine.Animations;

public class LockingJoint : MonoBehaviour
{
    private RotationConstraint RC;
    private PositionConstraint PC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door")){
           RC= other.gameObject.GetComponent<RotationConstraint>();
            RC.locked = true;
            
        }else if (other.gameObject.CompareTag("Draw")){
            PC = other.gameObject.GetComponent<PositionConstraint>();
            PC.locked = true;
        }
    
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
