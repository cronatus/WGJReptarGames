using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviour : StateMachineBehaviour {

    bool idle;
    bool left;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        

    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        idle = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().idle;
        left = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().left;

        if (idle == true) {

            animator.SetTrigger("Idle");

        } else if (idle == false) {

            animator.ResetTrigger("Idle");

        }

        if (left == true) {

            animator.SetTrigger("Left");

        } else if (left == false) {

            animator.ResetTrigger("Left");

        }


    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {



    }

}