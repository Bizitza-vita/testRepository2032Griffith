using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class AnimationAndMovementController : MonoBehaviour
{
    // declare reference variables
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;

    // variable to store player input values
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;


    //Awake is called earlier than start in Unity's event life cycle

    void Awake()

    {
        // initially set reference variables
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerInput.CharacterControls.Move.started += Context =>
        {
            currentMovementInput = Context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.y = currentMovementInput.y;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        };

        playerInput.CharacterControls.Move.canceled += Context =>
        {
            currentMovementInput = Context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.y = currentMovementInput.y;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        };

        playerInput.CharacterControls.Move.performed += Context =>
        {
            currentMovementInput = Context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.y = currentMovementInput.y;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        };
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;
        // the change in position our character should point to
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;
        //the current rotation of our characters
        Quaternion currentRotation = transform.rotation;


        void handleAnimation()
        {
            bool isWalking = animator.GetBool("isWalking");
            bool isRunning = animator.GetBool("isRunning");

            // start walking if movement pressed is true and not already walking
            if (isMovementPressed && !isWalking)
            {
                animator.SetBool("isWalking", true);
            }

            // stop walking is isMovementPrssed is false and not already walking
            else if (!isMovementPressed && isWalking)
            {
                animator.SetBool("isWalkimg", false);
            }
        }



        //update is callled once per frame
        void Update()
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }

        void OnEnable()
        {
            playerInput.CharacterControls.Enable();

        }

        void OnDisable()
        {
            //disable the character controls action map
            playerInput.CharacterControls.Disable();
        }
    }

}