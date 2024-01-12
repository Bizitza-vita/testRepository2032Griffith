using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        // increases performance
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

    }

    // Update is called once per frame
    void Update()

    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("up");
        bool rigthPressed = Input.GetKey("up");
        bool runPressed = Input.GetKey("left shift");

        // If player presses up,left,rigth,down key
        if (!isWalking && forwardPressed)

        {
            // then set the walking boolean to be true
            animator.SetBool(isWalkingHash, true);
           

        }

            // If the player is not pressing w key
            if (isWalking && !forwardPressed)
         {
                //then set the isWalking boolean to be false
                animator.SetBool(isWalkingHash, false);
        }

            // if player is walking and not running and presses left shift
            if (!isRunning && (forwardPressed && runPressed))
        {
            // then ser the isRunning boolean to be true
            animator.SetBool(isRunningHash, true);
        }
            // if player is running and stops running or stops walkimg
            if(isRunning && (!forwardPressed || !runPressed))
        {
            // then ser the isRinning boolean to be false
            animator.SetBool(isRunningHash, false);
        }
        
    }
}
