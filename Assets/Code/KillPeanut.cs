using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPeanut : MonoBehaviour {

	public float fExtendedGateTime = 0;

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
		}


	}

}
