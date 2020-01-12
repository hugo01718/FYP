using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerFighting : MonoBehaviour
{
    public Button runaway;
    public Button normalAttack;
    public Button heavyAttack;
    public Button recovery;
    public Button dancing;
    public Button fireball;
    public Text message;
    private int level;
    private int exp;
    private int health;
    private int maxHealth;
    private int attack;
    private int defense;
    public GameObject robot1, robot2;

    // Start is called before the first frame update
    void Start()
    {
        runaway.onClick.AddListener(RunAway);
        normalAttack.onClick.AddListener(NormalAttack);
        heavyAttack.onClick.AddListener(HeavyAttack);
        recovery.onClick.AddListener(Recovery);
        dancing.onClick.AddListener(Dancing);
        fireball.onClick.AddListener(Fireball);
        if (gameStatus.level >= 3)
            heavyAttack.interactable = true;
        if (gameStatus.level >= 8)
            recovery.interactable = true;
        if (gameStatus.level >= 12)
            dancing.interactable = true;
        if (gameStatus.level >= 18)
            fireball.interactable = true;
        
        if (gameStatus.battleWithRobot1 == true)
        {
            level = 1;
            exp = 120;
            health = 30;
            maxHealth = 30;
            attack = 4;
            defense = 3;
            robot1.SetActive(true);
        }
        else if (gameStatus.battleWithRobot2 == true)
        {
            level = 3;
            exp = 150;
            health = 100;
            maxHealth = 100;
            attack = 100;
            defense = 3;
            robot2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float enemyHealthBar, playerHealthBar;
        enemyHealthBar = (float)health / maxHealth;
        if (enemyHealthBar < 0)
        {
            enemyHealthBar = 0;
        }

        playerHealthBar = (float)gameStatus.health / gameStatus.maxHealth;
        if (playerHealthBar < 0)
        {
            playerHealthBar = 0;
        }
            
        GameObject.Find("EnemyHealthBar").GetComponent<Slider>().value = enemyHealthBar;
        GameObject.Find("PlayerHealthBar").GetComponent<Slider>().value = playerHealthBar;

        if (health <= 0)
        {
            health = 9999999;
            StartCoroutine(Victory());
            
            if (gameStatus.battleWithRobot1 == true)
            {
                gameStatus.Robot1Alive = false;
                gameStatus.battleWithRobot1 = false;
            }
            if (gameStatus.battleWithRobot2 == true)
            {
                gameStatus.Robot2Alive = false;
                gameStatus.battleWithRobot2 = false;
            }
            
        }
        if (gameStatus.health <= 0)
        {
            StartCoroutine(GameOver());
        }

        GameObject.Find("Level").GetComponent<Text>().text = "Level: " + gameStatus.level.ToString();
        GameObject.Find("EXP").GetComponent<Text>().text = "EXP: " + gameStatus.exp.ToString() + "/50";
        GameObject.Find("Health").GetComponent<Text>().text = "Health: " + gameStatus.health.ToString() + "/" + gameStatus.maxHealth.ToString();
    }

    IEnumerator Victory()
    {
        message.text = "Your enemy is defeated!";
        
        yield return new WaitForSecondsRealtime(1);
        message.text = "You gain " + exp + " EXP!";
        gameStatus.exp += exp;
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator GameOver()
    {
        message.text = "You are defeated!";
        yield return new WaitForSecondsRealtime(1);
        message.text = "Game Over!";
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("GameOverScene");
    }

    void RunAway()
    {
        gameStatus.battleWithRobot1 = false;
        gameStatus.battleWithRobot2 = false;
        SceneManager.LoadScene("MainScene");
    }

    void NormalAttack()
    {
        StartCoroutine(NormalAttackIEnumerator());  
    }

    IEnumerator NormalAttackIEnumerator()
    {
        lockAllButton();
        message.text = "You use \"Normal Attack\" to Attack your enemy.";
        yield return new WaitForSecondsRealtime((float) 0.5);
        message.text = "Your enemy receives " + (gameStatus.attack - defense / 2) + " damage!";
        health -= gameStatus.attack - defense / 2;
        yield return new WaitForSecondsRealtime(1);
        message.text = "You receive " + (attack - gameStatus.defense / 2) + " damage!";
        gameStatus.health -= attack - gameStatus.defense / 2;
        yield return new WaitForSecondsRealtime(1);
        message.text = "What action do you choose?";
        unlockAllButton();
    }

    void HeavyAttack()
    {
        StartCoroutine(HeavyAttackIEnumerator());
    }

    IEnumerator HeavyAttackIEnumerator()
    {
        lockAllButton();
        message.text = "You use \"Heavy Attack\" to Attack your enemy.";
        yield return new WaitForSecondsRealtime((float)0.5);
        message.text = "Your enemy receives " + (gameStatus.attack * 2 - defense) + " damage!";
        health -= gameStatus.attack - defense / 2;
        yield return new WaitForSecondsRealtime(1);
        message.text = "You receive " + (attack - gameStatus.defense / 2) + " damage!";
        gameStatus.health -= attack - gameStatus.defense / 2;
        yield return new WaitForSecondsRealtime(1);
        message.text = "What action do you choose?";
        unlockAllButton();
    }

    void Recovery()
    {

    }

    void Dancing()
    {

    }

    void Fireball()
    {

    }

    void lockAllButton()
    {
        normalAttack.interactable = false;
        runaway.interactable = false;
        heavyAttack.interactable = false;
        recovery.interactable = false;
        dancing.interactable = false;
        fireball.interactable = false;
    }

    void unlockAllButton()
    {
        normalAttack.interactable = true;
        runaway.interactable = true;
        if (gameStatus.level >=3)
            heavyAttack.interactable = true;
        if (gameStatus.level >= 8)
            recovery.interactable = true;
        if (gameStatus.level >= 12)
            dancing.interactable = true;
        if (gameStatus.level >= 18)
            fireball.interactable = true;
    }
}
