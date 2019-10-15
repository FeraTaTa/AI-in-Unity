using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform player;
    Animator anim;

    float rotSpeed = 2f;
    float speed = 2f;
    float visDistance = 20f;
    float visAngle = 30f;
    float shootDistance = 5f;

    string state = "IDLE";
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if(direction.magnitude < visDistance && angle < visAngle)
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotSpeed);
            if (direction.magnitude < shootDistance)
            {
                if (state != "SHOOTING")
                { 
                    state = "SHOOTING";
                    anim.SetTrigger("isShooting");
                }
            }
            else
            {
                if (state != "RUNNING")
                {
                    state = "RUNNING";
                    anim.SetTrigger("isRunning");
                }
            }
        }
        else
        {
            if (state != "IDLE")
            {
                state = "IDLE";
                anim.SetTrigger("isIdle");
            }
        }

        if(state == "RUNNING")
        {
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
