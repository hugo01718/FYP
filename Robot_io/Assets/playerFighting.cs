using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerFighting : MonoBehaviour
{
    public Button runaway;

    // Start is called before the first frame update
    void Start()
    {
        runaway.onClick.AddListener(RunAway);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RunAway()
    {
        SceneManager.LoadScene("MainScene");
    }
}
