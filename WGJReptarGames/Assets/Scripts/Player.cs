using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    //These two variables are for Animation purposes
    public bool left;       // a boolean variable to know if the player is moving left or not
    public bool idle;       // a boolean variable to know if the player is idle

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void Update()
    {

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        GetPlayerDirection();
        print("Velocity: " + velocity.x);

    }

    private void GetPlayerDirection() {
        
        if (velocity.x < -0.9f) {

            left = true;    //If the player is moving left set the left Boolean to be true
            idle = false;   //If the player is moving set idle to false

        } else if (velocity.x > 0.9f) {

            left = false;   //If the player is moving Right set the left Boolean to be False
            idle = false;   //If the player is moving set idle to false

        } else if ((velocity.x > -0.9f) && (velocity.x < 0.9)) {

            idle = true;    //When the player stops moving set Idle to true;

        }

    }


}
