﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0;

    float speed = 5.0f;
    public float rotSpeed = 0.8f;

    float accuracy = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoints");
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0) return;

        Vector3 goal = new Vector3(waypoints[currentWP].transform.position.x,
                                            this.transform.position.y,
                                            waypoints[currentWP].transform.position.z);
        Vector3 direction = goal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotSpeed);
        Debug.DrawRay(this.transform.position, direction, Color.green);
        if (direction.magnitude < accuracy)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
