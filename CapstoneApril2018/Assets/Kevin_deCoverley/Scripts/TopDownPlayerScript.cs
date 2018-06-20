using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerScript : MonoBehaviour {

    // Movement Speed
    [SerializeField] private float forwardSpeed = 5.0f;
    [SerializeField] private float backwardSpeed = 2.0f;
    [SerializeField] private float sideSpeed = 3.5f;
    [SerializeField] private float sprintMultiplier = 5.0f;
    [SerializeField] private float RotationSpeed = 80.0f;
    // Jump Force
    [SerializeField] private float jumpForce = 10.0f;
    // GetComponants
    [SerializeField] private Animator Animate;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private GameObject Model;
    // Controls
    [SerializeField] private int PlayerNum = 1;
    [SerializeField] private float BoardAcceleration = 5.0f;
    [SerializeField] private float MaxSpeed = 10;

    private float MidSpeed;
    private float xAxis = 0.0f;
    private float yAxis = 0.0f;
    private float FourthAxis = 0.0f;
    private float FifthAxis = 0.0f;
    private float AngleOfPlayer = 0.0f;
    private float AngleOfDirection = 0.0f;
    private Vector3 ROTATION;
    private Vector3 ShootDirection;
    // Booleans
    private bool Sprinting = false;
    private bool onGround = true;
    private bool canJump = true;
    private bool MovingFB = false;
    private bool MovingLR = false;
    private bool Stunned = false;
    // Transform
    private Transform Trans;
    // Jumping
    private float jumpTime = 0;
    // Ball / Hand
    [SerializeField]
    private Transform playHand;
    private bool handOccupied = false;
    private ballScript BS;
    // Direction
    private Vector3 direction;
    // Velocity and Acceleration
    private Vector3 Velocity;
    private Vector3 Acceleration;
    private float AngularVelocity;
    private float AngularAcceleration;


    // Use this for initialization
    void Start () {
        Velocity = new Vector3(0, 0, 0);
        Acceleration = new Vector3(0, 0, 0);
        MidSpeed = MaxSpeed / 2;
        // Error Check
        if (!Animate)
            Debug.LogWarning("Character Will have No Animations");

        if (!RB)
        {
            Debug.LogError("Character has no rigidbody");
            RB = GetComponent<Rigidbody>();
        }

        // Init
        Trans = transform;
        ShootDirection = transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
        // Ground Check
        onGround = Physics.Raycast(GroundCheck.position, Vector3.down, 0.1f);
        if (handOccupied)
            Debug.Log("hand Occupied");
        else
            Debug.Log("hand Not Occupied");
        // Fire Ball
        if (Input.GetAxis("X " + PlayerNum + " Triggers") < -0.5f && handOccupied)
        {

            ShootDirection = new Vector3(FourthAxis, 0, FifthAxis);
            BS.throwBall(ShootDirection);
            handOccupied = false;
        }

        // Controller Inputs
        xAxis = Input.GetAxis("X " + PlayerNum + " Horizontal");
        yAxis = Input.GetAxis("X " + PlayerNum + " Vertical");
        //Debug.Log("Left Joystick (X: " + xAxis + ", Y: " + yAxis + ")");

        FourthAxis = Input.GetAxis("X " + PlayerNum + " 4th");
        FifthAxis = Input.GetAxis("X " + PlayerNum + " 5th");
        //Debug.Log("Right Joystick (X: " + FourthAxis + ", Y: " + FifthAxis + ")");
        if (Mathf.Abs(xAxis) < 0.2f)
            xAxis = 0;
        if (Mathf.Abs(yAxis) < 0.2f)
            yAxis = 0;
        if (Mathf.Abs(FourthAxis) < 0.3f)
            FourthAxis = 0;
        if (Mathf.Abs(FifthAxis) < 0.3f)
            FifthAxis = 0;

        // Direction and Movement
        if (xAxis + yAxis + FourthAxis + FifthAxis != 0f)
        {
            direction = new Vector3(xAxis, yAxis).normalized;
            if (direction.magnitude == 0)
                direction = new Vector3(FourthAxis, FifthAxis).normalized;
        }

        if (direction.magnitude != 0 && (xAxis != 0 || yAxis != 0))
        {
            // Direction and Movement
            AngleOfDirection = Mathf.Atan2(direction.y, direction.x) * 180 / (Mathf.PI);
            if (AngleOfDirection < 0.0f)
                AngleOfDirection += 360;
            ROTATION = Trans.rotation.eulerAngles;
            AngleOfPlayer = 360 - ROTATION.y; // To get the angle to be in the right direction (CCW is POSITIVE)
            //Debug.Log("Y Axis: " + yAxis + ", Angle of Player: " + AngleOfPlayer + ", Angle of Direction: " + AngleOfDirection);
            if (AngleOfDirection < 180 && AngleOfPlayer > 180 & AngleOfDirection + 360 - AngleOfPlayer < 180)
                AngleOfDirection += 360;
            else if (AngleOfPlayer < 180 && AngleOfDirection > 180 & AngleOfPlayer + 360 - AngleOfDirection < 180)
                AngleOfPlayer += 360;
            if ((AngleOfPlayer - AngleOfDirection) > 3.0f)
                Trans.Rotate(0.0f, RotationSpeed * Time.deltaTime, 0.0f);
            else if ((AngleOfPlayer - AngleOfDirection) < -3.0f)
                Trans.Rotate(0.0f, -RotationSpeed * Time.deltaTime, 0.0f);

            // Move Character
            if (!Stunned)
            {
                if (Velocity.x > MaxSpeed)
                {
                    Acceleration.x = -1f;
                }
                else if (Velocity.x == MaxSpeed)
                {
                    Acceleration.x = 0f;
                }
                else
                {
                    Acceleration.x = BoardAcceleration;
                }
            }
            
            Velocity += Acceleration * Time.deltaTime;
            Trans.Translate(Velocity.x * Time.deltaTime, Velocity.y * Time.deltaTime, Velocity.y * Time.deltaTime);


            MovingFB = true;

        }
        else if (direction.magnitude != 0 && xAxis == 0 && yAxis == 0)
        {
            // Direction and Movement
            AngleOfDirection = Mathf.Atan2(direction.y, direction.x) * 180 / (Mathf.PI);
            if (AngleOfDirection < 0.0f)
                AngleOfDirection += 360;
            ROTATION = Trans.rotation.eulerAngles;
            AngleOfPlayer = 360 - ROTATION.y; // To get the angle to be in the right direction (CCW is POSITIVE)
            //Debug.Log("Y Axis: " + yAxis + ", Angle of Player: " + AngleOfPlayer + ", Angle of Direction: " + AngleOfDirection);
            if (AngleOfDirection < 180 && AngleOfPlayer > 180 & AngleOfDirection + 360 - AngleOfPlayer < 180)
                AngleOfDirection += 360;
            else if (AngleOfPlayer < 180 && AngleOfDirection > 180 & AngleOfPlayer + 360 - AngleOfDirection < 180)
                AngleOfPlayer += 360;
            if ((AngleOfPlayer - AngleOfDirection) > 3.0f)
                Trans.Rotate(0.0f, RotationSpeed * Time.deltaTime, 0.0f);
            else if ((AngleOfPlayer - AngleOfDirection) < -3.0f)
                Trans.Rotate(0.0f, -RotationSpeed * Time.deltaTime, 0.0f);

            if (!Stunned)
            {
                if (Velocity.x > 0f)
                {
                    Acceleration.x = -4f;
                }
                else if (Velocity.x < 0f)
                {
                    Acceleration.x = 0f;
                }
            }
            Debug.LogWarning("Here");
            Velocity += Acceleration * Time.deltaTime;
            Trans.Translate(Velocity.x * Time.deltaTime, Velocity.y * Time.deltaTime, Velocity.y * Time.deltaTime);

            MovingFB = false;

        }
        else
        {
            if (!Stunned)
            {
                if (Velocity.x > 0f)
                {
                    Acceleration.x = -4f;
                }
                else if (Velocity.x< 0f)
                {
                    Acceleration.x = 0f;
                }
            }
            Debug.LogWarning("Here");
            Velocity += Acceleration * Time.deltaTime;
            Trans.Translate(Velocity.x * Time.deltaTime, Velocity.y * Time.deltaTime, Velocity.y * Time.deltaTime);
            MovingFB = false;
        }

        Debug.LogWarning("Velocity (" + Velocity + ")");
        Debug.LogWarning("Acceleration (" + Acceleration + ")");



        // Jumping
        jumpTime += Time.fixedDeltaTime;
        if (onGround && jumpTime >= 0.3f)
        {
            canJump = true;
            Animate.SetBool("Jumped", false);
            jumpTime = 0;
        }
        if (Input.GetButton("X " + PlayerNum + " A") && onGround && canJump)
        {
            JumpCharacter(jumpForce);
            Animate.SetBool("Jumped", true);
        }
        // onGround
        if (onGround)
        {
            Animate.SetBool("onGround", true);
        }
        else
        {
            Animate.SetBool("onGround", false);
        }

        // Sprint is pressed
        if (Input.GetButton("X " + PlayerNum + " LeftBumper"))
        {
            Sprinting = true;
        }
        else
        {
            Sprinting = false;
        }

        // idle
        if (!MovingFB && !MovingLR && onGround)
        {
            Animate.SetBool("isIdle", true);
            Animate.SetBool("Walking", false);
            Animate.SetBool("Sprint", false);
        }
        else
        {
            Animate.SetBool("isIdle", false);
        }
    }


    private void MoveForwards(float speed, float dTime) // Z is forwards
    {
        Trans.Translate(speed * dTime, 0, 0);
    }

    private void MoveRight(float speed, float dTime)
    {
        Trans.Translate(0, 0, speed * dTime);
    }

    private void JumpCharacter(float JumpForce)
    {
        RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    public Transform HandReturn()
    {
        return playHand;
    }
    public void SetHand(bool B)
    {
        handOccupied = B;
    }
    public bool getHand()
    {
        return handOccupied;
    }
    public void setBall(ballScript ball)
    {
        BS = ball;
    }
}
