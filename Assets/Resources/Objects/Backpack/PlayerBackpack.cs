using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioSource BackpackSound;
    public BackpackFunction backpack;
    void Start()
    {
        BackpackSound= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        // putting a rock into the bag
        if (other.gameObject.CompareTag("Rock"))
        {
            string rock = other.gameObject.GetComponent<Rock>().RockName;
            backpack.objects.Append(rock);
            BackpackSound.Play();
            //Play game sound effect here
            Destroy(other.gameObject);
        }
       
    }

}
