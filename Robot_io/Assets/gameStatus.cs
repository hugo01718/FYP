using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameStatus : MonoBehaviour
{
    public static int level = 1;
    public static int exp = 0;
    public static int attack = 6;
    public static int defense = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (exp > 50)
        {
            level += 1;
            exp -= 50;
        }

        GameObject.Find("Level").GetComponent<Text>().text = "Level: " + level.ToString();
        GameObject.Find("EXP").GetComponent<Text>().text = "EXP: " + exp.ToString() + "/50";
    }
}
