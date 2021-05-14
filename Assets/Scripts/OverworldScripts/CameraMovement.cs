using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;           // GameObject camera follows
    Rigidbody2D rb;                     // Its Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        // Get player y
        //float playerX = rb.position.x;
        float playerY = rb.position.y;

        // Get camera x and z
        float cameraX = transform.position.x;
        float cameraZ = transform.position.z;

        // Move camera to new position
        transform.position = new Vector3(cameraX, playerY, cameraZ);
    }
}
