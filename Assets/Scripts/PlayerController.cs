using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject wintextobject;


    private float speed;
    private float xDirection;
    private float zDirection;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        count = 0;
        SetCountText();
        wintextobject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        MoveBall();

    }

    private void MoveBall()
    {
        // Uses player input to move the ball
        Vector3 direction = new Vector3(xDirection, 0, zDirection);
        GetComponent<Rigidbody>().AddForce(direction * speed);

    }

    // listen for player pressing arrow or WASD keys
    private void GetPlayerInput()
    {
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");
    }
    private void SetCountText()
    {
        countText.text = "Count" + count.ToString();
        if(count >= 12)
        {
            wintextobject.SetActive(true); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        } 
    }
}