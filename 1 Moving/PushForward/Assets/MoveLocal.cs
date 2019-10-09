using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLocal : MonoBehaviour
{
    public Transform goal;
    float speed = 0.5f;
    float accuracy = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //create a goal that ignores vertical distance
        Vector3 LookAtgoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        
        this.transform.LookAt(LookAtgoal);
        //Translate between this and the goal in the x-z plane, stopping when within acciracy
        if (Vector3.Distance(transform.position, LookAtgoal) > accuracy){
            this.transform.Translate(0, 0, speed * Time.deltaTime);

        }
    }
}
