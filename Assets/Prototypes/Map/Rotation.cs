using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rotator : MonoBehaviour
{
    public Camera lookingCamera;

    public float Angle;

    public GameObject player;

    void Update() {
        Vector2 lookDirection = new Vector2(lookingCamera.transform.forward.x, lookingCamera.transform.forward.z);
        lookingCamera.transform.rotation = 
    }

    void UpdateRo



    
}

