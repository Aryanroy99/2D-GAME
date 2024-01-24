using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moument_follower : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoint;
    private int currentwaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    
    // Update is called once per frame
   private void Update()
    {
        if(Vector2.Distance(Waypoint[currentwaypointIndex].transform.position , transform.position) < .1f)
        {
            currentwaypointIndex++;
            if(currentwaypointIndex >= Waypoint.Length)
            {
                currentwaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Waypoint[currentwaypointIndex].transform.position , Time.deltaTime * speed);
        
    }
}
