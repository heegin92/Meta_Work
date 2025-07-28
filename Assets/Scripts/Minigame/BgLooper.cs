using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5; // Number of background objects to loop
    public int obstaclCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstaclCount = obstacles.Length;

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstaclCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with " + collision.name);

        if (collision.CompareTag("Background"))
        {
            // Handle background collision if needed
            float widthOfBgObject = collision.GetComponent<SpriteRenderer>().bounds.size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
         }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstaclCount);
        }
    }
}
