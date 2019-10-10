using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Transform goal;
    float speed = 5f;
    float rotSpeed = 1.5f;
    float accuracy = 1.5f;
    public GameObject wpManager;    //holds all the waypoints which NPC needs to know
    GameObject[] wps;       //holds all waypoints from manager
    GameObject currentNode;  
    int currentWP = 0;      //index of waypoint in the path being followed
    Graph g;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[13];    //start near node14 (index 13) 
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[8]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        g.AStar(currentNode, wps[2]);
        currentWP = 0;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        //if object is at the end of path, do nothing
        if(g.getPathLength()==0 || currentWP == g.getPathLength())
        {
            return;
        }

        currentNode = g.getPathPoint(currentWP); //returns the node which matches up with next destination

        //if object is within distance of target then go to next waypoint
        if (Vector3.Distance(
            g.getPathPoint(currentWP).transform.position,
            transform.position) < accuracy)
        {
            currentWP++;
        }

        //if we are not at the end of the path
        if(currentWP < g.getPathLength())
        {
            goal = g.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,
                                            this.transform.position.y,
                                            goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                Quaternion.LookRotation(direction),
                                                Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, Time.deltaTime * speed);
            //Debug.DrawRay(this.transform.position, direction, Color.green);
        }
        //Debug.Log(g.getPathPoint(currentWP).transform.position);
    }
}
