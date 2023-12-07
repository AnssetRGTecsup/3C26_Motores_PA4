using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giragira : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private void Update()
    {
        
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
