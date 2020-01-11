using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    private Transform tf;
    public float velocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);

        rb.velocity = movement * velocity;

        if (x != 0 && y != 0)
        {
              transform.eulerAngles = new Vector3(0, Mathf.Atan2(x, y) * Mathf.Rad2Deg - 50, 0);
        }
    }
}
