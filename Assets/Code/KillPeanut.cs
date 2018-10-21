using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPeanut : MonoBehaviour {


    public float fExtendedGateTime = 0;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enterd: " +  col.name);


        switch (col.gameObject.tag)
        {
            case "Enemy":
                col.gameObject.GetComponent<Enemy>().Die();
                break;
            case "Gate":

                CloseGate GateLink = col.gameObject.GetComponent<CloseGate>();
                GateLink.fRemainingTime = GateLink.fMaxTime + fExtendedGateTime;            //++ Player Powerup Bonus
                Debug.Log(GateLink.fRemainingTime);
                break;
            case "PowerUP":
                PowerUp01 PowerUpLink = col.gameObject.GetComponent<PowerUp01>();
                PowerUpLink.Power(this.gameObject);
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
