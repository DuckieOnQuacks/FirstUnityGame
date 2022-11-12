using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    public Transform player;
    public Transform playerAir;
    public Transform target;
    protected float followSpeed = 5;


    void Start()
    {
        if (!target) 
        {
            target = GameObject.FindGameObjectWithTag("FlyingPlayer").transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player")) 
        {
            target = GameObject.FindGameObjectWithTag("FlyingPlayer").transform;
            //transform.position = target.position + new Vector3(x,y,z);
            float xTarget = target.position.x + x;
            float yTarget = target.position.y + y;
            float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
            float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
            transform.position = new Vector3(xNew, yNew, transform.position.z);
        }
        else if(GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            float xTarget = target.position.x + x;
            float yTarget = target.position.y + y;
            float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
            float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
            transform.position = new Vector3(xNew, yNew, transform.position.z);
        }
    }
}


 /*   void Update()
    {
        if (!target || GameObject.FindGameObjectWithTag("Player") == null) 
        {
            target = GameObject.FindGameObjectWithTag("Flying Player").transform;
            //transform.position = target.position + new Vector3(x,y,z);
            float xTarget = target.position.x + x;
            float yTarget = target.position.y + y;
            float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
            float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
            transform.position = new Vector3(xNew, yNew, transform.position.z);
        }
        else if(!target || GameObject.FindGameObjectWithTag("Flying Player") == null) 
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            float xTarget = player.position.x + x;
            float yTarget = player.position.y + y;
            float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
            float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
            transform.position = new Vector3(xNew, yNew, transform.position.z);
        }
    }
}*/