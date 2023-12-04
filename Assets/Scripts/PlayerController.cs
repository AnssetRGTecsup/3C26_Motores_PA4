using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform reference;
    [SerializeField] private Vector3 simplePosition;

    public void OnMovement(InputAction.CallbackContext context)
    {
        simplePosition = context.ReadValue<Vector2>();
        simplePosition.z = 10;

        Vector3 complexPosition = Camera.main.ScreenToWorldPoint(simplePosition);

        reference.position = complexPosition;
    }
}
