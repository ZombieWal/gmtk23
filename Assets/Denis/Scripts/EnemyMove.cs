using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 9;
    public float rotationSpeed = 1.5f;
    public float acceleration;

    private Transform target;
    private float startSpeed;

    public bool start_ = false;
    private void Awake()
    {
        if(FindObjectOfType<PlayerMovement>() != null)
            target = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Start()
    {
        //Invoke("Start_move", 1.5f);
    }

    private void Update()
    {
        if (start_)
        {
            if (acceleration > 1)
            {
                acceleration -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (start_)
        {
            if (target != null)
            {
                if (acceleration > 1)
                {
                    startSpeed = speed / acceleration;
                }
                else
                {
                    startSpeed = speed;
                }


                //var dir = target.position - transform.position;
                //transform.up = Vector3.MoveTowards(transform.up, dir, rotationSpeed * Time.deltaTime);

                transform.position = Vector3.MoveTowards(transform.position, target.position, startSpeed * Time.deltaTime);
            }
            else if (GameObject.Find("RIP_player(Clone)") != null)
            {
                target = GameObject.Find("RIP_player(Clone)").transform;
            }
        }
        else
        {
            transform.position = transform.position;
        }
    }

    void Start_move()
    {
        start_ = true;
    }
}
