using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed; //the base speed of the enemy
    private Transform playerPos; // the position of the player in the game world.
    private float direction; // used to figure out which direction the player is in, in relation to the enemy.

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
        direction = transform.position.x - playerPos.position.x; // determine a negative or positive float number to determine which direction the enemy will be going to go towards the player
                                                                 // a positive float means the player is to the left of the enemy and a negative means the player is to the right

        GetEnemyDirection();

        if(left == true) {

            gameObject.GetComponent<Animator>().SetLayerWeight(1, 1f);  // set the enemy animator to the layer using the left animation

        } else if (left == false) {

            gameObject.GetComponent<Animator>().SetLayerWeight(1, 0f);  // set the enemy animator to the layer using the right animation

        }

        
    }

    private void GetEnemyDirection() {  // set the left variable, to true or false if the enemy is going left or right respectively.

        if (direction < 0.0f) {

            left = false;

        } else if (direction > 0.0f) {

            left = true;

        }

    }
}
