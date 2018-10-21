using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloseGate : MonoBehaviour
{

	public NavMeshSurface navMesh;
    public float fRemainingTime
    {
        get { return _fRemaingTime; }
        set
        {

            if (value >= 0) _fRemaingTime = value;

            if (_fRemaingTime <= 0)
            {
                this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
                this.gameObject.GetComponent<NavMeshObstacle>().enabled = false;
				UpdateMesh();

			}
			else
            {
                this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
                this.gameObject.GetComponent<NavMeshObstacle>().enabled = true;
			}
		}
    }

    //Set defaut value



    [SerializeField] public float fMaxTime = 10;
    private float _fRemaingTime = 0;
    private float fTimer = 0;

	public void UpdateMesh() {
		navMesh.BuildNavMesh();

	}
	private void FixedUpdate()
    {

        fTimer += Time.deltaTime;
        if (fTimer >= 1)
        {
            fTimer = 0;
            fRemainingTime -= 1;
            //Debug.Log(this.gameObject.name + ": " + fRemainingTime + " sec remaining");
        }


    }
}
