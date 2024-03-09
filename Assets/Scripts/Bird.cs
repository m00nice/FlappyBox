using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField] private CharacterController characterController;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float gravityMult = 1f;
    [SerializeField] private Renderer renderer;
    [SerializeField] private Material yellow;
    [SerializeField] private Material red;
    private float verticalVelocity;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        VerticalMovement();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("BirdGoDie"))
        {
            Debug.Log("time stop");
            renderer.material = red;
            Time.timeScale = 0;
            GameSystem.Instance.ShowMenu();
        }

        if (collider.gameObject.CompareTag("Points"))
        {
            GameSystem.Instance.AddPoints(1);
        }
    }

    private void VerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity -= (gravity * gravityMult) * Time.deltaTime;
            if (verticalVelocity < -4f)
            {
                verticalVelocity = -4f;
            }
        }
        characterController.Move(Vector3.up * (verticalVelocity * Time.deltaTime));
    }
}
