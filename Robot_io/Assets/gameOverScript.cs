using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour
{
    public Button backToMenu;

    // Start is called before the first frame update
    void Start()
    {
        backToMenu.onClick.AddListener(BackToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
