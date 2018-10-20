using System;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

/*
 * attached to Enemy transform
 * moves towards the Target Position (Vector3) and tries to avoid all objects with the tag AvoidTag
*/
public class Enemy : MonoBehaviour {

    [SerializeField] private Transform TargetPos;

    //assigned in Editor:
    [SerializeField] private NavMeshAgent NavAgent;
    [SerializeField] private GameObject[] ToAvoid; //List of all objects that have the AvoidTag as tag. Only updated on Spawn()
    [SerializeField] private float AvoidDistance; //avoid is triggered when closer to an avoidobject than this distance
    [SerializeField] private float FleeSpeed;
    [SerializeField] private Transform[] Eyes;
    [SerializeField] private Transform EyeTarget;
    [SerializeField] private Rigidbody RB; //RigidBody of this gameobject

    //TESTING ONLY
    public void Start()
    {
        Spawn(Vector3.up * 3, "Avoid");
    }

    public void Spawn(Vector3 SpawnPos, string AvoidTag)
    {
        transform.position = SpawnPos;
        ToAvoid = GameObject.FindGameObjectsWithTag(AvoidTag);
        
        
    }

    public void FixedUpdate()
    {
        NavAgent.destination = TargetPos.position;
        //point eyes at eyetargetposition
        foreach (Transform Eye in Eyes) Eye.rotation = Quaternion.LookRotation(EyeTarget.position - transform.position + transform.position.y * Vector3.up, Vector3.up);

        //avoid ToAvoid Objects
        foreach (GameObject AvoidObject in ToAvoid)
        {
            Vector3 AwayFromObject = Vector3.ProjectOnPlane(transform.position - AvoidObject.transform.position, Vector3.up);
            if (AwayFromObject.magnitude < AvoidDistance)
            {
                RB.AddForce(
                    AwayFromObject.normalized * FleeSpeed);

            }
        }
    }
}
