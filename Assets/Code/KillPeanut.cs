using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPeanut : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enterd: " +  col.name);


        switch (col.gameObject.tag)
        {
            case "Enemy":
                Destroy(col.gameObject);
                break;
            case "Gate":

                CloseGate GateLink = col.gameObject.GetComponent<CloseGate>();
                GateLink.fRemainingTime = GateLink.fMaxTime;            //++ Player Powerup Bonus
                Debug.Log(GateLink.fRemainingTime);
                break;
        }

       
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
