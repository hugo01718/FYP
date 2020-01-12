using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameStatus : MonoBehaviour
{
    public static int level = 1;
    public static int exp = 0;
    public static int health = 50;
    public static int maxHealth = 50;
    public static int attack = 6;
    public static int defense = 4;
    public static int upgradePoints = 0;
    public Button statPage;
    public GameObject statPageGO;
    bool statOpen = false;
    public Text statPageButtonText;
    public static bool battleWithRobot1 = false;
    public static bool battleWithRobot2 = false;
    public static bool Robot1Alive = true;
    public static bool Robot2Alive = true;

    // Start is called before the first frame update
    void Start()
    {
        statPage.onClick.AddListener(OpenStat);
    }

    // Update is called once per frame
    void Update()
    {
        if (exp > 50)
        {
            level += 1;
            exp -= 50;
            upgradePoints += 1;
        }

        GameObject.Find("Level").GetComponent<Text>().text = "Level: " + level.ToString();
        GameObject.Find("EXP").GetComponent<Text>().text = "EXP: " + exp.ToString() + "/50";
        GameObject.Find("Health").GetComponent<Text>().text = "Health: " + health.ToString() + "/" + maxHealth.ToString();
        
    }

    void OpenStat()
    {
        if (statOpen == false)
        {
            statOpen = true;
            statPageGO.SetActive(true);
            statPageButtonText.text = "Close";
        }
        else
        {
            statOpen = false;
            statPageGO.SetActive(false);
            statPageButtonText.text = "Statistics Page";
        }
    }
}
