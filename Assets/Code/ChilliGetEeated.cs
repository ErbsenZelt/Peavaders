using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChilliGetEeated : MonoBehaviour {

    float fStayTimer = 0;

    private float fChilliHealth
    {
        get { return _fChilliHealth; }
        set
        {
            _fChilliHealth = value;
            if (_fChilliHealth <=0)
            {
                // Destroy Object
                Debug.Log("I should have been destroyed");

                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);


            }
        }
    }

    private float _fChilliHealth;


    private void DoDamage(float fDmg)
    {
        Debug.Log("Hey Ho " + fChilliHealth);
        fChilliHealth -= fDmg;
    }


    private void OnTriggerStay(Collider col)
    {
       
        if (col.gameObject.tag == "Enemy")
        {
            //Do Damage ever Second
            fStayTimer += Time.deltaTime;
            if (fStayTimer > 1)
            {
                fStayTimer = 0;

                GameObject Enemy = GameObject.Find(col.gameObject.name);
                DefaultEnemySettings EnemyLink = Enemy.GetComponent<DefaultEnemySettings>();

                DoDamage(EnemyLink.fDamage);
            }
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        DefaultEnemySettings EnemyLink = col.gameObject.GetComponent<DefaultEnemySettings>();
         var r =EnemyLink.fDamage;

        fStayTimer = 0;
        Debug.Log("Hello there");
        //Debug.Log(col.gameObject.tag);
        //if (col.gameObject.tag == "Enemy")
        //{
        //    Debug.Log("Hello there");
        //    fChilliHealth -= 10;
        //}
      
    }

    void Start () {
        fChilliHealth = 100;

    }


}
