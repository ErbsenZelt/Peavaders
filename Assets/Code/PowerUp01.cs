using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp01 : MonoBehaviour
{


    [SerializeField, Range(0,10)]
    public float fPlayerRunSpeed = 10;

    [SerializeField, Range(0, 60)]
    public float fExtendedGateTime = 10;

    [SerializeField, Range(1,60)]
    public float fPowerUpTime = 5;

    private bool isActive = false;
    private GameObject Target;



    private float fTimer = 0;

    public float fRemainigTime
    {
        get { return _fRemainingTime; }
        set
        {
            _fRemainingTime = Mathf.Clamp(value, 0, 60);
            if (_fRemainingTime == 0) DisablePower();
        }
    }


    private void DisablePower()
    {
        
       
            MovableCharacter PlayerLink = Target.transform.parent.GetComponent<MovableCharacter>();
            PlayerLink.moveSpeed -= fPlayerRunSpeed;
        
        isActive = false;
    }

    private void EnablePowers()
    {
        isActive = true;
       
            MovableCharacter PlayerLink = Target.transform.parent.GetComponent<MovableCharacter>();
            PlayerLink.moveSpeed += fPlayerRunSpeed;
       // PlayerLink = Target.GetComponent<KillPeanut>();


    }

    //Set defaut value
    [SerializeField] private float _fRemainingTime = 0;



    private void FixedUpdate()
    {
       if (_fRemainingTime>0)
        {
            fTimer += Time.deltaTime;
            if (fTimer >= 1)
            {
                fTimer = 0;
                fRemainigTime -= 1;
            }
        }
        


    }



    public void Power(GameObject go)
    {
        if (!isActive)
        {

            Target = go;
            Debug.Log(Target.name);
            EnablePowers();
            fRemainigTime = fPowerUpTime;
        }
        
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
