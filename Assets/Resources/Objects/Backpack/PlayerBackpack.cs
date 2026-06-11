using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public BackpackFunction backpack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("its a trigger  "+ other.gameObject.tag+ other.gameObject.name);



        // putting a rock into the bag
        if (other.gameObject.CompareTag("Rock"))
        {
            string rock = other.gameObject.GetComponent<Rock>().RockName;
            backpack.objects.Append(rock);
            Destroy(other.gameObject);
            // grabing a rock out of the bag
        }
       
    }

}
