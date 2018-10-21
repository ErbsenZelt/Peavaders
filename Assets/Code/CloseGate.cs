using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloseGate : MonoBehaviour
{


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
                foreach (MeshRenderer mr in this.gameObject.GetComponentsInChildren<MeshRenderer>())
                {
                    mr.enabled = false;
                }
                
                
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;

                // Disable Object
                //this.gameObject.SetActive(false);
                //Debug.Log(this.gameObject.name + " should have been disabled");
            }
            else
            {
                this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
                this.gameObject.GetComponent<NavMeshObstacle>().enabled = true;
                //foreach (MeshRenderer mr in this.gameObject.GetComponentsInChildren<MeshRenderer>())
                //{
                //    mr.enabled = true;
                //}
                //this.gameObject.GetComponent<BoxCollider>().enabled = true;

            }
        }
    }

    //Set defaut value



    [SerializeField] public float fMaxTime = 10;
    private float _fRemaingTime = 0;
    private float fTimer = 0;

    private void FixedUpdate()
    {

        fTimer += Time.deltaTime;
        if (fTimer >= 1)
        {
            fTimer = 0;
            fRemainingTime -= 1;
            Debug.Log(this.gameObject.name + ": " + fRemainingTime + " sec remaining");
        }


    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
