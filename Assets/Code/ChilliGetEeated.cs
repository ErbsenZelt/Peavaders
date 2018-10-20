using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChilliGetEeated : MonoBehaviour
{


    //Counts Time for triggerd Damage Script - Every Second Damage should happen
    float fStayTimer = 0;

    //Property for ChilliHealth with auto check wheter its dead
    public float fChilliHealth
    {
        get { return _fChilliHealth; }
        set
        {
            _fChilliHealth = value;
            if (_fChilliHealth <= 0)
            {
                // Disable Object
                this.gameObject.SetActive(false);
                Debug.Log(this.gameObject.name + " should have been disabled");
            }
        }
    }

    //Set defaut value
    [SerializeField] private float _fChilliHealth = 100;


    //Applys the damage
    private void DoDamage(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            //Do Damage ever Second
            fStayTimer += Time.deltaTime;
            if (fStayTimer > 1)
            {
                //Reset timer - counts only to one second...
                fStayTimer = 0;

                //Get Link to DefaultEnemieSettings for getting damage of enemy
                //GameObject Enemy = GameObject.Find(col.gameObject.name);
                DefaultEnemySettings EnemyLink = col.gameObject.GetComponent<DefaultEnemySettings>();

                fChilliHealth -= EnemyLink.fDamage;
            }
        }

        Debug.Log("Remaing health of " + this.gameObject.name + ": " + fChilliHealth);
    }


    //Do Damage evry second while collision
    private void OnTriggerStay(Collider col)
    {
        DoDamage(col);

    }

    //Initialize Timer
    private void OnTriggerEnter(Collider col)
    {
        DoDamage(col);

    }

    void Start()
    {


    }



}
