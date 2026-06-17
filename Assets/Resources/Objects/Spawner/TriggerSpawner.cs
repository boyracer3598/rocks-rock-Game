using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger. Children count: " + transform.childCount);
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject thisSpawner = transform.GetChild(i).gameObject;
                thisSpawner.GetComponent<SpawnerBehaviour>().KillRock();
                thisSpawner.GetComponent<SpawnerBehaviour>().SpawnRandom();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
