using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Checker : MonoBehaviour {

    
    [SerializeField]
    private CinemachineTargetGroup.Target battery;


    [SerializeField]
    private CinemachineTargetGroup.Target follow;

    [SerializeField]
    CinemachineTargetGroup group;

    [SerializeField]
    List <CinemachineTargetGroup.Target> targets = new List<CinemachineTargetGroup.Target>();
   
    private GameObject[] playerObjects;

    [SerializeField]
    private GameObject virtualCam;

    // Use this for initialization
    void Start () {

        // set angle of camera
        virtualCam.transform.eulerAngles = new Vector3(40, 0, 0);

        // find all objects with Player as the tag, and place them in a list
         playerObjects = GameObject.FindGameObjectsWithTag("Player");
         foreach(GameObject gamePlayers in playerObjects)
         {

            follow.target = gamePlayers.transform;
            //Debug.Log("player target : " + follow.target);
            follow.weight = 1;
            targets.Add(follow);
            group.m_Targets = targets.ToArray();
         }
         

     
    }
	
	// Update is called once per frame
	void Update () {

        // if battery doesn't exist check for battery until battery exists
        if (!battery.target)
        {
            //Debug.Log("enterd1");

            // if battery is found place it in group list
            if (GameObject.FindGameObjectWithTag("Battery") == true)
            {
                Debug.Log("enterd2");
                battery.target = GameObject.FindGameObjectWithTag("Battery").transform;
                battery.weight = 1;

                targets.Add(battery);
                group.m_Targets = targets.ToArray();
            }



           
        }

       // Debug.Log("Targets . count = " + targets.Count);
        
        // resize list depending if the there's a spot inn list that is void 
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].target == null)
            {
                //Debug.Log("It entered " + i);
                targets.RemoveAt(i);
            }
        }

       
    }


    

}
