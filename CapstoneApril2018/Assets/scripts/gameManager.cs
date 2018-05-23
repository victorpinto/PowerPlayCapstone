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
    [SerializeField]
    private float doorSpeed = 0.01f;

    [SerializeField]
    private GameObject[] balls;

    [SerializeField]
    private Transform spawn1;
    [SerializeField]
    private Transform spawn2;
    [SerializeField]
    private Transform spawn3;
    private int itemInt;

    // Use this for initialization
    void Awake ()
    {
        spawnBATT();
        spawnItems();
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
    public void closeDoors()
    {
            blueDoor.transform.position = blueStartMarker.transform.position;
            yellowDoor.transform.position = yellowStartMarker.transform.position;
            redDoor.transform.position = redStartMarker.transform.position;
    }

    void spawnItems()
    {

        Instantiate(balls[RandomInt()], spawn1.position, spawn1.rotation);
        Instantiate(balls[RandomInt()], spawn2.position, spawn2.rotation);
        Instantiate(balls[RandomInt()], spawn3.position, spawn3.rotation);
       
    }
    private int RandomInt()
    {
        itemInt = Random.Range(0, balls.Length);
        return itemInt;
    }


}
