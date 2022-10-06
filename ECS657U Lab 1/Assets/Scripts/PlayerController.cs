using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerController : MonoBehaviour {
    
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 5;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI posText;
    public TextMeshProUGUI velText;
    public GameObject player;
    public Vector3 oldPos;
    public Vector3 velocity;

    void Start() {
        count = 0;
        winText.text = "";
        SetCountText();
        oldPos = player.transform.position;
    }

    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2>();
    }

    // void Update() {
    //     velocity = (player.transform.position - oldPos) / Time.deltaTime;
    //     velText.text = "Velocity: " + velocity + "Speed: " + Math.Sqrt(Math.Pow(velocity.x, 2) + Math.Pow(velocity.y, 2));
    //     oldPos = player.transform.position;
    // }

    void FixedUpdate() {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
        posText.text = "Position: " + player.transform.position.ToString("0.00");
        velocity = (player.transform.position - oldPos) / Time.fixedDeltaTime;
        velText.text = "Velocity: " + velocity + " Speed: " + Math.Sqrt(Math.Abs(Math.Pow(velocity.x, 2)) + Math.Abs(Math.Pow(velocity.z, 2)));
        oldPos = player.transform.position;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText() {
        scoreText.text = "Score: " + count.ToString();
        if(count >= numPickups) {
            winText.text = "You win!";
        }
    }
}
