using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RivalMovement : MonoBehaviour
{
    Rigidbody2D rb;                     // This object's Rigidbody
    Rigidbody2D wayrb;                  // Rigidbody of current target waypoint
    Animator ra;                        // This object's Animator
    float distancePerSecond = 3f;       // Movement speed
    bool isMoving = true;               // This object can move
    public static bool canSpeak = false;// Battle message can be displayed

    // Waypoints array
    public GameObject[] waypoints;
    // Keep track of current waypoint
    int count = 0;
    // Has object reached waypoint
    bool waypoint = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ra = GetComponent<Animator>();
        count = 0;
        wayrb = waypoints[count].GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move to player when they collect item
        if (KeyboardMove.item && isMoving)
        {
            // Move to waypoint first
            // Move towards current waypoint location 
            Vector2 delta = wayrb.position - rb.position;
            delta.Normalize();
            delta = delta * distancePerSecond;
            rb.position += delta * Time.deltaTime;
            ra.SetBool("moveLeft", true);
            ra.SetBool("moveUp", false);

            if (waypoint)
            {
                canSpeak = true;

                if (Input.GetKeyDown("k"))
                {
                    SceneManager.LoadScene("BattleScene");
                }



                /*
                GameObject p = GameObject.FindWithTag("Player");    // p = player
                if (p == null) return;

                Rigidbody2D prb = p.GetComponent<Rigidbody2D>();    // prb = player Rigidbody

                // Move toward player
                delta = prb.position - rb.position;
                delta.Normalize();
                rb.position += delta * distancePerSecond * Time.deltaTime;
                ra.SetBool("moveLeft", false);
                ra.SetBool("moveUp", true);
                */
            }
        }
    }

    // When waypoint is reached
    void OnTriggerEnter2D(Collider2D c)
    {
        GameObject g = c.gameObject;

        // Make sure this is the waypoint we are looking for
        if (g == waypoints[count])
        {
            // Move to player next
            waypoint = true;
        }
    }

    /*
    // When player is reached
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject p = collision.gameObject;
        if (p.CompareTag("Player"))
        {
            Debug.Log("player reached");
            // Stop moving
            isMoving = false;
            // Deliver message
            canSpeak = true;
            Debug.Log("canSpeak = true");
        }
    }
    */
}
