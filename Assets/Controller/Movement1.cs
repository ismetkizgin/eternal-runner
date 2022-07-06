using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement1 : MonoBehaviour
{
    public CharacterController characterController;

    public Vector2 moveDeger;

    public float PlayerSpeed=13f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.Move(Vector3.forward * PlayerSpeed * Time.deltaTime); //Bu ileri götürüyor
    }

    public void Moving(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Performed");
            moveDeger = context.ReadValue<Vector2>();//okuma yapýyor 
            Debug.Log(moveDeger.x + " "+ moveDeger.y);
        }
        

    }

}
