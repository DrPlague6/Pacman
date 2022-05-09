using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public PlayerController PlayerControllerScript;
    public float MovementSpeed;
    private float InputHorizontalAxis;
    private float InputVerticalAxis;
    public Rigidbody PlayerRB;
    void Start(){
        PlayerRB = GetComponent<Rigidbody>();
    }
    void Update(){
        InputVerticalAxis = Input.GetAxis("Vertical");
        InputHorizontalAxis = Input.GetAxis("Horizontal");
        if(InputHorizontalAxis == 0)
            return;
        else if(InputVerticalAxis == 0)
            return;
        PlayerRB.AddForce(transform.forward * InputVerticalAxis * MovementSpeed,ForceMode.Acceleration);
    }
}
