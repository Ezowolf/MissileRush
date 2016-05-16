using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(KeyboardInput))]
public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private KeyboardInput input;

    private float verticalSpeed;
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

        maxVerticalSpeed = 100f;
    }

    void FixedUpdate()
    {
        verticalSpeed++;
        maxVerticalSpeed++;

        CapMaxSpeed();
        StrafeRocket();
        CapRotation();
        RotateBack();

        rb.AddForce(new Vector2(0, verticalSpeed));
    }

    void RotateBack()
    {
        if (buttonRPressed == false && buttonLPressed == false)
        {
            //check rotation
            if (transform.eulerAngles.z < 360 && transform.eulerAngles.z > 315)
            {
                //rotate back to middle from right side
                rb.MoveRotation(rb.rotation + (rotSpeed * 2f) * Time.fixedDeltaTime);
            }
            else if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 46)
            {
                //rotate back to middle from left side
                rb.MoveRotation(rb.rotation + (-rotSpeed * 2f) * Time.fixedDeltaTime);
            }
        }
    }

    void CapRotation()
    {
        if (transform.rotation.eulerAngles.z > 45 && transform.rotation.eulerAngles.z < 180 && buttonLPressed)
        {
            //limit rotation on left side
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, CheckAngle(true));
        }

        if (transform.rotation.eulerAngles.z < 315 && transform.rotation.eulerAngles.z > 180 && buttonRPressed)
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

            rb.MoveRotation(rb.rotation + rotSpeed * Time.fixedDeltaTime);

            DecreaseMaxSpeed();
        }

        if (buttonRPressed == true)
        {
            //rotate to the right
            rb.AddForce(new Vector3(strafeSpeed, 0));

            rb.MoveRotation(rb.rotation + -rotSpeed * Time.fixedDeltaTime);

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
        maxVerticalSpeed -= 5;
    }

    int CheckAngle(bool onLeft)
    {
        if (onLeft == true)
            return 45;
        else
            return 316;
    }

    void Update()
    {
        //cap speed
        if(verticalSpeed > maxVerticalSpeed)
        {
            verticalSpeed = maxVerticalSpeed;
        }

        //read inputs
        if(input.arrowLeft == true)
        {
            buttonLPressed = true;
        }else if(input.arrowLeft == false)
        {
            buttonLPressed = false;
        }

        if(input.arrowRight == true)
        {
            buttonRPressed = true;
        }else if(input.arrowRight == false)
        {
            buttonRPressed = false;
        }
    }

	public float VerticalSpeed {
		get { return verticalSpeed; }
	}
}