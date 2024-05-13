using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public Transform cameraContainer;
    public Transform playerContainer;
    [SerializeField] float Speed = 5f;
    [SerializeField] float JumpSpeed = 10f;
    [SerializeField] float MouseSensitivity = 2f;
    [SerializeField] float Gravity = 20f;
    public float LookUpClamp = -30f;
    public float LookDownClamp = 60f;
    private Vector3 MoveDirection = Vector3.zero;
    float rotateX, rotateY;
    [SerializeField] GameObject Leveling;
    [SerializeField] GameObject Death;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //GameManager.ResetGame();
        characterController = GetComponent<CharacterController>();
        SetCurrentCamera();
    }
    void Update()
    {
        //if (!MenuController.IsGamePaused)
        //{
        Locomotion();
        if (!Leveling.activeSelf || !Death.activeSelf)
        {
            RotateAndLook();
        }
        //}
    }
    void SetCurrentCamera()
    {
        playerContainer = gameObject.transform.parent;
        cameraContainer = gameObject.transform.Find("Camera").Find("PlayerCam");
    }
    void Locomotion()
    {
        if (characterController.isGrounded)
        {
            MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            MoveDirection = transform.TransformDirection(MoveDirection);
            MoveDirection *= Speed;
            if (Input.GetButton("Jump"))
            {
                MoveDirection.y = JumpSpeed;
            }
            if(Input.GetKey(KeyCode.C))
            {
                characterController.height = 0.65f;
                characterController.center = new Vector3(0f, 0.5f, 0f);
            }
            else
            {
                characterController.height = 1.5f;
                characterController.center = new Vector3(0f, 1f, 0f);
            }
        }
        MoveDirection.y -= Gravity * Time.deltaTime;
        characterController.Move(MoveDirection * Time.deltaTime);
    }
    void RotateAndLook()
    {
        rotateX = Input.GetAxis("Mouse X") * MouseSensitivity;
        rotateY -= Input.GetAxis("Mouse Y") * MouseSensitivity;
        rotateY = Mathf.Clamp(rotateY, LookUpClamp, LookDownClamp);
        transform.Rotate(0f, rotateX, 0f);
        cameraContainer.transform.localRotation = Quaternion.Euler(rotateY, 0f, 0f);
    }
}
