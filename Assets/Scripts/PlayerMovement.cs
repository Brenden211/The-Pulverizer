using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = -10f;

    private CharacterController charController;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        charController.Move(move * speed * Time.deltaTime);
    }
}
