using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public CharacterController characterController;
    public animationNmovement animationNmovement;
    float MoveFixedValue;


    public void FixedUpdate()
    {
        

        if (variableJoystick.Horizontal>0.5f)
        {
            MoveFixedValue = 0.5f;
        }
        else if (variableJoystick.Horizontal < -0.5f)
        {
            MoveFixedValue = -0.5f;
        }
        else
        {
            MoveFixedValue = variableJoystick.Horizontal;
        }

        // Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;

        Vector3 direction = Vector3.right * MoveFixedValue;
 
        characterController.Move(direction);

        MobileHandleAnimator(direction);

    }



    public void MobileHandleAnimator(Vector3 direction)
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = direction.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = direction.z;

        bool isMovementPressed = variableJoystick.Horizontal != 0;

        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, animationNmovement.rotationFactorPerFrame * Time.deltaTime);
        }
        if (!isMovementPressed)
        {
            Quaternion Frotation = animationNmovement.forward.transform.rotation;

            transform.rotation = Quaternion.Slerp(currentRotation, Frotation, animationNmovement.rotationFactorPerFrame * Time.deltaTime);
        }
}
       
}