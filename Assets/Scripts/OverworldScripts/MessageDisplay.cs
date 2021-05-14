using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    public Text battleMessage;         // Rival's message to player
    public Image bg;                   // Message background

    // Start is called before the first frame update
    void Start()
    {
        battleMessage = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RivalMovement.canSpeak)
        {
            // Display message when rivaL encounters player
            bg.enabled = true;
            battleMessage.text = "Hey you! Let's battle!";
        }
        else
        {
            bg.enabled = false;
            battleMessage.text = "";
        }
    }
}
