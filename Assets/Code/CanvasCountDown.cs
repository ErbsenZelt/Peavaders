using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCountDown : MonoBehaviour {

    private float MaxValue;
    [SerializeField] private CloseGate OtherScript;
    [SerializeField] private Text display;
    [SerializeField] private Transform Camera;

    private void Update()
    {
        transform.LookAt(Camera);
        display.text = OtherScript.getRemainingTime().ToString();
    }
}
