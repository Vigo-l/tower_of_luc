using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensitivity = 2f;

    private CharacterController controller;
    private Vector3 playerVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //movement
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * walkSpeed * Time.deltaTime);

        playerVelocity.y += Physics.gravity.y * Time.deltaTime; //gravity
        controller.Move(playerVelocity * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; //camera control
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        Vector3 currentRotation = cameraTransform.rotation.eulerAngles; //rotate camera
        float desiredRotationX = currentRotation.x - mouseY;
        if (desiredRotationX > 180)
            desiredRotationX -= 360;

        desiredRotationX = Mathf.Clamp(desiredRotationX, -90f, 90f);
        cameraTransform.rotation = Quaternion.Euler(desiredRotationX, currentRotation.y, currentRotation.z);
    }
}