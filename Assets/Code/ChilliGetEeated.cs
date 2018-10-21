using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChilliGetEeated : MonoBehaviour
{


	public ParticleSystem eaten;

	private ParticleSystem particleEaten;
    //Counts Time for triggerd Damage Script - Every Second Damage should happen
    float fStayTimer = 0;

    //Property for ChilliHealth with auto check wheter its dead
    private void Start()
    {
        particleEaten = Instantiate(eaten, transform.position, Quaternion.identity);
    }
    public float fChilliHealth
    {
        get { return _fChilliHealth; }
        set
        {
        
            _fChilliHealth = Mathf.Clamp( value,0,100);
            Debug.Log(this.gameObject.name + "' Health: " + _fChilliHealth);
            if (_fChilliHealth <= 0)
            {
                transform.parent.GetComponent<ChiliMaster>().ChiliDied(transform.GetSiblingIndex());
                if (particleEaten.isPlaying) particleEaten.Stop();
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
            if (!particleEaten.isPlaying) particleEaten.Play();

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

    private void OnTriggerExit(Collider other)
    {
        if (particleEaten.isPlaying) particleEaten.Stop();
    }

}
