using System;
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


    
    AudioSource DeathSound;

    //assigned in Editor:
    [SerializeField] private NavMeshAgent NavAgent;
    [SerializeField] private Transform[] Eyes;
    [SerializeField] private Rigidbody RB; //RigidBody of this gameobject

    [SerializeField] private ParticleSystem dieAnim;

    public void FixedUpdate()
    {

        if (Target.activeSelf == false)
        {
            OnEnable();
        }

        NavAgent.destination = Target.transform.position;

        //point eyes at eyetargetposition
        foreach (Transform Eye in Eyes) Eye.rotation = Quaternion.LookRotation(Target.transform.position - transform.position + transform.position.y * Vector3.up, Vector3.up);
    }


    void OnEnable()
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

    private void Start()
    {
        DeathSound = GameObject.Find("DeathSound").gameObject.GetComponent<AudioSource>();

    }

    public void Die()
    {
        DeathSound.Play();


        Instantiate(dieAnim, gameObject.transform.position, Quaternion.identity);
        Spawner.Instance.Despawn(gameObject);
    }
}
