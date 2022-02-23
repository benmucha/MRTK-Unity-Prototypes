using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public Camera lookingCamera;
    public Transform userIndicator;

    void Update() {
        Vector2 lookDirection = new Vector2(lookingCamera.transform.forward.x, lookingCamera.transform.forward.z);
        float angle = Vector2.SignedAngle(lookDirection, new Vector2(0, 1));
        userIndicator.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }  
}

