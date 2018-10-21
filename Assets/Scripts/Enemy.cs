﻿using System;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

/*
 * attached to Enemy transform
 * moves towards the Target Position (Vector3) and tries to avoid all objects with the tag AvoidTag
*/
public class Enemy : MonoBehaviour
{

     private GameObject Target;
    [SerializeField] private GameObject[] ToAvoid; //List of all objects that have the AvoidTag as tag. Only updated on Spawn()

    //assigned in Editor:
    [SerializeField] private NavMeshAgent NavAgent;
    [SerializeField] private float AvoidDistance; //avoid is triggered when closer to an avoidobject than this distance
    [SerializeField] private float FleeSpeed;
    [SerializeField] private Transform[] Eyes;
   private Transform EyeTarget;
    [SerializeField] private Rigidbody RB; //RigidBody of this gameobject




    public void FindAvoidObjects(string AvoidTag)
    {
        ToAvoid = GameObject.FindGameObjectsWithTag(AvoidTag);
    }

    public void FixedUpdate()
    {

      if (Target.activeSelf == false)
        {
            Start();
        }

        NavAgent.destination = Target.transform.position;
        EyeTarget = Target.transform;


       

        //point eyes at eyetargetposition
        foreach (Transform Eye in Eyes) Eye.rotation = Quaternion.LookRotation(EyeTarget.position - transform.position + transform.position.y * Vector3.up, Vector3.up);

        //avoid ToAvoid Objects
        //foreach (GameObject AvoidObject in ToAvoid)
        //{
        //    Vector3 AwayFromObject = Vector3.ProjectOnPlane(transform.position - AvoidObject.transform.position, Vector3.up);
        //    if (AwayFromObject.magnitude < AvoidDistance)
        //    {
        //        RB.AddForce(
        //            AwayFromObject.normalized * FleeSpeed);

        //    }
        //}
    }


    public void Start()
    {

        float fShortestDistance;
        GameObject NearestGameObject;

        //initialize
        NearestGameObject = GameObject.FindGameObjectWithTag("Target");
        fShortestDistance = Vector3.Distance(this.gameObject.transform.position, NearestGameObject.transform.position);


        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Target"))
        {
            if (Vector3.Distance(this.gameObject.transform.position, go.transform.position) < fShortestDistance)
            {
                fShortestDistance = Vector3.Distance(this.gameObject.transform.position, go.transform.position);
                NearestGameObject = go;
            }

           //Debug.Log(go.name + ": " + Vector3.Distance(this.gameObject.transform.position, go.transform.position));
        }

        Target = NearestGameObject;


    }
	
	public void Die() {
		Spawner.Instance.Despawn(gameObject);
	}

}
