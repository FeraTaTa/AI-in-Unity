using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLocal : MonoBehaviour
{
    public Transform goal;
    float accuracy = 0.1f;

    float speed = 0.5f;
    float rotSpeed = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //create a goal that ignores vertical distance
        Vector3 LookAtgoal = new Vector3(goal.position.x, 
                                        this.transform.position.y, goal.position.z);
        Vector3 direction = LookAtgoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                                Quaternion.LookRotation(direction), 
                                                Time.deltaTime * rotSpeed);
        //Translate between this and the goal in the x-z plane, stopping when within acciracy
        if (Vector3.Distance(transform.position, LookAtgoal) > accuracy){
            this.transform.Translate(0, 0, speed * Time.deltaTime);

        }
    }
}
