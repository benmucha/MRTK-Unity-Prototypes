using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Camera lookingCamera;
    public GameObject compassDirectionMarkerPrefab;
    public GameObject degreeMarkerPrefab;
    public GameObject waypointMarkerPrefab;

    private CompassMarking[] markers;
    private List<Waypoint> waypoints;
    


    // Start is called before the first frame update
    void Start()
    {
        BuildCompass();
        northDirection = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = new Vector2(lookingCamera.transform.forward.x, lookingCamera.transform.forward.z);
        UpdateCompass(lookDirection);
    }


    const int markerCount = (360 / 15);
    const int maxMarkerIndex = markerCount - 1;
    const int halfMarkerCount = markerCount / 2;

    private Vector2 northDirection;
    private float lookHeading;
    const float degreeScale = 4f; // Affects spacing.


    private void UpdateCompass(Vector2 lookDirection)
    {
        lookHeading = Vector2.SignedAngle(lookDirection, northDirection);

        for (int i = 0; i < markerCount; i++)
            UpdateCompassMarkerPos(markers[i]);

        foreach (Waypoint waypoint in waypoints)
            UpdateCompassMarkerPos(waypoint);
    }

    private void UpdateCompassMarkerPos(CompassMarking marker)
    {
        marker.UpdatePos(GetHeadingPos(marker.heading));
    }

    private float GetHeadingPos(float heading)
    {
        float wrapHeading = (lookHeading + 180) % 360;
        float closestRelativeHeading;
        if (wrapHeading > lookHeading)
        {
            if (heading > wrapHeading)
            {
                closestRelativeHeading = (heading - 360) - lookHeading;
            }
            else
            {
                closestRelativeHeading = heading - lookHeading;
            }
        }
        else
        {
            if (heading > wrapHeading)
            {
                closestRelativeHeading = heading - lookHeading;
            }
            else
            {
                closestRelativeHeading = (360 - lookHeading) + heading;
            }
        }

        return closestRelativeHeading * degreeScale;
    }

    static string[] compassDirectionLabels = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };

    /// <summary>
    /// 
    /// </summary>
    private void BuildCompass()
    {
        markers = new CompassMarking[markerCount];
        for (int i = 0; i < markerCount; i++)
        {
            int degree = i * 15;
            GameObject markingPrefab;
            string markingText;
            if (degree % 45 == 0)
            {
                markingText = compassDirectionLabels[degree / 45];
                markingPrefab = compassDirectionMarkerPrefab;
            }
            else
            {
                markingPrefab = degreeMarkerPrefab;
                markingText = degree.ToString();
            }

            GameObject compassMarkingGO = Instantiate(markingPrefab, this.transform);
            compassMarkingGO.GetComponent<Text>().text = markingText;
            CompassMarking marking = compassMarkingGO.GetComponent<CompassMarking>();
            marking.heading = degree;
            markers[i] = marking;
        }

        waypoints = new List<Waypoint>();
        Waypoint waypoint = Instantiate(waypointMarkerPrefab, this.transform).GetComponent<Waypoint>();
        waypoint.heading = 42;
        waypoints.Add(waypoint);
    }
}
