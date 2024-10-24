using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensitivity = 2f;

    Camera c;

    private CharacterController controller;
    private Vector3 playerVelocity;

    [Header("Interaction")]
    [SerializeField] private Vector3 interactionRayPoint = default;
    [SerializeField] private float interactionDistance = default;
    [SerializeField] private LayerMask interactionLayer = default;
    private Interactable currentInteractable;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        c = cameraTransform.GetComponent<Camera>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //movement
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * walkSpeed * Time.deltaTime);

        playerVelocity.y += Physics.gravity.y / 5 * Time.deltaTime; //gravity
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
        HandleInteractionInput();
        HandleInteractionCheck();


    }

    private void HandleInteractionCheck()
    {
        if (Physics.Raycast(c.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance))
        {
            if (hit.collider.gameObject.layer == 8 && (currentInteractable == null || hit.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID()))
            {
                hit.collider.TryGetComponent(out currentInteractable);

                if (currentInteractable)
                {
                    currentInteractable.OnFocus();
                }
            } // x1 position
        }
        else if (currentInteractable) //this should be also in the x1 position otherwise the OnLoseFocus() would only apply when you look at nothing
        {
            currentInteractable.OnLoseFocus();
            currentInteractable = null;
        }
    }
    private void HandleInteractionInput()
    {
        if (Input.GetButtonDown("Fire1") && currentInteractable != null && Physics.Raycast(c.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance, interactionLayer))
        {
            currentInteractable.OnInteract();
        }
    }
}