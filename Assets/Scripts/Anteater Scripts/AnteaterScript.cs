﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnteaterScript : MonoBehaviour
{
    public SpeedButtons speedButtonsScript;
    public Transform[] waypoints;
    public int speed;

    private int waypointIndex;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        speedButtonsScript = GameObject.FindGameObjectWithTag("HUD").GetComponent<SpeedButtons>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (distance < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * speedButtonsScript.speedModifier * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
