using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : StateMachineBehaviour
{
    public float reloadTime = 0.7f;
    bool hasReloaded = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)


    {
        if (hasReloaded) return;
        if(stateInfo.normalizedTime >= reloadTime)
        {
            if (animator.GetComponent<weapon>())
            {
                animator.GetComponent<weapon>().RELOAD();
                hasReloaded = true;
            }

            if (animator.GetComponent<weapon2>())
            {
                animator.GetComponent<weapon2>().RELOAD();
                hasReloaded = true;
            }
            if (animator.GetComponent<greenrifle>())
            {
                animator.GetComponent<greenrifle>().RELOAD();
                hasReloaded = true;
            }
            if (animator.GetComponent<orangerifle>())
            {
                animator.GetComponent<orangerifle>().RELOAD();
                hasReloaded = true;
            }
            if (animator.GetComponent<yellowrifle>())
            {
                animator.GetComponent<yellowrifle>().RELOAD();
                hasReloaded = true;
            }
            if (animator.GetComponent<bluepistol>())
            {
                animator.GetComponent<bluepistol>().RELOAD();
                hasReloaded = true;
            }
        }
    }
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasReloaded = false;    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
