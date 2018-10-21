using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObjectCamera : MonoBehaviour {

    [SerializeField] private Transform[] Targets;
    [SerializeField] private Vector3 Offset = Vector3.back + Vector3.up;
    [SerializeField] private Vector2 FOV_Clamps = new Vector2(40, 120);

    private Camera Cam;

    private void Start()
    {
        Cam = transform.GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 origin = Vector3.zero;
        foreach (Transform Target in Targets) origin += Target.position;
        origin /= Targets.Length;
        Debug.DrawRay(origin, Vector3.up, Color.green, 10000);
        transform.position = origin + Offset;
        transform.LookAt(origin);

        Cam.fieldOfView += Input.GetAxis("Mouse ScrollWheel");
        if (Cam.fieldOfView < FOV_Clamps.x) Cam.fieldOfView = FOV_Clamps.x;
        if (Cam.fieldOfView > FOV_Clamps.y) Cam.fieldOfView = FOV_Clamps.y;

        foreach (Transform Target in Targets)
        {
            Vector3 screenPoint = Cam.WorldToViewportPoint(Target.position);
            while (!(screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)) { Debug.Log("Zooming out"); transform.position += Offset.normalized; }
            Offset = transform.position - origin;
        }
    }
}
