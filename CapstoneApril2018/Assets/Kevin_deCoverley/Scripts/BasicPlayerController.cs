using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour {

    // Movement Speed
    [SerializeField] private float forwardSpeed = 5.0f;
    [SerializeField] private float backwardSpeed = 2.0f;
    [SerializeField] private float sideSpeed = 3.5f;
    [SerializeField] private float sprintMultiplier = 5.0f;
    // Jump Force
    [SerializeField] private float jumpForce = 10.0f;
    // GetComponants
    [SerializeField] private Animator Animate;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    // Controls
    [SerializeField] private KeyCode Forwards = KeyCode.W;
    [SerializeField] private KeyCode Backwards = KeyCode.S;
    [SerializeField] private KeyCode Left = KeyCode.A;
    [SerializeField] private KeyCode Right = KeyCode.D;
    [SerializeField] private KeyCode Sprint = KeyCode.LeftShift;
    [SerializeField] private KeyCode Jump = KeyCode.Space;
    [SerializeField] private KeyCode Fire = KeyCode.LeftControl;
    // Private Variables
    // Animator
    private bool isIdle = true;
    private bool Sprinting = false;
    private bool Walking = false;
    private bool MovingFB = false;
    private bool MovingLR = false;
    private bool StrafeRight = false;
    private bool StrafeLeft = false;
    private bool Jumped = false;
    private bool onGround = true;
    private bool canJump = true;
    // Transform
    private Transform Trans;
    // Jumping
    private float jumpTime = 0;
    // Ball / Hand
    [SerializeField]
    private Transform playHand;
    private bool handOccupied = false;
    private ballScript BS;

    private void Start () {
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
    }

    //Inputs
    private void FixedUpdate()
    {
        onGround = Physics.Raycast(GroundCheck.position, Vector3.down, 0.1f);

        // Forwards and Backwards
        if (Input.GetKey(Forwards) && !Input.GetKey(Backwards))
        {
            Animate.SetBool("Forward", true);
            Animate.SetBool("Backward", false);
            MovingFB = true;
            if(!Sprinting)
            {
                Animate.SetBool("Walking", true);
                Animate.SetBool("Sprint", false);
                MoveForwards(forwardSpeed, Time.fixedDeltaTime);
            }
            else
            {
                Animate.SetBool("Walking", false);
                Animate.SetBool("Sprint", true);
                MoveForwards(forwardSpeed*sprintMultiplier, Time.fixedDeltaTime);
            }
        }
        else if (!Input.GetKey(Forwards) && Input.GetKey(Backwards))
        {
            Animate.SetBool("Forward", false);
            Animate.SetBool("Backward", true);
            MovingFB = true;
            if (!Sprinting)
            {
                Animate.SetBool("Walking", true);
                Animate.SetBool("Sprint", false);
                MoveForwards(-backwardSpeed, Time.fixedDeltaTime);
            }
            else
            {
                Animate.SetBool("Walking", false);
                Animate.SetBool("Sprint", true);
                MoveForwards(-backwardSpeed * sprintMultiplier, Time.fixedDeltaTime);
            }
        }
        else
        {
            Animate.SetBool("Forward", false);
            Animate.SetBool("Backward", false);
            MovingFB = false;
        }

        // Left and Right
        if (Input.GetKey(Right) && !Input.GetKey(Left))
        {
            Animate.SetBool("StrafeRight", true);
            Animate.SetBool("StrafeLeft", false);
            MovingLR = true;
            if (!Sprinting)
            {
                Animate.SetBool("Walking", true);
                Animate.SetBool("Sprint", false);
                MoveRight(sideSpeed, Time.fixedDeltaTime);
            }
            else
            {
                Animate.SetBool("Walking", false);
                Animate.SetBool("Sprint", true);
                MoveRight(sideSpeed*sprintMultiplier, Time.fixedDeltaTime);
            }
        }
        else if (!Input.GetKey(Right) && Input.GetKey(Left))
        {
            Animate.SetBool("StrafeRight", false);
            Animate.SetBool("StrafeLeft", true);
            MovingLR = true;
            if (!Sprinting)
            {
                Animate.SetBool("Walking", true);
                Animate.SetBool("Sprint", false);
                MoveRight(-sideSpeed, Time.fixedDeltaTime);
            }
            else
            {
                Animate.SetBool("Walking", false);
                Animate.SetBool("Sprint", true);
                MoveRight(-sideSpeed * sprintMultiplier, Time.fixedDeltaTime);
            }
        }
        else
        {
            Animate.SetBool("StrafeRight", false);
            Animate.SetBool("StrafeLeft", false);
            MovingLR = false;
        }

        // Jumping
        jumpTime += Time.fixedDeltaTime;
        if (onGround && jumpTime >= 0.3f)
        {
            canJump = true;
            Animate.SetBool("Jumped", false);
            jumpTime = 0;
        }
        if (Input.GetKeyDown(Jump) && onGround && canJump)
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

        // Shift is pressed
        if (Input.GetKey(Sprint))
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

        // Fire Ball
        if (Input.GetKeyDown(Fire) && handOccupied)
        {
            BS.throwBall();
            handOccupied = false;
        }
    }

    private void MoveForwards(float speed, float dTime) // Z is forwards
    {
        Trans.Translate(0, 0, speed * dTime);
    }

    private void MoveRight(float speed, float dTime)
    {
        Trans.Translate(speed * dTime, 0, 0);
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
