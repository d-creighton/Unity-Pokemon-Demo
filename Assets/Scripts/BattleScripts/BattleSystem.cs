using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Determine current battle state
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;           // Reference to battle state

    public GameObject playerPrefab;     // Spawn player
    public GameObject enemyPrefab;      // Spawn enemy

    public Text battleText;             // Menu text to display

    public BattleHUD playerHUD;         // Player HUD
    public BattleHUD enemyHUD;          // Enemy HUD

    Unit playerUnit;                    // Reference to player unit
    Unit enemyUnit;                     // Reference to enemy unit

    // Start is called before the first frame update
    void Start()
    {
        // Start of battle
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        // Spawn units
        GameObject p = Instantiate(playerPrefab, new Vector2(-6f, -1.5f), Quaternion.identity);    // player gameobject
        playerUnit = p.GetComponent<Unit>();

        GameObject e = Instantiate(enemyPrefab, new Vector2(6f, 1.75f), Quaternion.identity);       // enemy gameobject
        enemyUnit = e.GetComponent<Unit>();

        // Starting message
        battleText.text = "Rival challenges you to a battle!";

        // Initiate HUD elements
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        // Add time delay
        yield return new WaitForSeconds(2f);

        // Player's turn
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        // Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        // Update HUD
        enemyHUD.SetHP(enemyUnit.currentHP);
        battleText.text = playerUnit.unitName + " attacks!";

        yield return new WaitForSeconds(2f);

        // Check if enemy is dead
        // Change state depending on what happened
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        // Enemy attacks
        // Damage player
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        // Update HUD
        playerHUD.SetHP(playerUnit.currentHP);
        battleText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(2f);

        // Check if player is dead
        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            battleText.text = "Victory!";
        }
        else if (state == BattleState.LOST) 
        {
            battleText.text = "Defeat...";
        }
    }

    void PlayerTurn()
    {
        battleText.text = "Choose action:";
    }

    public void OnAttackButton()
    {
        // Can only attack if it is player's turn
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }
}
