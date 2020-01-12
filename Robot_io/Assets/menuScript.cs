using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public Button startNewGame;
    // Start is called before the first frame update
    void Start()
    {
        startNewGame.onClick.AddListener(StartNewGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartNewGame()
    {
        gameStatus.level = 1;
        gameStatus.exp = 0;
        gameStatus.health = 50;
        gameStatus.maxHealth = 50;
        gameStatus.attack = 6;
        gameStatus.defense = 4;
        gameStatus.battleWithRobot1 = false;
        gameStatus.battleWithRobot2 = false;
        gameStatus.Robot1Alive = true;
        gameStatus.Robot2Alive = true;
        SceneManager.LoadScene("MainScene");
    }
}
