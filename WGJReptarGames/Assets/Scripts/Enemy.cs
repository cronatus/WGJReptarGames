using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed; //the base speed of the enemy
    private Transform playerPos; // the position of the player in the game world.
    private float direction;

    private bool isDead;

    public bool left; // a boolean variable to know if the enemy is going left


    // Use this for initialization
    void Start() {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //set the playerPos variable to be a reference to the players transform.

    }

    // Update is called once per frame
    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime); // move the enemy towards the player
        //print("enemy: " + (transform.position.x - playerPos.position.x)); // used to figure out directional velocities for implementation of directional animations
        direction = transform.position.x - playerPos.position.x; // determine a negative of positive float number to determine the direction of the player relevant 

        GetEnemyDirection();
        
    }

    private void GetEnemyDirection() {  // set the left variable, to true or false if the enemy is going left or right respectively.

        if (direction < 0.0f) {

            left = false;

        } else if (direction > 0.0f) {

            left = true;

        }

    }
}
