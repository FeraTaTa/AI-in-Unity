using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    public GameObject wpManager;    //holds all the waypoints which NPC needs to know
    GameObject[] wps;       //holds all waypoints from manager
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void GoToHeli()
    {
        agent.SetDestination(wps[8].transform.position);
        //g.AStar(currentNode, wps[8]);
        //currentWP = 0;
    }

    public void GoToRuin()
    {
        agent.SetDestination(wps[2].transform.position);
        //g.AStar(currentNode, wps[2]);
        //currentWP = 0;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {

    }
}
