using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameManager : MonoBehaviour
{
   [SerializeField]
    private GameObject battery;
    [SerializeField]
    private GameObject chargePad;
    public GameObject BATT;
    [SerializeField]
    private BatteryScript BS;

    //team#1 goal
    [SerializeField]
    private GameObject blueDoor;
    [SerializeField]
    private GameObject redDoor;
    [SerializeField]
    private GameObject yellowDoor;
    [SerializeField]
    private Transform blueStartMarker;
    [SerializeField]
    private Transform blueEndMarker;
    [SerializeField]
    private Transform redStartMarker;
    [SerializeField]
    private Transform redEndMarker;
    [SerializeField]
    private Transform yellowStartMarker;
    [SerializeField]
    private Transform yellowEndMarker;
    //team#2 goal
    [SerializeField]
    private GameObject blueDoor2;
    [SerializeField]
    private GameObject redDoor2;
    [SerializeField]
    private GameObject yellowDoor2;
    [SerializeField]
    private Transform blueStartMarker2;
    [SerializeField]
    private Transform blueEndMarker2;
    [SerializeField]
    private Transform redStartMarker2;
    [SerializeField]
    private Transform redEndMarker2;
    [SerializeField]
    private Transform yellowStartMarker2;
    [SerializeField]
    private Transform yellowEndMarker2;

    [SerializeField]
    private float doorSpeed = 0.01f;

    
    // Use this for initialization
    void Awake ()
    {
        spawnBATT();
        
    }
	
	public void spawnBATT()
    {
        
         BATT = Instantiate(battery, chargePad.transform.position, chargePad.transform.rotation);
        
        
    }
    public void openBlue()
    {
        blueDoor.transform.position = Vector3.Lerp(blueDoor.transform.position, blueEndMarker.position, doorSpeed);
        if(blueDoor.transform.position.y >= blueEndMarker.transform.position.y)
        {
            blueDoor.transform.position = blueEndMarker.transform.position;
        }
    }
    public void openYellow()
    {
        yellowDoor.transform.position = Vector3.Lerp(yellowDoor.transform.position, yellowEndMarker.position, doorSpeed);
        if (yellowDoor.transform.position.y >= yellowEndMarker.transform.position.y)
        {
            yellowDoor.transform.position = yellowEndMarker.transform.position;
        }
    }
    public void openRed()
    {
       redDoor.transform.position = Vector3.Lerp(redDoor.transform.position, redEndMarker.position, doorSpeed);
        if (redDoor.transform.position.y >= redEndMarker.transform.position.y)
        {
            redDoor.transform.position = redEndMarker.transform.position;
        }
    }

    public void openBlue2()
    {
        blueDoor2.transform.position = Vector3.Lerp(blueDoor2.transform.position, blueEndMarker2.position, doorSpeed);
        if (blueDoor2.transform.position.y >= blueEndMarker2.transform.position.y)
        {
            blueDoor2.transform.position = blueEndMarker2.transform.position;
        }
    }
    public void openYellow2()
    {
        yellowDoor2.transform.position = Vector3.Lerp(yellowDoor2.transform.position, yellowEndMarker2.position, doorSpeed);
        if (yellowDoor2.transform.position.y >= yellowEndMarker2.transform.position.y)
        {
            yellowDoor2.transform.position = yellowEndMarker2.transform.position;
        }
    }
    public void openRed2()
    {
        redDoor2.transform.position = Vector3.Lerp(redDoor2.transform.position, redEndMarker2.position, doorSpeed);
        if (redDoor2.transform.position.y >= redEndMarker2.transform.position.y)
        {
            redDoor2.transform.position = redEndMarker2.transform.position;
        }
    }
    public void closeDoors()
    {
            blueDoor.transform.position = blueStartMarker.transform.position;
            yellowDoor.transform.position = yellowStartMarker.transform.position;
            redDoor.transform.position = redStartMarker.transform.position;

        blueDoor2.transform.position = blueStartMarker2.transform.position;
        yellowDoor2.transform.position = yellowStartMarker2.transform.position;
        redDoor2.transform.position = redStartMarker2.transform.position;
    }

    

}
