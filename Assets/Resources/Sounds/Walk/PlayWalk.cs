using UnityEngine;

public class PlayWalk : MonoBehaviour
{
    Vector3 lastPosition;
    float speed;
    [SerializeField] AudioSource walk;
    [SerializeField] AudioClip[] walkClips;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set start position
        lastPosition = transform.position;
        walk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //detect Speed and play the walk sound
        speed = (transform.position - lastPosition).magnitude;
        if (speed > 0){
            if (!walk.isPlaying){
                walk.Play(0);
            }
        //stop when not walking   
        }else if(speed== 0){
            walk.Pause();
        }
        lastPosition = transform.position;
    }
}
