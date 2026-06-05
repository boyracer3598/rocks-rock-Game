using UnityEngine;

public class BatMove : MonoBehaviour
{
    [SerializeField] Transform[] Points;// the points the bat will move to
    [SerializeField] float Speed;

    private int currentPointIndex = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Points[currentPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        //move towards the current point
        transform.position = Vector3.MoveTowards(transform.position, Points[currentPointIndex].position, Speed * Time.deltaTime);
        transform.LookAt(Points[currentPointIndex].position);// make the bat look at the point it is moving towards

        if (Vector3.Distance(transform.position, Points[currentPointIndex].position) < 0.1f)
        {
            //make it do a loop of the points
            if (currentPointIndex >= Points.Length - 1)
            {
                currentPointIndex = 0;
            }
            else
            {
                currentPointIndex = currentPointIndex + 1 ;
            }
        }
    }
}
