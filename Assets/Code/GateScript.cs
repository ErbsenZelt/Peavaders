using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

    private Vector3 RotationCenter;
    [SerializeField] private Transform Door;
    private float AngleIncrement = 0;
    private bool Status = false; //true = open

    private void Start()
    {
        Door = transform.GetChild(0).transform;
        RotationCenter = Door.transform.position + Vector3.left * Door.localScale.x / 2;
        Debug.DrawRay(RotationCenter, Vector3.up, Color.green, 10000);
    }

    public bool ChangeState(int secondsTillDone)
    {
        if (AngleIncrement == 0)
        {
            if (Status) AngleIncrement = 90 / secondsTillDone;
            else AngleIncrement = -90 / secondsTillDone;
            return true;
        }
        else return false;
    }
    
    private void FixedUpdate()
    {

        if (Door.rotation.eulerAngles.y >= 270 || Door.rotation.eulerAngles.y == 0) Door.RotateAround(RotationCenter, Vector3.up, AngleIncrement * Time.deltaTime);
        else
        {
            AngleIncrement = 0;
            if (Door.rotation.eulerAngles.y < 90)
            {
                Door.rotation = Quaternion.LookRotation(transform.forward, transform.up);
                Status = false;
            }
            else if (Door.rotation.eulerAngles.y < 270)
            {
                Door.rotation = Quaternion.LookRotation(-transform.right, transform.up);
                Status = true;
            }
        }
    }
}
