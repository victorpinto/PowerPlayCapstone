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

    [SerializeField]
    List<GameObject> players = new List<GameObject>();

    private int numberOfPlayers;

    [SerializeField]
    private GameObject virtualCam;

    bool started = false;
    //private List<GameObject> playerObject = new List<GameObject>();



    GameObject[] goals;


    // Use this for initialization
    void Start () {
        //GameObject[] playerObjects;

        // set angle of camera
        virtualCam.transform.eulerAngles = new Vector3(40, 0, 0);


        //goals = FindObjectsOfType</*name of the goal script*/>
        
        
        
        /*
        GameObject[] goals;

       goals = GameObject.FindGameObjectsWithTag("Goal");

        foreach (GameObject inGameGoals in goals)
        {

        }


            follow.target = 
        //Debug.Log("player target : " + follow.target);
        follow.weight = 1;
        targets.Add(follow);
        */

        /*
        // find all objects with Player as the tag, and place them in a list
         playerObjects = GameObject.FindGameObjectsWithTag("Player");
         foreach(GameObject gamePlayers in playerObjects)
         {

            players.Add(gamePlayers);

            follow.target = gamePlayers.transform;
            //Debug.Log("player target : " + follow.target);
            follow.weight = 1;
            targets.Add(follow);
            group.m_Targets = targets.ToArray();
         }
         */


    }
	
	// Update is called once per frame
	void Update () {
        

        /*
        for (int i = 0; i < goals.Length; i++)
        {
            if ((goals[i].transform.position - ))
        }
        */
        

        if(!started)
        {
            GameObject startingPlayer = GameObject.FindGameObjectWithTag("Player");


            players.Add(startingPlayer);


            


            follow.target = startingPlayer.transform;
            follow.weight = 1;
            targets.Add(follow);
            group.m_Targets = targets.ToArray();


            started = true;
        }
        

        // if battery doesn't exist check for battery until battery exists
        if (!battery.target)
        {
            //Debug.Log("enterd1");

            // if battery is found place it in group list
            if (GameObject.FindGameObjectWithTag("Battery"))
            {
                
                Debug.Log("enterd2");
                battery.target = GameObject.FindGameObjectWithTag("Battery").transform;
                battery.weight = 1;

                targets.Add(battery);
                group.m_Targets = targets.ToArray();
            
                }
            else
            {
                Debug.Log("battery not found!!!");
            }



           
        }
        

        // Debug.Log("Targets . count = " + targets.Count);

        // resize list depending if the there's a spot inn list that is void 
        //for (int i = 0; i < targets.Count; i++)

        numberOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;


        Debug.Log("numberOfPlayer" + numberOfPlayers);
        Debug.Log("player.Count" + players.Count);

        /*
        for(int l= 0; l < numberOfPlayers; l++)
        {
            GameObject current = GameObject.FindGameObjectsWithTag("Player")[l];
            Debug.Log("current: " + current);
        }
        */

        if (numberOfPlayers > players.Count)
        {
           // bool pop = false;
            Debug.Log("number of players exceed the amount of targets!");
            int numberMatch = 0;
            for (int l = 0; l < numberOfPlayers; l++)
            {
                GameObject current = GameObject.FindGameObjectsWithTag("Player")[l];


                for (int p = 0; p < players.Count; p++)
                {
                    // find excluded object
                    
                  //  Debug.Log("current: " + current);

                    //for (int x = 0; x < players.Count; x++)
                   // {
                     //   if (current != players[x])
                    //    {
                            // Debug.Log("kop");
                            // Debug.Log("current: " + current + "players[p]" + players[p]);     
                           // numberMatch = numberMatch + 1;
                     //   }
                   // }



                    //if (current != players[p])
                    //{
                       // Debug.Log("kop");
                       // Debug.Log("current: " + current + "players[p]" + players[p]);     
                        //numberMatch = numberMatch + 1;
                   // }

                    if (current == players[p])
                    {
                        numberMatch = 0;
                        break;
                    }
                    else
                    {
                        numberMatch = numberMatch +1;
                    }
                    
                    



                    Debug.Log("num: " +numberMatch);
                    if (numberMatch == numberOfPlayers - 1)
                    {
                        numberMatch = 0;

                        Debug.Log("inputed!");
                        Debug.Log("numberMatch: " + numberMatch + " " + "current: " + current);


                        players.Add(current);



                        
                        follow.target = current.transform;
                        follow.weight = 1;
                        targets.Add(follow);
                        group.m_Targets = targets.ToArray();


                        // break;


                    }
                    /*if (numberMatch == numberOfPlayers - 1)
                    {
                       
                        numberMatch = 0;
                    }

                    */

                }
            }
        }

        for (int i =players.Count - 1; i >= 0; i--)
        {
            if(players[i]== null)
            {
                players.RemoveAt(i);
            }
        }

        for (int i = targets.Count - 1; i >= 0; i--)
        {
            if (targets[i].target == null)
            {
                //Debug.Log("It entered " + i);
                targets.RemoveAt(i);
            }
        }

        /*
        for (int i = group.m_Targets.Length - 1; i >= 0; i--)
        {
            if(group.m_Targets[i])
            {

            }
        }
        */


    }


    

}
