using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject pickUps;
    public double shortestDist;
    public int closestPickUp;
    public TextMeshProUGUI distText;
    //Transform[] pickUpArray = pickUps.GetComponentsInChildren<Transform>();

    void Start() {
        shortestDist = 1000;
    }

    // Update is called once per frame
    void Update() {
        for(int i = 0; i <= 4; i++) {
            pickUps.transform.GetChild(i).gameObject.GetComponent <Renderer >().material.color = Color.white;
            if (pickUps.transform.GetChild(i).gameObject.activeSelf & Math.Sqrt(Math.Pow(pickUps.transform.GetChild(i).gameObject.transform.position.x - player.transform.position.x, 2) + Math.Pow(pickUps.transform.GetChild(i).gameObject.transform.position.z - player.transform.position.z, 2)) < shortestDist) {
                shortestDist = Math.Sqrt(Math.Pow(pickUps.transform.GetChild(i).gameObject.transform.position.x - player.transform.position.x, 2) + Math.Pow(pickUps.transform.GetChild(i).gameObject.transform.position.z - player.transform.position.z, 2));
                closestPickUp = i;
            }
        }
        distText.text = "Distance to blue cube: " + Math.Round(shortestDist, 2, MidpointRounding.AwayFromZero);
        shortestDist = 1000;
        pickUps.transform.GetChild(closestPickUp).gameObject.GetComponent <Renderer >().material.color = Color.blue;
        // foreach (Transform t in pickUpArray) {
        //     if (Math.Sqrt(Math.Pow(t.position.x - player.transform.position.x, 2) + Math.Pow(t.position.z - player.transform.position.z, 2)) < shortestDist) {
        //         shortestDist = Math.Sqrt(Math.Pow(t.position.x - player.transform.position.x, 2) + Math.Pow(t.position.z - player.transform.position.z, 2));
        //     }
        // }
        // distText.text = "" + shortestDist;
    }
}
