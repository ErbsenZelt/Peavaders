using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour {

    private Vector3 LastPos;
    [SerializeField, Range(0,1)] private float Smoothness = 0.1f;

    private void Start()
    {
        LastPos = transform.position;
    }

    void Update () {
        if (Vector3.Magnitude(transform.position - LastPos) > Smoothness)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - LastPos, Vector3.up);
            LastPos = transform.position;
        }
	}
}
