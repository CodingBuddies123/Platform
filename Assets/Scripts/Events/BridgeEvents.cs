using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeEvents : MonoBehaviour {
    public GameObject bridge;

    public float BridgeOpenDelay;
    public float BridgeTimeLimit;

    bool LeftTrigger = false;
    private float OpenTime;
    private float ClosingTime;

    private string BridgeStatus;

    private const float UpdateTime = (float).02;

    // Use this for initialization
    void Start () {
        BridgeStatus = "Closed";
        OpenTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        switch(BridgeStatus)
        {
            case "Opening":
                OpenTime += UpdateTime;
                if(OpenTime >= BridgeOpenDelay)
                {
                    BridgeStatus = "Open";
                    ActivateBridge(true);
                    OpenTime = 0;
                    
                }
                break;
            case "Open":
                if(LeftTrigger)
                    ClosingTime += UpdateTime;

                if(ClosingTime > BridgeTimeLimit)
                {
                    BridgeStatus = "Closed";
                    ActivateBridge(false);
                    ClosingTime = 0;
                }
                break;
            case "Closed":
                break;
        }
    }

    private void ActivateBridge(bool active)
    {
        bridge.SetActive(active);
    }

    public void OnCollisionEnter(Collision collision)
    {
        BridgeStatus = "Opening";
        LeftTrigger = false;
    }

    public void OnCollisionExit(Collision collision)
    {
        LeftTrigger = true;
    }


}
