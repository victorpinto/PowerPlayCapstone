
using UnityEngine;
using UnityEngine.Networking;
public class levelManager : NetworkBehaviour
{
    [SerializeField]
    private GameObject[] balls;

    [SerializeField]
    private Transform[] spawns;
   
    private int itemInt;
    public float roundTime = 20f;


    void Awake ()
    {
        CmdSpawnItems();
    }
	
	// Update is called once per frame
	void Update ()
    {
        roundTime -= Time.deltaTime;
        if (roundTime <= 0)
        {
            CmdSpawnItems();
            roundTime = 20;
            Debug.Log("spawning items again");
        }
    }
   
    [Command]
    public void CmdSpawnItems()
    {
        //for (int i = 0; i < balls.Length; i++)
        //{
            GameObject item1 = Instantiate(balls[RandomInt()], spawns[1].position, spawns[1].rotation);
            Debug.Log("spawning balls");
            NetworkServer.Spawn(item1);
        //}





    }
    private int RandomInt()
    {
        itemInt = Random.Range(0, balls.Length);
        return itemInt;
    }
}
