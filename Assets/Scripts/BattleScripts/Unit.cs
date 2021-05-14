using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Information regarding the unit this is attached to
    public string unitName;         // Name
    public int unitLevel;           // Level

    public int damage;              // Damage dealt with atacks

    public int maxHP;               // Max health
    public int currentHP;           // Current health

    public bool TakeDamage(int damage)
    {
        // Take damage
        currentHP -= damage;

        // Check if this unit has died
        if(currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
