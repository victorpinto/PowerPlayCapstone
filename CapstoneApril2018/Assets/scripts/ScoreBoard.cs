using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    //orange
    [SerializeField]
    private RectTransform orangeTeamBar;
    [SerializeField]
    private RectTransform maxOrangeBarSizeRect;

    [SerializeField]
    private RectTransform orangeResource1Bar;
    [SerializeField]
    private RectTransform maxOrangeResource1BarSizeRect;

    [SerializeField]
    private RectTransform orangeResource2Bar;
    [SerializeField]
    private RectTransform maxOrangeResource2BarSizeRect;

    [SerializeField]
    private RectTransform orangeResource3Bar;
    [SerializeField]
    private RectTransform maxOrangeResource3BarSizeRect;


    [SerializeField]
    private float orangeScore = 0;
    [SerializeField]
    private float orangeRes1Score = 0;
    [SerializeField]
    private float orangeRes2Score = 0;
    [SerializeField]
    private float orangeRes3Score = 0;



    // purple 
    [SerializeField]
    private RectTransform purpleTeamBar;
    [SerializeField]
    private RectTransform maxPurpleBarSizeRect;

    [SerializeField]
    private RectTransform purpleResource1Bar;
    [SerializeField]
    private RectTransform maxPurpleResource1BarSizeRect;

    [SerializeField]
    private RectTransform purpleResource2Bar;
    [SerializeField]
    private RectTransform maxPurpleResource2BarSizeRect;

    [SerializeField]
    private RectTransform purpleResource3Bar;
    [SerializeField]
    private RectTransform maxPurpleResource3BarSizeRect;

    [SerializeField]
    private float purpleScore = 0;
    [SerializeField]
    private float purpleRes1Score = 0;
    [SerializeField]
    private float purpleRes2Score = 0;
    [SerializeField]
    private float purpleRes3Score = 0;



    [SerializeField]
    private int roundNumber;

    [SerializeField]
    private Text roundText;


    

    [SerializeField]
    private float timer;

    [SerializeField]
    private Image clock;





    [SerializeField]
    private float batteryCharge;
    [SerializeField]
    private RectTransform batteryChargeBar;
    [SerializeField]
    private RectTransform maxBatteryChargeSizeRect;



    // Use this for initialization
    void Start () {
        //maxBarSize = maxBarSizeRect.sizeDelta.x;
        timer = 60;



        roundNumber = 1;


    }
	
	// Update is called once per frame
	void Update ()
    {
        /*

        if(orangeScore > 100)
        {
            orangeScore = 100;
        }

        if (purpleScore > 100)
        {
            purpleScore = 100;
        }

        


       

        

        if (Input.GetKeyDown(KeyCode.K))
        {
            orangeScore += 10;
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            purpleScore += 10;
        }


        if(Input.GetKeyDown(KeyCode.O))
        {
            orangeScore = 0;
            purpleScore = 0;
        }
        */

        roundText.text = roundNumber.ToString();


        // to be change later!!!!! not decided

        timer -= Time.deltaTime;

        clock.fillAmount = timer / 60;



        if(timer <= 0)
        {
            timer = 60;
            roundNumber++;
        }




        // battery charge
        batteryChargeBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, batteryCharge * maxBatteryChargeSizeRect.sizeDelta.y / 100);

        //bar changes
        PurpleBars();
        OrangeBars();
    }



    void PurpleBars()
    {
        //score
        purpleTeamBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, purpleScore * maxPurpleBarSizeRect.sizeDelta.x / 100);

        //res1
        purpleResource1Bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, purpleRes1Score * maxPurpleResource1BarSizeRect.sizeDelta.x / 100);

        //res2
        purpleResource2Bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, purpleRes2Score * maxPurpleResource2BarSizeRect.sizeDelta.x / 100);

        //res3
        purpleResource3Bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, purpleRes3Score * maxPurpleResource3BarSizeRect.sizeDelta.x / 100);

    }

    void OrangeBars()
    {
        // score
        orangeTeamBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, orangeScore * maxOrangeBarSizeRect.sizeDelta.x / 100);

        // res1
        orangeResource1Bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, orangeRes1Score * maxOrangeResource1BarSizeRect.sizeDelta.x / 100);

        //res2
        orangeResource2Bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, orangeRes2Score * maxOrangeResource2BarSizeRect.sizeDelta.x / 100);

        // res3
        orangeResource3Bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, orangeRes3Score * maxOrangeResource3BarSizeRect.sizeDelta.x / 100);

    }


}
