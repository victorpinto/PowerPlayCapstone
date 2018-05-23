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
   
    GameObject[] playerObjects;



    // Use this for initialization
    void Start () {




        
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


        if (!battery.target)
        {
            Debug.Log("enterd1");

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
