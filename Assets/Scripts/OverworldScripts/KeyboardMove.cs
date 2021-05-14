using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour
{
    Rigidbody2D rb;                         // Player's Rigidbody
    Animator pa;                            // Player's Animator
    public float distancePerSecond = 5f;    // Player's speed
    public static bool item = false;        // Player's "inventory"

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pa = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Amount to move in each dimension
        float dx = 0;
        float dy = 0;

        // Player can move until they collect item
        if (!item)
        {
            // Move up
            if (Input.GetKey (KeyCode.W)) {
                dy = distancePerSecond * Time.deltaTime;
                pa.SetBool("movingUpDown", true);
                pa.SetBool("movingRight", false);
                pa.SetBool("movingLeft", false);
            }
            // Move down
            if (Input.GetKey (KeyCode.S)) {
                dy = -distancePerSecond * Time.deltaTime;
                pa.SetBool("movingUpDown", true);
                pa.SetBool("movingRight", false);
                pa.SetBool("movingLeft", false);
            }
            // Move left
            if (Input.GetKey (KeyCode.A)) {
                dx = -distancePerSecond * Time.deltaTime;
                pa.SetBool("movingUpDown", false);
                pa.SetBool("movingLeft", true);
                pa.SetBool("movingRight", false);
            }
            // Move right
            if (Input.GetKey (KeyCode.D)) {
                dx = distancePerSecond * Time.deltaTime;
                pa.SetBool("movingUpDown", false);
                pa.SetBool("movingLeft", false);
                pa.SetBool("movingRight", true);
            }
            // Move by that amount
            rb.position += new Vector2(dx, dy);
        }
    }
}
