using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassMarking : MonoBehaviour
{
    public int heading;


    public void UpdatePos(float relativeHorizontalPos)
    {
        this.transform.localPosition = new Vector2(relativeHorizontalPos, this.transform.localPosition.y);
    }
}