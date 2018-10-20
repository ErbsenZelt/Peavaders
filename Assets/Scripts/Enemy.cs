using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

/*
 * attached to Enemy transform
 * moves towards the Target Position (Vector3) and tries to avoid all objects with the tag AvoidTag
*/
public class Enemy : MonoBehaviour {

    //assigned in Editor:
    [SerializeField] private NavMeshAgent NavAgent;
    [SerializeField] private Vector3 TargetPos;
    [SerializeField] private GameObject[] ToAvoid; //List of all objects that have the AvoidTag as tag. Only updated on Spawn()
    [SerializeField] private Transform[] Eyes;
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
        NavAgent.destination = TargetPos; 
    }

    public void FixedUpdate()
    {
        //point eyes at targetposition
        foreach (Transform Eye in Eyes) Eye.rotation = Quaternion.LookRotation(NavAgent.destination - transform.position + transform.position.y * Vector3.up, Vector3.up); 

        //avoid ToAvoid Objects
        foreach (GameObject AvoidObject in ToAvoid)
        {
            Vector3 AwayFromTarget = transform.position - AvoidObject.transform.position;
            RB.velocity += AwayFromTarget/Vector3.SqrMagnitude(AwayFromTarget);
        }
    }
}
