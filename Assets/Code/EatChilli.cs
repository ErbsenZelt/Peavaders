using UnityEngine;

public class EatChilli : MonoBehaviour {

    private void OnTriggerEnter(Collider col){
        Debug.Log(col.gameObject.name);
        Destroy(col);
    }

    //void OnTriggerEnter(Collision col)
    //{
    //    Debug.Log(col.gameObject.name);

    //    if (col.gameObject.name == "Cube")
    //    {
    //        Destroy(col.gameObject);
    //    }
    //}

}
