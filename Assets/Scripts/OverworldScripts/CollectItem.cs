using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    Rigidbody2D rb;                     // This object's Rigidbody
    private bool collected = false;     // Has player collected item

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(collected)
        {
            if (Input.GetKeyDown (KeyCode.K))
            {
                // Player has collected item
                KeyboardMove.item = true;
                // Rival stops following waypoints
                RivalPath.pathfinding = true;
                Destroy(this.gameObject);
            }
        }
    }

    // Player only able to collect item when in range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if object collided with is player
        GameObject p = collision.gameObject;
        if (p.CompareTag("Player"))
        {
            collected = true;
        }
    }
}
