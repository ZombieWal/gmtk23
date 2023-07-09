using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 9;
    public float rotationSpeed = 1.5f;

    public Transform target;

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

    }

    void FixedUpdate()
    {
        if (start_)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else if (GameObject.Find("RIP_player(Clone)") != null)
            {
                target = GameObject.Find("RIP_player(Clone)").transform;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void Start_move()
    {
        start_ = true;
    }
}
