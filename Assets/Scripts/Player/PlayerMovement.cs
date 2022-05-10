using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public PlayerScript PlayerControllerScript;
    private float InputHorizontalAxis;
    private float InputVerticalAxis;
    private CharacterController playerController;
    public Transform CameraTransform;
    private float turnSmoothingVelocity;
    void Start(){
        playerController = GetComponent<CharacterController>();
    }
    void Update(){
        InputVerticalAxis = Input.GetAxis("Vertical");
        InputHorizontalAxis = Input.GetAxis("Horizontal");
        Vector3 movementDirection = new Vector3(InputHorizontalAxis,0,InputVerticalAxis);
        if(movementDirection.magnitude <= 0.01f)
            return;
            float targetAngle = Mathf.Atan2(movementDirection.x,movementDirection.z) * Mathf.Rad2Deg + CameraTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothingVelocity, PlayerControllerScript.TurnSmoothingTime);
            transform.rotation = Quaternion.Euler(0f,smoothAngle,0f);

        movementDirection = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
        playerController.Move(movementDirection.normalized * PlayerControllerScript.PlayerSpeed * PlayerControllerScript.SpeedBoost * Time.deltaTime);
    }
}
