using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // item
    public GameObject Item1;

    // Start is called before the first frame update
    void Start()
    {
        // Generate item
        Instantiate(Item1, new Vector2(0, 6), Quaternion.identity);
    }
}
