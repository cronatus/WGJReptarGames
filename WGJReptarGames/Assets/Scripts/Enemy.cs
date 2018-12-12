using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed; //the base speed of the enemy
    private Transform playerPos; // the position of the player in the game world.

    private bool isDead;



    // Use this for initialization
    void Start() {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

    }
}
