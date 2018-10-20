using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPeanut : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enterd: " +  col.name);

        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
