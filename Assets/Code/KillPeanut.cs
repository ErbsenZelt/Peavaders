using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPeanut : MonoBehaviour {


    public float fExtendedGateTime = 0;
    public float fHealChilliValue = 5;

    private float fTimer = 0;

    private void HealChilli(GameObject go)
    {
        ChilliGetEeated ChilliLink = go.GetComponent<ChilliGetEeated>();
        ChilliLink.fChilliHealth += fHealChilliValue;
    }

    private void OnTriggerStay(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Target":
                fTimer += Time.deltaTime;
                if (fTimer >= 1)
                {
                    fTimer = 0;
                    HealChilli(col.gameObject);
                    //Heal
                }
                break;
        }
    }

	private void OnTriggerEnter(Collider col) {


		switch (col.gameObject.tag) {
			case "Enemy":
			col.gameObject.GetComponent<Enemy>().Die();
			break;
			case "Gate":

			CloseGate gateLink = col.gameObject.GetComponent<CloseGate>();
			gateLink.fRemainingTime = gateLink.fMaxTime + fExtendedGateTime;            //++ Player Powerup Bonus
			gateLink.UpdateMesh();
			break;
			case "PowerUP":
			PowerUp01 PowerUpLink = col.gameObject.GetComponent<PowerUp01>();
			PowerUpLink.Power(this.gameObject);
			break; 
			case "Target":
                fTimer += Time.deltaTime;
                if (fTimer >= 1)
                {
                    fTimer = 0;
                    HealChilli(col.gameObject);
                }
                break;
		}



	}

}
