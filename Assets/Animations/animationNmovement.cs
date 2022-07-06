using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class animationNmovement : MonoBehaviour
{

    PlayerInput playerInput;
    CharacterController characterController;
    public GameObject forward;

    int isWhash;
    int isRhash;
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;
    Animator animat;
    public float rotationFactorPerFrame = 10.0f;
    //float runMultiplier = 13.0f;
    public float speed = 5.0f;
    public int lvl = 13;
    // Start is called before the first frame update
    void Awake()
    {

        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animat = GetComponent<Animator>();

       // isWhash = Animator.StringToHash("isW");
        isRhash = Animator.StringToHash("isR");
        ///sag sol haraketini buras� yapt�r�yor
        playerInput.characterControls.Move.started += onMovementInput;
        playerInput.characterControls.Move.performed += onMovementInput;
        playerInput.characterControls.Move.canceled += onMovementInput;
        // playerInput.characterControls.Run.started += onRun;
        //playerInput.characterControls.Run.canceled += onRun;

        Debug.Log("Karakter no: "+PlayerPrefs.GetInt("character"));

    }

    //void onRun(InputAction.CallbackContext context)
    //{
     //   isRunPressed = context.ReadValueAsButton();
   // }
    void onMovementInput(InputAction.CallbackContext context)
    {
            currentMovementInput = context.ReadValue<Vector2>();
           currentMovement.x = currentMovementInput.x * lvl;
      ///ileri geriyi kapatt�k //     currentMovement.z = currentMovementInput.y * lvl;
            //currentRunMovement.x = currentMovementInput.x * runMultiplier;
           // currentRunMovement.z = currentMovementInput.y * runMultiplier;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }


    public void handleRotation()
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
        if (!isMovementPressed)
        {
            Quaternion Frotation = forward.transform.rotation;

            transform.rotation = Quaternion.Slerp(currentRotation, Frotation, rotationFactorPerFrame * Time.deltaTime);
        }

    }

    public void handleAnimat()
    {
       // bool isW = animat.GetBool(isWhash);
        bool isR = animat.GetBool(isRhash);
       // bool isB = animat.GetBool("isB");

       // if (isMovementPressed && !isW)
        //{
         //   animat.SetBool(isWhash, true);
       // }
       // else if (!isMovementPressed && isW)
        //{
         //   animat.SetBool(isWhash, false);
        //}
        if (1==1)
        {
            animat.SetBool(isRhash, true);

        }
        //else if (!isMovementPressed && isR)
        //{
         //   animat.SetBool(isRhash, false);

        //}
    }


    void Update()
    {
        

        handleRotation();//animasyon
        handleAnimat();

        characterController.Move(Vector3.forward *lvl* Time.deltaTime);
        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }
        else
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }

    }
    void OnEnable()
    {
        playerInput.characterControls.Enable();
    }
    void OnDisable()
    {
        playerInput.characterControls.Disable();
    }
}

