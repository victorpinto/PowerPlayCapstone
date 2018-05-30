using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{

    [SerializeField]
    private float energy;
    [SerializeField]
    private GameObject battery;
    //[SerializeField]
    //private GameObject blueSlot;
    //[SerializeField]
    //private GameObject redSlot;
    [SerializeField]
    private GameObject yellowSlot;
    [SerializeField]
    private GameObject doorPad;
    [SerializeField]
    private gameManager GM;
    private float maxEnergy = 100;
    private Transform playHand;
    private PlayerScript player;

    // Use this for initialization
    void Start ()
    {
        energy = 1;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //blueSlot = GameObject.FindGameObjectWithTag("blueSlot");
        //redSlot = GameObject.FindGameObjectWithTag("redSlot");
        yellowSlot = GameObject.FindGameObjectWithTag("yellowSlot");
        doorPad = GameObject.FindGameObjectWithTag("doorPad");
        GM = FindObjectOfType<gameManager>();
        if (energy <= -1)
        {
            Destroy(gameObject);
            GM.spawnBATT();
        }
        if(energy >= 100)
        {
            energy = maxEnergy;
        }

	}
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player" && energy == 100)
        {
            player = FindObjectOfType<PlayerScript>();
            playHand = player.HandReturn();
            if (!player.getHand())
            {
                batteryGrab();
            }
        }
        //if (c.gameObject.tag == "blueSlot")
        //{

        //    placeBattBlue();

        //}
        //if (c.gameObject.tag == "redSlot")
        //{

        //    placeBattRed();

        //}
        if (c.gameObject.tag == "yellowSlot")
        {

            placeBattYellow();

        }
        if (c.gameObject.tag == "doorPad")
        {

            placeBatt2();

        }
    }
    private void OnTriggerStay(Collider c)
    {
        //if (c.gameObject.tag == "blueSlot")
        //{
        //    GM.openBlue();
        //    energydrain();

        //}
        if (c.gameObject.tag == "yellowSlot")
        {
            GM.openRed();
            GM.openBlue();
            GM.openYellow();
            energydrain();

        }

        if (c.gameObject.tag == "doorPad")
        {
            GM.openRed2();
            GM.openBlue2();
            GM.openYellow2();
            energydrain();

        }
        //if (c.gameObject.tag == "redSlot")
        //{
        //    GM.openRed();
        //    energydrain();

        //}
        if (c.gameObject.tag == "chargePad")
        {
            
            energyUP();
            GM.closeDoors();
        }
    }
    


    public void batteryGrab()
    {
        GM.BATT.transform.parent = playHand.transform;
        
    }
    public void energydrain()
    {
        energy -= 0.1f;
    }
    public void energyUP()
    {
        energy += 0.1f;
    }
    //public void placeBattBlue()
    //{
        
    //    GM.BATT.transform.parent = blueSlot.transform;
    //    GM.BATT.transform.localPosition = new Vector3(0, 0, 0);
    //}
    public void placeBattYellow()
    {

        GM.BATT.transform.parent = yellowSlot.transform;
        GM.BATT.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void placeBatt2()
    {

        GM.BATT.transform.parent = doorPad.transform;
        GM.BATT.transform.localPosition = new Vector3(0, 0, 0);
    }
    //public void placeBattRed()
    //{

    //    GM.BATT.transform.parent = redSlot.transform;
    //    GM.BATT.transform.localPosition = new Vector3(0, 0, 0);
    //}
}
