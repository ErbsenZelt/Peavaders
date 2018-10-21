using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObjectCamera : MonoBehaviour {

    [SerializeField] private Transform[] Targets;
    private Vector3 origin;
    [SerializeField] private Vector3 Offset = Vector3.back + Vector3.up;
    //[SerializeField] private float Distance { get { Height =  } }
    [SerializeField] private float Height;
    [SerializeField] private Vector2 FOV_Clamps = new Vector2(40, 120);

    private Camera Cam;

    private void Start()
    {
        Cam = transform.GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 newOrigin = Vector3.zero;
        foreach (Transform Target in Targets) newOrigin += Target.position;
        newOrigin /= Targets.Length;
        Debug.DrawRay(newOrigin, Vector3.up, Color.green, 10000);
        transform.position = newOrigin + Offset;
        transform.LookAt(newOrigin);

        Cam.fieldOfView += 5* Input.GetAxis("Mouse ScrollWheel");
        if (Cam.fieldOfView < FOV_Clamps.x) Cam.fieldOfView = FOV_Clamps.x;
        if (Cam.fieldOfView > FOV_Clamps.y) Cam.fieldOfView = FOV_Clamps.y;

        foreach (Transform Target in Targets)
        {
            Vector3 screenPoint = Cam.WorldToViewportPoint(Target.position);
            int i = 0;
            while (i<100 && !(screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)) { i++; transform.position += Offset.normalized; }
            Offset = transform.position - newOrigin;
        }
        origin = newOrigin;
    }
}
