using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{

    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;

    void Update()
    {
        characterController.Move(Vector3.right * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Deadzone"))
        {
            Destroy(gameObject);
        }
    }
}
