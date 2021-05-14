using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    // Unit's UI attributes
    public Text unitName;
    public Text unitLevel;
    public Slider healthbar;

    // Setting the attributes
    public void SetHUD(Unit unit)
    {
        unitName.text = unit.unitName;
        unitLevel.text = "Level " + unit.unitLevel;
        healthbar.maxValue = unit.maxHP;
        healthbar.value = unit.currentHP;
    }

    // Updating health
    public void SetHP(int hp)
    {
        healthbar.value = hp;
    }
}
