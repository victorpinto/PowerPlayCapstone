using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    [SerializeField]
    private Transform playHand;
    private bool handOccupied = false;
    public ballScript BS;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if(Input.GetKeyDown(KeyCode.Space) && handOccupied)
        {
            BS.throwBall(transform.forward);
            handOccupied = false;
        }

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
