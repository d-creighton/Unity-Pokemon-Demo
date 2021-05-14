using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalPath : MonoBehaviour
{
    // Waypoints array
    public GameObject[] waypoints;

    // Keep track of current waypoint
    int count = 0;

    float speed = 5.0f;
    Rigidbody2D rb;     // This object's rigidbody
    Rigidbody2D wayrb;  // Rigidbody of current target waypoint

    public static bool pathfinding = true;    // Is this object following waypoints

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        wayrb = waypoints[count].GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pathfinding)
        {
            // Move towards current waypoint location 
            Vector2 delta = wayrb.position - rb.position;
            delta.Normalize();
            delta = delta * speed;
            rb.position += delta * Time.deltaTime;
        }
    }

    // We are considered to have "reached" a waypoint when we hit
    // its collider (which should be a trigger).
    void OnTriggerEnter2D(Collider2D c)
    {
        GameObject g = c.gameObject;

        // Make sure this is the waypoint we are looking for
        if (g == waypoints[count])
        {
            // If so, now look for the next waypoint
            count++;
            if (count >= waypoints.Length)
            {
                count = 0;
            }
            // Get the Rigidbody of that waypoint
            wayrb = waypoints[count].GetComponent<Rigidbody2D>();
        }
    }
}
