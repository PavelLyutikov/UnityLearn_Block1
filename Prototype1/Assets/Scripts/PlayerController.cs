using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    //[SerializeField] Transform centerOfMass;

    [SerializeField] float horsePower = 20f;
    [SerializeField] float turnSpeed = 20f;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rtmText;
    [SerializeField] float rtm;

    [SerializeField] List<WheelCollider> allWheels;
    //[SerializeField] List<WheelCollider> backWheels;
    [SerializeField] int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.centerOfMass = centerOfMass.localPosition;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //Moves the car forward
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            //Rotates the car
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);


            //Speed
            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f); // 3.6 for km, 2.237 mph
            speedometerText.SetText("Speed: " + speed + "km");
            //RTM
            rtm = Mathf.Round((speed % 30) * 40);
            rtmText.SetText("RTM: " + rtm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        //foreach (WheelCollider wheel in backWheels)
        //{
        //    if (wheel.isGrounded)
        //    {
        //        wheelsOnGround++;
        //    }
        //}

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
