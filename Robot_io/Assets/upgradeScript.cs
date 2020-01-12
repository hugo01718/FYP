using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeScript : MonoBehaviour
{
    public Text level, exp, health, attack, defense, upgradePoints;
    public Button upgradeHealth, upgradeAttack, upgradeDefense;
    // Start is called before the first frame update
    void Start()
    {
        upgradeHealth.onClick.AddListener(UpgradeHealth);
        upgradeAttack.onClick.AddListener(UpgradeAttack);
        upgradeDefense.onClick.AddListener(UpgradeDefense);
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level: " + gameStatus.level.ToString();
        exp.text = "EXP: " + gameStatus.exp.ToString() + "/50";
        health.text = "Health: " + gameStatus.health.ToString() + "/" + gameStatus.maxHealth.ToString();
        attack.text = "Attack: " + gameStatus.attack.ToString();
        defense.text = "Defense: " + gameStatus.defense.ToString();
        upgradePoints.text = "Upgrade Points: " + gameStatus.upgradePoints.ToString();

    }

    void UpgradeHealth()
    {
        if (gameStatus.upgradePoints > 0)
        {
            gameStatus.maxHealth += 10;
            gameStatus.upgradePoints -= 1;
        }
    }

    void UpgradeAttack()
    {
        if (gameStatus.upgradePoints > 0)
        {
            gameStatus.attack += 4;
            gameStatus.upgradePoints -= 1;
        }

    }

    void UpgradeDefense()
    {
        if (gameStatus.upgradePoints > 0)
        {
            gameStatus.defense += 4;
            gameStatus.upgradePoints -= 1;
        }
    }
}
