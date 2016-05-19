using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TouchScreenInput))]
public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private KeyboardInput input;
    private TouchScreenInput touchInput;

    private float verticalSpeed;

    public float VerticalSpeed
    {
        get { return verticalSpeed; }
    }

    private float maxVerticalSpeed;

    [Range(0,20)]
    [SerializeField] private float strafeSpeed;
    private float maxStrafeSpeed = 20;

    [SerializeField]
    private float rotSpeed;

    private bool buttonLPressed, buttonRPressed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<KeyboardInput>();

        touchInput = GetComponent<TouchScreenInput>();
        
        maxVerticalSpeed = 100f;


        Debug.Log("Player Loaded");
    }

    void FixedUpdate()
    {
        verticalSpeed++;
        maxVerticalSpeed++;

        CapMaxSpeed();
        StrafeRocket();
        CapRotation();
        RotateBack();

        buttonRPressed = false;
        buttonLPressed = false;
    }

    void LPress()
    {
        buttonLPressed = true;
    }

    void RPress()
    {
        buttonRPressed = true;
    }

    void RotateBack()
    {
        if (buttonRPressed == false && buttonLPressed == false)
        {
            //check rotation
            if (transform.eulerAngles.z < 360 && transform.eulerAngles.z > 330)
            {
                //rotate back to middle from right side
                rb.MoveRotation(rb.rotation + (rotSpeed * 2f) * Time.fixedDeltaTime);
            }
            else if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 30)
            {
                //rotate back to middle from left side
                rb.MoveRotation(rb.rotation + (-rotSpeed * 2f) * Time.fixedDeltaTime);
            }
        }
    }

    void CapRotation()
    {
        if (transform.rotation.eulerAngles.z > 25 && transform.rotation.eulerAngles.z < 180 && buttonLPressed)
        {
            //limit rotation on left side
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, CheckAngle(true));
        }

        if (transform.rotation.eulerAngles.z < 335 && transform.rotation.eulerAngles.z > 180 && buttonRPressed)
        {
            //limit rotation on right side
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, CheckAngle(false));
        }
    }

    void StrafeRocket()
    {
        if (buttonLPressed == true)
        {
            //rotate to the left
            rb.AddForce(new Vector2(-strafeSpeed, 0));

            rb.MoveRotation(rb.rotation + (rotSpeed * 2) * Time.fixedDeltaTime);

            DecreaseMaxSpeed();
        }

        if (buttonRPressed == true)
        {
            //rotate to the right
            rb.AddForce(new Vector3(strafeSpeed, 0));

            rb.MoveRotation(rb.rotation + (-rotSpeed * 2) * Time.fixedDeltaTime);

            DecreaseMaxSpeed();
        }
    }

    void CapMaxSpeed()
    {
        //cap max speed
        if (maxVerticalSpeed < 50)
        {
            maxVerticalSpeed = 50;
        }
        //cap max speed
        if (maxVerticalSpeed > 175)
        {
            maxVerticalSpeed = 175;
        }
    }

    void DecreaseMaxSpeed()
    {
        //decrease maxVerticalSpeed
        maxVerticalSpeed -= 2;
    }

    int CheckAngle(bool onLeft)
    {
        if (onLeft == true)
            return 25;
        else
            return 335;
    }

    void Update()
    {
        //cap speed
        if(verticalSpeed > maxVerticalSpeed)
        {
            verticalSpeed = maxVerticalSpeed;
        }

        Touch();
    }

    void Touch()
    {
        //read touch inputs
        if (touchInput.touchL == true)
        {
            buttonLPressed = true;
        }
        else if (touchInput.touchL == false)
        {
            buttonLPressed = false;
        }

        if (touchInput.touchR == true)
        {
            buttonRPressed = true;
        }
        else if (touchInput.touchR == false)
        {
            buttonRPressed = false;
        }
    }
}