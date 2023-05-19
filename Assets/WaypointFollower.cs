using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    private int currwp = 0;

    private float speed = 0.5f;

    private void Update()
    {

        if (Vector2.Distance(waypoints[currwp].transform.position, transform.position) < 0.1f){

            currwp++;
            if (currwp >= waypoints.Length){

                currwp = 0;

            }
            
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currwp].transform.position, Time.deltaTime * speed);
        
    }
}
