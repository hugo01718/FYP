using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class robot_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus.Robot1Alive == false)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        gameStatus.battleWithRobot1 = true;
        SceneManager.LoadScene("FightingScene");

    }
}
