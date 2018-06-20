using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField] private TopDownPlayerScript TopPlayer;

    // Put here for first person script
    // here for third person

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform HandReturn()
    {
        return TopPlayer.HandReturn();
    }
    public void SetHand(bool B)
    {
        TopPlayer.SetHand(B);

    }
    public bool getHand()
    {
        return TopPlayer.getHand();
    }
    public void setBall(ballScript ball)
    {
        TopPlayer.setBall(ball);

    }
}

